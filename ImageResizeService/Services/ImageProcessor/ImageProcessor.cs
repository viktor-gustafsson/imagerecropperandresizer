using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using ImageResizeService.Controllers.Image.Models;
using ImageResizeService.Services.ImageProcessor.Models;
using ImageResizeService.Services.ImageService;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SkiaSharp;

namespace ImageResizeService.Services.ImageProcessor
{
    public class ImageProcessor : IImageProcessor
    {
        private readonly IImageService _imageService;

        public ImageProcessor(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<ModifiedImage> ReSizeImage(ImageResizeInputModel imageResizeInputModel)
        {
            var image = await _imageService.GetImage(imageResizeInputModel.Url);

            var info = new SKImageInfo(imageResizeInputModel.Height, imageResizeInputModel.Width);
            using (var surface = SKSurface.Create(info))
            {
                var surfaceCanvas = surface.Canvas;
                surfaceCanvas.DrawBitmap(image, new SKRect(0, 0, image.Width, image.Height),
                    new SKRect(0, 0, imageResizeInputModel.Width, imageResizeInputModel.Height));

                using (var encodedImage = surface.Snapshot())
                {
                    var data = encodedImage.Encode(SKEncodedImageFormat.Jpeg, 100);
                    return new ModifiedImage("image/jpeg", data.ToArray());
                }
            }
        }

        public Task<ModifiedImage> CropImage(ImageCropInputModel imageCropInputModel)
        {
            throw new System.NotImplementedException();
        }
    }
}