using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.PixelFormats;

namespace ImageResizeService.Services.ImageProcessor.Models
{
    public class ModifiedImage
    {
        public string ImageFormat { get; }
        public byte[] ImageAsBytes { get; }
        public ModifiedImage(string imageFormat, byte[] imageAsBytes)
        {
            ImageFormat = imageFormat;
            ImageAsBytes = imageAsBytes;
        }
    }
}