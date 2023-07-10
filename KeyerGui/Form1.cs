using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace KeyerGui
{
    public partial class Form1 : Form
    {
        private Bitmap _imageOriginal;
        private Bitmap _imageOutput;
        private Color _selectedColor;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Изображения|*.jpg;*.jpeg;*.png;*.gif;*.tif;..."
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            _imageOriginal = new Bitmap(dialog.FileName);
            boxOriginal.Image = _imageOriginal;
            MessageBox.Show("Изображение загружено");
        }

        private void makeGreatImage_Click(object sender, EventArgs e)
        {
            if (_imageOriginal is null)
            {
                MessageBox.Show("Укажите изображение для обработки");
                return;
            }

            var pixelArr = ToPixelArray(_imageOriginal);

            RemoveKeyColor(pixelArr, _selectedColor, pixelArr.Length, thresholdBar.Value);

            _imageOutput = ToOutputBitmap(pixelArr, _imageOriginal.Width, _imageOriginal.Height);
            boxEdited.Image = _imageOutput;
            MessageBox.Show("Изображение обработано");
        }

        private void RemoveKeyColor(byte[] pixelArray, Color key, int size, double threshold)
        {
            var thresh = threshold * threshold;

            int sourceRed = key.R, sourceGreen = key.G, sourceBlue = key.B;

            for (var i = 0; i < size; i += 4)
            {
                var r = ((pixelArray[i + 1]) & 255) - sourceRed;
                var g = ((pixelArray[i + 2]) & 255) - sourceGreen;
                var b = ((pixelArray[i + 3]) & 255) - sourceBlue;

                if ((r * r) + (g * g) + (b * b) > thresh)
                    continue;

                pixelArray[i] = 0;
                pixelArray[i + 1] = 0;
                pixelArray[i + 2] = 0;
                pixelArray[i + 3] = 0;
            }
        }

        private Bitmap ToOutputBitmap(byte[] pixelArray, int width, int height)
        {
            var outputBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            var pixelIndex = 0;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var pixelColor = Color.FromArgb(pixelArray[pixelIndex], pixelArray[pixelIndex + 1], pixelArray[pixelIndex + 2], pixelArray[pixelIndex + 3]);
                    outputBitmap.SetPixel(j, i, pixelColor);//Знаю, долго. Но я честно говоря не знаю как ускорить его
                    pixelIndex += 4;
                }
            }

            return outputBitmap;
        }

        private byte[] ToPixelArray(Bitmap inputBitmap)
        {
            var width = inputBitmap.Width;
            var height = inputBitmap.Height;
            var arraySize = width * height * 4;

            var pixelArray = new byte[arraySize];

            var pixelIndex = 0;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    pixelArray[pixelIndex] = inputBitmap.GetPixel(j, i).A;
                    pixelArray[pixelIndex + 1] = inputBitmap.GetPixel(j, i).R;
                    pixelArray[pixelIndex + 2] = inputBitmap.GetPixel(j, i).G;
                    pixelArray[pixelIndex + 3] = inputBitmap.GetPixel(j, i).B;

                    pixelIndex += 4;
                }
            }

            return pixelArray;
        }

        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            if (_imageOutput is null)
            {
                MessageBox.Show("Сделайте обработку изображения");
                return;
            }

            var dialog = new SaveFileDialog
            {
                Filter = "Изображения|*.jpg;*.jpeg;*.png;*.gif;*.tif;..."
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            _imageOutput.Save(dialog.FileName);
            MessageBox.Show("Изображение сохранено");
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Color.FromArgb(0, 205, 24);

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _selectedColor = colorViewer.BackColor = colorDialog1.Color;
        }

        private void boxOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            if (_imageOriginal is null)
                return;

            var b = (Bitmap)boxOriginal.Image;
            var x = e.X * b.Width / boxOriginal.ClientSize.Width;
            var y = e.Y * b.Height / boxOriginal.ClientSize.Height;
            _selectedColor = colorViewer.BackColor = b.GetPixel(x, y);
        }
    }
}
