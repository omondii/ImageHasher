using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageHash.Tests;

public class Conf
/*
 * Test Setup Class.
 * Func:: MockImage: Image creation
 * Func:: LoadMockImage: Wrapper function for MockImage
 */
{
    private static Image<Rgba32> MockImage(int width = 100, int height = 100)
    /*
     * MockImage: Create a mock Image for testing
     * @width: Sets the mock image width
     * @height: sets the mock image height
     */
    {
        var mockImage = new Image<Rgba32>(width, height);
        return mockImage;
    }

    public static Image<Rgba32> LoadMockImage(string imagePath, int width = 100, int height = 100)
    /*
     * CreateMockImage: Mocks the image loading process and returns an image for testing
     * @imagePath: Dummy param to match the ImageModifier method
     * Returns: fake image data
     */
    {
        return MockImage(width, height);
    }

}