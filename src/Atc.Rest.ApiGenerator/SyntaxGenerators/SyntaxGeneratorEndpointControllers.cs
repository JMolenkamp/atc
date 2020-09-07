﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Atc.CodeAnalysis.CSharp.SyntaxFactories;
using Atc.Rest.ApiGenerator.Factories;
using Atc.Rest.ApiGenerator.Helpers;
using Atc.Rest.ApiGenerator.Models;
using Atc.Rest.ApiGenerator.ProjectSyntaxFactories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.OpenApi.Models;

// ReSharper disable ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
// ReSharper disable UseDeconstruction
namespace Atc.Rest.ApiGenerator.SyntaxGenerators
{
    public class SyntaxGeneratorEndpointControllers : ISyntaxGeneratorEndpointControllers
    {
        public SyntaxGeneratorEndpointControllers(
            ApiProjectOptions apiProjectOptions,
            string focusOnSegmentName)
        {
            this.ApiProjectOptions = apiProjectOptions ?? throw new ArgumentNullException(nameof(apiProjectOptions));
            this.FocusOnSegmentName = focusOnSegmentName ?? throw new ArgumentNullException(nameof(focusOnSegmentName));
        }

        public ApiProjectOptions ApiProjectOptions { get; }

        public string FocusOnSegmentName { get; }

        public CompilationUnitSyntax? Code { get; private set; }

        public bool GenerateCode()
        {
            var controllerTypeName = FocusOnSegmentName.EnsureFirstLetterToUpper() + "Controller";

            // Create compilationUnit
            var compilationUnit = SyntaxFactory.CompilationUnit();

            // Create a namespace
            var @namespace = SyntaxProjectFactory.CreateNamespace(
                ApiProjectOptions,
                NameConstants.Endpoints);

            // Create class
            var classDeclaration = SyntaxClassDeclarationFactory.Create(controllerTypeName)
                .AddAttributeLists(
                    SyntaxAttributeListFactory.CreateWithOneItem(nameof(ApiControllerAttribute)),
                    SyntaxAttributeListFactory.CreateWithOneItemWithOneArgument(nameof(RouteAttribute), $"api/{ApiProjectOptions.ApiVersion}/{FocusOnSegmentName}"))
                .AddBaseListTypes(SyntaxFactory.SimpleBaseType(SyntaxFactory.ParseTypeName(nameof(ControllerBase))))
                .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForEndpoints(FocusOnSegmentName));

            // Create Methods
            var usedApiOperations = new List<OpenApiOperation>();
            foreach (var (key, value) in ApiProjectOptions.Document.GetPathsByBasePathSegmentName(FocusOnSegmentName))
            {
                foreach (var apiOperation in value.Operations)
                {
                    var methodDeclaration = CreateMembersForEndpoints(apiOperation, key, ApiProjectOptions.ApiOptions.Generator.Response.UseProblemDetailsAsDefaultBody, FocusOnSegmentName)
                        .WithLeadingTrivia(SyntaxDocumentationFactory.CreateForEndpointMethods(apiOperation, FocusOnSegmentName));
                    classDeclaration = classDeclaration.AddMembers(methodDeclaration);

                    usedApiOperations.Add(apiOperation.Value);
                }
            }

            // Add the class to the namespace.
            @namespace = @namespace.AddMembers(classDeclaration);

            // Add using statement to compilationUnit
            compilationUnit = compilationUnit.AddUsingStatements(ProjectEndpointsFactory.CreateUsingList(ApiProjectOptions.ProjectName, FocusOnSegmentName, usedApiOperations));

            // Add namespace to compilationUnit
            compilationUnit = compilationUnit.AddMembers(@namespace);

            // Set code property
            Code = compilationUnit;
            return true;
        }

        public string ToCodeAsString()
        {
            if (Code == null)
            {
                GenerateCode();
            }

            if (Code == null)
            {
                return $"Syntax generate problem for endpoints-controller for: {FocusOnSegmentName}";
            }

            return Code
                .NormalizeWhitespace()
                .ToFullString();
        }

        public void ToFile()
        {
            var controllerName = FocusOnSegmentName.EnsureFirstLetterToUpper() + "Controller";
            var file = Util.GetCsFileNameForEndpoints(ApiProjectOptions.PathForEndpoints, controllerName);
            FileHelper.Save(file, ToCodeAsString());
        }

        public void ToFile(FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            FileHelper.Save(file, ToCodeAsString());
        }

