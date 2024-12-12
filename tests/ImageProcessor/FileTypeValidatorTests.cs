namespace ImageHash.Tests;

public class FileTypeValidatorTests
{
    // DI for console mocking
    private readonly TextReader _input;
    private readonly TextWriter _output;

    public FileTypeValidatorTests()
    {
        _input = Console.In;
        _output = Console.Out;
    }
    
    [Theory]
    [InlineData("image1.png")]
    [InlineData("2.png")]
    public void TestValidImageFormat(string filename)
    {
        // Act
        string validName = ImageProcessor.FileTypeValidator(filename);
        
        // Assert
        Assert.Equal(filename, validName);
    }

    [Theory]
    [InlineData("image1.jpeg")]
    [InlineData("image2.jpg")]
    [InlineData("image3.xml")]
    public void TestInvalidImageFormat(string filename)
    {
        var writer = new StringWriter();
        var reader = new StringReader("image.png");
        
        try
        {
            Console.SetOut(writer);
            Console.SetIn(reader);
            
            //Act
            string invalidName = ImageProcessor.FileTypeValidator(filename);
        
            // Assert
            var received = writer.ToString();
            Assert.Contains("Image type must be PNG. Check and retry...", received);
            Assert.Equal("image.png", invalidName);
        }
        finally
        {
            // Restore I/O
            var output = _output;
            var input = _input;
           
            Console.SetOut(output);
            Console.SetIn(input);

        }
        
    }

    [Theory]
    [InlineData("image")]
    [InlineData("76")]
    public void TestMissingImageFormatExtension(string filename)
    {
        var writer = new StringWriter();
        var reader = new StringReader("image.png");

        try
        {
            Console.SetOut(writer);
            Console.SetIn(reader);
            
            // Act
            var invalidImage = ImageProcessor.FileTypeValidator(filename);
            
            // Assert
            var received = writer.ToString();
            Assert.Contains("Image type must be PNG. Check and retry...", received);
            Assert.Equal("image.png", invalidImage);
        }
        finally
        {
           // Restore I/O
           var output = _output;
           var input = _input;
           
           Console.SetOut(output);
           Console.SetIn(input);

        }
    }
}