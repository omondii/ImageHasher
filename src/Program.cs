namespace ImageHash;

class Program
{
    static void Main(string[] args)
    /*
     * Main takes in 3 arguments
     * @hexString: A string off type Hexadecimal.
     * @imagePath: path to an image file.
     * @newFile: path to save the modified image to.
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

        // Input validation
        hexString = ImageProcessor.HexValidator(hexString);
        imagePath = ImageProcessor.FileTypeValidator(imagePath);
        newFile = ImageProcessor.FileTypeValidator(newFile);

        // if (!File.Exists(imagePath) )
        // {
        //     Console.WriteLine("Image File Not Found");
        // }

        try
        {
            /* Application entry point.
             Pass the provided Image to the processor func together with the hexstring to prefix the hash value
             Save the modified Image to the provided location with the provided name
             */
            using var modifiedImage = ImageProcessor.ImageModifier(imagePath, hexString);
            using var fs = new FileStream(newFile, FileMode.Create);
            modifiedImage.Save(fs, new SixLabors.ImageSharp.Formats.Png.PngEncoder());
            Console.WriteLine($"Image Saved as {newFile}");
        }
        catch (Exception)
        {
            Console.WriteLine($"Operation Unsuccessful");
        }
    }
}
