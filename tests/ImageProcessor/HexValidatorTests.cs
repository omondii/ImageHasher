namespace ImageHash.Tests;

public class HexValidatorTest
/*
 * HexValidator: Test suit for: ImageProcessor. HexValidator
 * SUT: ImageProcessor Class
 */
{
    // DI for Console mocking for our testclass
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public HexValidatorTest()
    {
        _input = Console.In;
        _output = Console.Out;
    }

    [Theory]
    [InlineData("0x24")]
    [InlineData("02ea")]
    [InlineData("345e")]
    [InlineData("0xdead")]
    public void TestValidHexString(string hexString)
    /*
     * TestValidHexString: Tests if a function receives an Invalid string
     * @hexString: Must be a hexadecimal equivalent string. 0x must be optional
     */
    {
        // Remove "0x" if present
        string expected = hexString.Replace("0x", "");

        // Act
        string validString = ImageProcessor.HexValidator(hexString);

        // Assert
        Assert.Equal(expected, validString);
    }

    [Theory]
    [InlineData("0x20re")]
    [InlineData("0xTeam")]
    [InlineData("4040HG")]
    public void TestInvalidHexString(string hexString)
    /*
     * TestInvalidHexString: Tests if function receives an invalid hexstring
     * @hexString: Must be a valid hexadecimal string
     */
    {
        // Setup console for Test-input
        var writer = new StringWriter();
        var reader = new StringReader("0x24"); // Valid input for each invalid one

        try
        {
            Console.SetOut(writer);
            Console.SetIn(reader);

            // Act
            var invalidHex = ImageProcessor.HexValidator(hexString);

            // Assert
            var received = writer.ToString();
            Assert.Contains("Invalid hex string", received);
            Assert.Equal("24", invalidHex);
        }
        finally
        {
            // Restore original I/O
            var output = _output;
            var input = _input;
            
            Console.SetOut(output);
            Console.SetIn(input);
        }
    }
}