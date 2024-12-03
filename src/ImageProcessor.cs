using System.Security.Cryptography;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageHash;

public class ImageProcessor
{
    public static Image<Rgba32> ImageModifier(string imagePath, string hexString)
    /*
     * ImageModifier: Takes input Image and modifies it such that it's hash value starts
        with `hexString`.
     * @imagePath: User input image to alter
     * @hexString: Hexadecimal no. that modified image should start with.
     */
    {
        // Load Image using e ImageSharp library. 
        using var originalImage = Image.Load<Rgba32>(imagePath);
        var workingImage = originalImage.Clone();

        var random = new Random();
        int maxAttempts = 1_000_000; // Total attempts 1M to prevent an infinite loop

        for (int attempts = 0; attempts < maxAttempts; attempts++)
        {
            var modImage = workingImage.Clone(); // Create a clone of the image for each attempt
            // Randomly pick a pixel coordinate to modify, then replace in the modification image
            int x = random.Next(modImage.Width); 
            int y = random.Next(modImage.Height);
            var pixel = modImage[x, y];
            
            /* Slightly modify the image by removing/adding -1/1 to each pixel
             Eg: If red is 100 it will be 99 or 101
            */
            pixel.R = (byte)Math.Clamp(pixel.R + (random.Next(2) * 2 - 1), 0, 255);
            pixel.G = (byte)Math.Clamp(pixel.G + (random.Next(2) * 2 - 1), 0, 255);
            pixel.B = (byte)Math.Clamp(pixel.B + (random.Next(2) * 2 - 1), 0, 255);
            
            modImage[x, y] = pixel;

            /* generate the images hash value and check if it starts with hexstring
             If it matches return the modified image, if not make this image the new working image 
            */
            var hash = ImageHasher(modImage);
            if (hash.StartsWith(hexString))
            {
                return workingImage;
            }
            workingImage = modImage;
        }
        throw new Exception("Unable to produce a matching hexstring");
    }

    private static string ImageHasher(Image<Rgba32> image)
    /*
     * ImageHasher: uses a slightly altered image to generate a hash value
     * @image: a slightly altered image that will be assigned a custom hash value
     */
    {
        using var memoryStream = new MemoryStream();
        image.Save(memoryStream, new SixLabors.ImageSharp.Formats.Png.PngEncoder());
        using var sha256 = SHA256.Create();
        var hashBytes = sha256.ComputeHash(memoryStream.ToArray());
        return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
    }
}