        private static MethodDeclarationSyntax CreateMembersForEndpoints(
            KeyValuePair<OperationType, OpenApiOperation> apiOperation,
            string urlPath,
            bool useProblemDetailsAsDefaultResponseBody,
            string area)
        {
            var operationName = apiOperation.Value.GetOperationName();
            var interfaceName = "I" + operationName + NameConstants.ContractHandler;
            var methodName = operationName + "Async";
            var parameterTypeName = operationName + NameConstants.ContractParameters;
            var resultTypeName = operationName + NameConstants.ContractResult;

            // Create method # use CreateParameterList & CreateCodeBlockReturnStatement
            var methodDeclaration = SyntaxFactory.MethodDeclaration(
                    SyntaxFactory.GenericName(SyntaxFactory.Identifier(nameof(Task)))
                        .WithTypeArgumentList(SyntaxTypeArgumentListFactory.CreateWithOneItem(nameof(ActionResult))),
                    SyntaxFactory.Identifier(methodName))
                .AddModifiers(SyntaxTokenFactory.PublicKeyword())
                .AddModifiers(SyntaxTokenFactory.AsyncKeyword())
                .WithParameterList(CreateParameterList(apiOperation, parameterTypeName, interfaceName))
                .WithBody(
                    SyntaxFactory.Block(
                        SyntaxIfStatementFactory.CreateParameterArgumentNullCheck("handler"),
                        CreateCodeBlockReturnStatement(apiOperation.Value.HasParametersOrRequestBody())));

            // Create and add Http-method-attribute
            var httpAttributeRoutePart = GetHttpAttributeRoutePart(urlPath);
            methodDeclaration = string.IsNullOrEmpty(httpAttributeRoutePart)
                ? methodDeclaration.AddAttributeLists(
                    SyntaxAttributeListFactory.CreateWithOneItem($"Http{apiOperation.Key}"))
                : methodDeclaration.AddAttributeLists(
                    SyntaxAttributeListFactory.CreateWithOneItemWithOneArgument(
                        $"Http{apiOperation.Key}",
                        httpAttributeRoutePart));

            // Create and add producesResponseTypes-attributes
            var producesResponseAttributeParts = apiOperation.Value.Responses.GetProducesResponseAttributeParts(resultTypeName, useProblemDetailsAsDefaultResponseBody, area);
            return producesResponseAttributeParts
                .Aggregate(
                    methodDeclaration,
                    (current, producesResponseAttributePart) => current.AddAttributeLists(
                        SyntaxAttributeListFactory.CreateWithOneItem(producesResponseAttributePart)));
        }

        private static string GetHttpAttributeRoutePart(string urlPath)
        {
            var urlPathParts = urlPath.Split('/', StringSplitOptions.RemoveEmptyEntries);
            if (urlPathParts.Length <= 1)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            for (var i = 1; i < urlPathParts.Length; i++)
            {
                if (i != 1)
                {
                    sb.Append('/');
                }

                sb.Append(urlPathParts[i]);
            }

            return sb.ToString();
        }

        private static ParameterListSyntax CreateParameterList(
            KeyValuePair<OperationType, OpenApiOperation> apiOperation,
            string parameterTypeName,
            string interfaceName)
        {
            ParameterListSyntax parameterList;
            if (apiOperation.Value.HasParametersOrRequestBody())
            {
                parameterList = SyntaxFactory.ParameterList(
                    SyntaxFactory.SeparatedList<ParameterSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxParameterFactory.Create(parameterTypeName, "parameters"),
                            SyntaxTokenFactory.Comma(),
                            SyntaxParameterFactory.CreateWithAttribute(nameof(FromServicesAttribute), interfaceName, "handler"),
                            SyntaxTokenFactory.Comma(),
                            SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstLetterToLower())
                        }));
            }
            else
            {
                parameterList = SyntaxFactory.ParameterList(
                    SyntaxFactory.SeparatedList<ParameterSyntax>(
                        new SyntaxNodeOrToken[]
                        {
                            SyntaxParameterFactory.CreateWithAttribute(nameof(FromServicesAttribute), interfaceName, "handler"),
                            SyntaxTokenFactory.Comma(),
                            SyntaxParameterFactory.Create(nameof(CancellationToken), nameof(CancellationToken).EnsureFirstLetterToLower())
                        }));
            }

            return parameterList;
        }

        private static ReturnStatementSyntax CreateCodeBlockReturnStatement(bool hasParameters)
        {
            var arguments = hasParameters
                ? new SyntaxNodeOrToken[]
                {
                    SyntaxArgumentFactory.Create("parameters"),
                    SyntaxTokenFactory.Comma(),
                    SyntaxArgumentFactory.Create("cancellationToken")
                }
                : new SyntaxNodeOrToken[]
                {
                    SyntaxArgumentFactory.Create("cancellationToken")
                };

            return SyntaxFactory.ReturnStatement(
                SyntaxFactory.AwaitExpression(
                    SyntaxFactory.InvocationExpression(
                            SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("handler"),
                                SyntaxFactory.IdentifierName("ExecuteAsync")))
                        .WithArgumentList(
                            SyntaxFactory.ArgumentList(
                                SyntaxFactory.SeparatedList<ArgumentSyntax>(arguments)))));
        }
    }
}