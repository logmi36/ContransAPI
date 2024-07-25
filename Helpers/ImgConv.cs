using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;


namespace CtrApp8.Helpers
{
    public class ImgConv
    {

        private static string GetURL(string file, string code, string size)
        {
            string url = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\Images\" + file + @"\" + size + @"\" + code + ".jpg");
            url = url.Replace("..", "");
            return url;
        }

        public static string ImageToUrl(string file, string code, string size)
        {
            string url;
            url = GetURL(file, code, size);
            if (!File.Exists(url))
            {
                code = "000000";
            }
            url = @"Images/" + file + @"/" + size + @"/" + code + ".jpg";
            return url;

        }


        public static string ImageToString(string file, string code, string size)
        {
            string url;
            url = GetURL(file, code, size);

            Image ims;

            if (!File.Exists(url))
            {
                code = "000000";
                url = GetURL(file, code, size);
            }

            ims = Image.FromFile(url);

            ImageConverter imc = new ImageConverter();
            byte[] contents = (byte[])imc.ConvertTo(ims, typeof(byte[]));

            string ans;
            ans = Convert.ToBase64String(contents, 0, contents.Length);
            return ans;

        }



        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static Bitmap ThumbnailImageSquare(Image originalImage, string size)
        {
            // Img en cuadrado
            int largestDimension = Math.Min(originalImage.Height, originalImage.Width);
            Size squareSize = new Size(largestDimension, largestDimension);
            Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
            using (Graphics graphics = Graphics.FromImage(squareImage))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, squareSize.Width, squareSize.Height);
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(originalImage, 0, 0, originalImage.Width, originalImage.Height);
            }

            Image img = squareImage;
            Bitmap bmp;

            // Img cambio de tamaño
            switch (size)
            {
                case "small":       // 32x32
                    bmp = ResizeImage(img, 32, 32);
                    break;
                case "64x64":   // 64x64
                    bmp = ResizeImage(img, 64, 64);
                    break;
                case "normal":      // 128x128
                    bmp = ResizeImage(img, 128, 128);
                    break;
                case "lg":       // 256x256
                    bmp = ResizeImage(img, 256, 256);
                    break;
                case "150x150":       // 150x0150
                    bmp = ResizeImage(img, 150, 150);
                    break;
                case "original":
                    bmp = squareImage;
                    break;
                default:
                    bmp = null;
                    break;
            }

            return bmp;
        }

    }
}
