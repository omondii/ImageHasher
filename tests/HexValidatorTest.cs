namespace ImageHash.Tests;

public class HexValidatorTest
{
    [Fact]
    public void TestValidHexString()
    {
        // Arrange
        const string hexString = "0x24";
        var expected = hexString.Replace("0x", "");
        
        // Act
        string validString = ImageProcessor.HexValidator(hexString);
        
        
        // Assert
        Assert.Equal(expected, validString);
    }
}