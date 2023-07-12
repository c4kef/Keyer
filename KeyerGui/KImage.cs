using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace KeyerGui
{
    internal class KImage
    {
        private enum ImageFormat
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            unknown
        }

        public Bitmap ImageOriginal { get; private set; }
        public Bitmap ImageOutput { get; private set; }

        public KImage(string imagePath)
        {
            if (!File.Exists(imagePath))
                throw new Exception("Изображение не найдено");

            var mimetype = GetImageFormat(File.ReadAllBytes(imagePath));

            if (!mimetype.Equals(ImageFormat.png) && !mimetype.Equals(ImageFormat.jpeg))
                throw new Exception("Расширение файла не поддерживается");

            ImageOriginal = new Bitmap(imagePath);
        }

        ~KImage() => Dispose();

        public void RemoveKeyColor(Color key, double threshold)
        {
            if (key.Equals(default))
                throw new Exception("Цвет не был установлен");

            if (ImageOriginal is null)
                throw new Exception("Изображение не было загружено");

            ImageOutput?.Dispose();

            //Создаем локальную переменную и на неё передаем изображение
            var image = new Bitmap(ImageOriginal);

            unsafe
            {
                var thresh = threshold * threshold;

                //Лочим массив для от прямого доступа
                var data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppPArgb);

                int sR = key.R, sG = key.G, sB = key.B;
                //Заранее считаем макс. длину чтобы лишний раз её не прогонять
                var length = (int*)data.Scan0 + image.Height * image.Width;

                for (var p = (int*)data.Scan0; p < length; p++)
                {
                    //Получаем разброс цветов из цвета хромокея
                    var r = ((*p >> 16) & 255) - sR;
                    var g = ((*p >> 8) & 255) - sG;
                    var b = ((*p >> 0) & 255) - sB;

                    if ((r * r) + (g * g) + (b * b) > thresh)
                        continue;

                    //Применяем цвет к этому пикселю
                    *p = Color.Transparent.ToArgb();
                }

                image.UnlockBits(data);
            }

            ImageOutput = new Bitmap(image);
            image.Dispose();
        }

        //Оригинал: https://stackoverflow.com/questions/210650/validate-image-from-file-in-c-sharp/9446045#9446045
        private ImageFormat GetImageFormat(byte[] bytes)
        {
            // see http://www.mikekunz.com/image_file_header.html  
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return ImageFormat.unknown;
        }

        public void Dispose()
        {
            ImageOriginal?.Dispose();
            ImageOutput?.Dispose();

            ImageOriginal = ImageOutput = null;
            GC.Collect();
        }
    }
}
