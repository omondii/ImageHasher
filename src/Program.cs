namespace ImageHash;

class Program
{
    static void Main(string[] args)
    /*
     * Program entry point. Takes 3 arguments
     * @hexString: A string off type Hexadecimal
     * @imagePath: path to an image file(original Image)
     * @newFile: name to save the altered image with
     */
    {
        if (args.Length != 3)
        {
            Console.WriteLine("Usage:spoof haxValue originalImage.png saveName.png");
            return;
        }

        string hexString = args[0];
        string imagePath = args[1];
        string newFile = args[2];
        
        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image File Not Found");
        }
        
        // Validate user Input
        hexString = ImageProcessor.HexValidator(hexString);
        // imagePath = ImageProcessor.IsPng(imagePath);
        // newFile = ImageProcessor.IsPng(newFile);

        try
        {
            // Use provided args to modify & get a hash value using the ImageProcessor class
            using var modifiedImage = ImageProcessor.ImageModifier(imagePath, hexString);
            using var stream = new FileStream(newFile, FileMode.Create);
            modifiedImage.Save(stream, new SixLabors.ImageSharp.Formats.Png.PngEncoder()); // Save .png Image using use provided name 
            Console.WriteLine("Done");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
