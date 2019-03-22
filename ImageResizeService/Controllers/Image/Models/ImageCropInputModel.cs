using System.ComponentModel.DataAnnotations;
using ImageResizeService.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;

namespace ImageResizeService.Controllers.Image.Models
{
    public class ImageCropInputModel : ImageConversionBaseModel
    {
        [Required]
        [SizeValidator]
        [FromQuery(Name = "left")]
        public int Left { get; set; }

        [Required]
        [SizeValidator]
        [FromQuery(Name = "top")]
        public int Top { get; set; }
        
        [Required]
        [SizeValidator]
        [FromQuery(Name = "right")]
        public int Right { get; set; }   
        
        [Required]
        [SizeValidator]
        [FromQuery(Name = "bottom")]
        public int Bottom { get; set; }
        
        public SKSize Size => new SKSize(Width, Height);
    }
}