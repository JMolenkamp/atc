<div style='text-align: right'>

[References](Index.md)&nbsp;&nbsp;-&nbsp;&nbsp;[References extended](IndexExtended.md)
</div>

# Atc.Rest.Helpers

<br />

## ProblemDetailsHelper

>```csharp
>public static class ProblemDetailsHelper
>```

### Static Methods

#### IsFormatJsonAndProblemDetailsModel
>```csharp
>bool IsFormatJsonAndProblemDetailsModel(string value)
>```
#### TrySerializeToProblemDetails
>```csharp
>bool TrySerializeToProblemDetails(string value, out ProblemDetails problemDetails)
>```
#### TrySerializeToProblemDetailsAndGetDetails
>```csharp
>bool TrySerializeToProblemDetailsAndGetDetails(string value, out string detailValue)
>```
#### TrySerializeToProblemDetailsAndGetStatusCode
>```csharp
>bool TrySerializeToProblemDetailsAndGetStatusCode(string value, out HttpStatusCode? statusCodeValue)
>```
#### TrySerializeToProblemDetailsAndGetTitle
>```csharp
>bool TrySerializeToProblemDetailsAndGetTitle(string value, out string titleValue)
>```
<hr /><div style='text-align: right'><i>Generated by MarkdownCodeDoc version 1.2</i></div>