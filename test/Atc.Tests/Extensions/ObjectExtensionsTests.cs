namespace Atc.Tests.Extensions;

public class ObjectExtensionsTests
{
    [Fact]
    public void GetPropertyValue()
    {
        // Arrange
        var sut = new LogKeyValueItem(
            LogCategoryType.Debug,
            "MyKey",
            "MyValue",
            "MyDescription");

        // Act
        var actualLogCategory = sut.GetPropertyValue("LogCategory");
        var actualKey = sut.GetPropertyValue("Key");
        var actualValue = sut.GetPropertyValue("Value");
        var actualDescription = sut.GetPropertyValue("Description");

        // Assert
        Assert.Equal(LogCategoryType.Debug, actualLogCategory);
        Assert.Equal("MyKey", actualKey);
        Assert.Equal("MyValue", actualValue);
        Assert.Equal("MyDescription", actualDescription);
    }
}