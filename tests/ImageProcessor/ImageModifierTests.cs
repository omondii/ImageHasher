using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageHash.Tests;

public class ImageModifierTests
{
    [Fact]
    public void ImageModifierGivesMatchingHash()
    {
        // Arrange
        string imagePath = "mockImage.png";
        string hash = "0x123";

        // var originalLoad = Image.Load<Rgba32>();
        // Image.Load<Rgba32>() = (Func<string, Image>)((path) => Conf.LoadMockImage(path));
        
        
    }
}