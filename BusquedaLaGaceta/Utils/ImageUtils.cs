﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusquedaLaGaceta.Utils
{
    public class ImageUtils
    {
        public ImageUtils()
        {

        }
        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }
        public static Image recortarImagen(Image imagen, Rectangle recuadro)
        {
            try
            {
                Bitmap bitmap = new Bitmap(imagen);
                Bitmap cropedBitmap = bitmap.Clone(recuadro, bitmap.PixelFormat);

                return (Image)(cropedBitmap);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
