namespace Atc.Tests.Extensions;

public class AppDomainExtensionsTests
{
    [Fact]
    public void GetAllExportedTypes()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetAllExportedTypes();

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetExportedTypeByName()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetExportedTypeByName(nameof(UnexpectedTypeException));

        // Assert
        Assert.NotNull(actual);
        Assert.Equal(typeof(UnexpectedTypeException), actual);
    }

    [Fact]
    public void GetExportedPropertyTypeByName()
    {
        // Act
        var actual = AppDomain.CurrentDomain.GetExportedPropertyTypeByName(nameof(UnexpectedTypeException), nameof(UnexpectedTypeException.Message));

        // Assert
        Assert.NotNull(actual);
    }

    [Fact]
    public void GetCustomAssemblies()
    {
        // Act
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var customAssemblies = AppDomain.CurrentDomain.GetCustomAssemblies();

        // Assert
        Assert.NotNull(assemblies);
        Assert.NotNull(customAssemblies);

        assemblies
            .Should()
            .HaveCountGreaterThan(customAssemblies.Length);
    }
}