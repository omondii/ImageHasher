using System.Security.Cryptography;
using System.Text.RegularExpressions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageHash;

public class ImageProcessor
{
    public static Image<Rgba32> ImageModifier(string imagePath, string hexString)
    /*
     * ImageModifier: Takes input Image and modifies it such that it's hash value starts
        with `hexString`.
     * @imagePath: (string.png)User input image to alter
     * @hexString: (string)Hexadecimal no. that modified image should start with.
     * Returns: a slightly modified image
     */
    {
        /* Load & make changes to the image using e ImageSharp library.
         ImageSharp stores pixel data in a contiguous memory buffer that allows for 2D
         coordinate access and manipulation. */
        using var originalImage = Image.Load<Rgba32>(imagePath);
        var workingImage = originalImage.Clone();
        //var count = 0; // A counter for each wrong hashValue (tests)

        var random = new Random();
        int maxAttempts = 1_000_000; // Total attempts 1M to prevent an infinite loop
                                     // while giving the prog enough iterations for complex hexstrings

        for (int attempts = 0; attempts < maxAttempts; attempts++)
        {
            var modImage = workingImage.Clone(); // Create a clone of the image for each attempt
            
            /*Randomly pick a pixel coordinate to modify
             Then, retrieve the specific pixel at the coordinate from image for modification.
             */ 
            int x = random.Next(modImage.Width);
            int y = random.Next(modImage.Height);
            var pixel = modImage[x, y];

            /* Randomly modify each pixel color channel at the coordinate by 1/-1 while ensuring the values
             remain between 0-255. 
             Color channels in a pixel are: Red, Green, Blue & Alpha
             Then, replace the modified pixel in the modImage.
            */
            pixel.R = (byte)Math.Clamp(pixel.R + (random.Next(2) * 2 - 1), 0, 255);
            pixel.G = (byte)Math.Clamp(pixel.G + (random.Next(2) * 2 - 1), 0, 255);
            pixel.B = (byte)Math.Clamp(pixel.B + (random.Next(2) * 2 - 1), 0, 255);

            modImage[x, y] = pixel;

            /* generate the images hash value and check if it starts with hexstring
             If it matches return the modified image, if not make this image the new working image
             and repeat the image modification & hash generation process.
            */
            var hash = ImageHasher(modImage);
            if (hash.StartsWith(hexString))
            {
                return modImage;
            }
            workingImage = modImage;
            //count++;
        }
        throw new Exception("Unable to produce a matching hexstring");
    }

    private static string ImageHasher(Image<Rgba32> image)
    /*
     * ImageHasher: computes a hash value from an image using the sha512 algo.
     * @image: (Image)a slightly altered image that will be assigned a custom hash value
     * Returns: (string)a normalized sha512 hash value
     */
    {
        using var memoryStream = new MemoryStream();
        image.Save(memoryStream, new SixLabors.ImageSharp.Formats.Png.PngEncoder()); // save the hashedImage into memory, support for png Image type 
        using var sha = SHA512.Create();
        var hashBytes = sha.ComputeHash(memoryStream.ToArray());
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }

    public static string HexValidator(string? hexString)
    /*
     * HexValidator: Validates entered string to ensure it's a hexadecimal equivalent
     * @hexString: a hexadecimal string.
     * Returns: A valid normalized hexstring.
     */
    {
        // Regex pattern representing a valid hexadecimal composition.
        string pattern = @"^(0x)?[0-9a-fA-F]+$";

        while (!string.IsNullOrEmpty(hexString) && !Regex.IsMatch(hexString, pattern))
        {
            Console.Write("Invalid hex string:");
            hexString = Console.ReadLine();
        }
        return hexString?.Replace("0x", "").ToLower() ?? string.Empty;
    }

    public static string FileTypeValidator(string? fileName)
    /*
      * FileTypeValidator: Checks if image and new image name passed are of type png
      * @imageName: a string path to an image
      * Returns: the path name if it's a valid .png string
      */
    {
        while (!string.IsNullOrEmpty(fileName) && !fileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("Image type must be PNG. Check and retry...");
            fileName = Console.ReadLine();
        }
        return fileName ?? string.Empty;
    }
}
