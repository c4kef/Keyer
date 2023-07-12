using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyerGui
{
    public partial class Form1 : Form
    {
        private KImage _image;
        private Color _selectedColor;
        private bool _isBusy;

        public Form1() => InitializeComponent();

        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show("Обработчик занят");
                return;
            }

            var dialog = new OpenFileDialog
            {
                Filter = "Изображения|*.png;*.jpg;*.jpeg;"
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                boxOriginal.Image?.Dispose();
                boxOriginal.Image = null;

                boxEdited.Image?.Dispose();
                boxEdited.Image = null;

                _image?.Dispose();

                _image = new KImage(dialog.FileName);
                boxOriginal.Image = _image.ImageOriginal;

                MessageBox.Show("Изображение загружено");
            }
            catch(Exception ex) 
            {
                _image?.Dispose();

                Console.Error.WriteLine(ex.Message);
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        private void MakeGreatImage_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show("Обработчик занят");
                return;
            }

            if (_image is null || _image.ImageOriginal is null)
            {
                MessageBox.Show("Укажите изображение для обработки");
                return;
            }

            _isBusy = true;

            var thresholdValue = thresholdBar.Value;

            Task.Run(() =>
            {
                try
                {
                    _image.RemoveKeyColor(_selectedColor, thresholdValue);

                    if (_image.ImageOutput is null)
                        throw new Exception("Изображение не обработано");

                    this.Invoke(new Action(() => boxEdited.Image = _image.ImageOutput));

                    MessageBox.Show("Изображение обработано");
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine(ex.Message);
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }

                _isBusy = false;
            });
        }

        private void BtnSaveOutput_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show("Обработчик занят");
                return;
            }

            if (_image is null || _image.ImageOutput is null)
            {
                MessageBox.Show("Сделайте обработку изображения");
                return;
            }

            var dialog = new SaveFileDialog
            {
                Filter = "Изображения|*.png"
            };

            if (dialog.ShowDialog() == DialogResult.Cancel)
                return;

            _image.ImageOutput.Save(dialog.FileName, ImageFormat.Png);
            MessageBox.Show("Изображение сохранено");
        }

        private void ColorPicker_Click(object sender, EventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show("Обработчик занят");
                return;
            }

            colorDialog1.Color = Color.FromArgb(0, 205, 24);

            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _selectedColor = colorViewer.BackColor = colorDialog1.Color;
        }

        private void BoxOriginal_MouseClick(object sender, MouseEventArgs e)
        {
            if (_isBusy)
            {
                MessageBox.Show("Обработчик занят");
                return;
            }

            if (_image is null)
                return;

            var b = (Bitmap)boxOriginal.Image;
            var x = e.X * b.Width / boxOriginal.ClientSize.Width;
            var y = e.Y * b.Height / boxOriginal.ClientSize.Height;
            _selectedColor = colorViewer.BackColor = b.GetPixel(x, y);
        }
    }
}
