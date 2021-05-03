using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT_praktika_11
{
  public partial class Form1 : Form
  {
    private Bitmap bmp;
    private Graphics g;

    public Form1()
    {
      InitializeComponent();
    }
    private void button1_Click(object sender, EventArgs e)
    {
      OpenFileDialog dialog = new OpenFileDialog();
      dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)|*.bmp;*.jpg;*.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
      if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно и проверяем выбран ли файл
      {
        Image image = Image.FromFile(dialog.FileName); //Загружаем в image изображение из выбранного файла
        int width = image.Width;
        int height = image.Height;
        pictureBox1.Width = width;
        pictureBox1.Height = height;

        bmp = new Bitmap(image, width, height); //создаемизагружаемиз image изображениевформате bmp

        pictureBox1.Image = bmp; //записываем изображение в формате bmp в pictureBox1
        g = Graphics.FromImage(pictureBox1.Image); //подготавливаем объект Graphics для рисования в pictureBox1

      }
    }
    private void button2_Click(object sender, EventArgs e)
    {
      if (pictureBox1.Image != null)
      { 
        for (int i = 0; i < bmp.Width; i++)
          for (int j = 0; j < bmp.Height; j++)
          {
            int R = bmp.GetPixel(i, j).R; //извлекаем в R значение красного цвета в текущей точке
            Color p = Color.FromArgb(R, 0, 0); //переводим int в значение цвета. 255 - показывает степень прозрачности. остальные значения одинаковы для трех каналов R,G,B
            bmp.SetPixel(i, j, p); //записываме полученный цвет в текущую точку
          }
        Refresh(); //вызываем функцию перерисовки окна
      }
    }

    private void button3_Click(object sender, EventArgs e)
    {
      if (pictureBox1.Image != null)
      {
        for (int i = 0; i < bmp.Width; i++)
          for (int j = 0; j < bmp.Height; j++)
          {
            int R = bmp.GetPixel(i, j).R; //извлекаем в R значение красного цвета в текущей точке
            int G = bmp.GetPixel(i, j).G;
            int B = bmp.GetPixel(i, j).B;
            int Gray = (R = G + B) / 3;
            Color p = Color.FromArgb(Gray, Gray, Gray); //переводим int в значение цвета. 255 - показывает степень прозрачности. остальные значения одинаковы для трех каналов R,G,B
            bmp.SetPixel(i, j, p); //записываме полученный цвет в текущую точку
          }
        Refresh(); //вызываем функцию перерисовки окна
      }
    }
  }
}
