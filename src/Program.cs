namespace ImageHash;

class Program
{
    static void Main(string[] args)
    /*
     * Main takes in 2 arguments
     * @hexString: A string off type Hexadecimal
     * @imagePath: path to an image file
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

        hexString = ImageProcessor.HexValidator(hexString);
        // Console.WriteLine(hexString);

        if (!File.Exists(imagePath))
        {
            Console.WriteLine("Image File Not Found");
        }

        try
        {
            using var modifyImage = ImageProcessor.ImageModifier(imagePath, hexString);
            using (var stream = new FileStream(newFile, FileMode.Create))
            {
                modifyImage.Save(stream, new SixLabors.ImageSharp.Formats.Png.PngEncoder());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}
