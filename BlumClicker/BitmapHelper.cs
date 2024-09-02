using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumClicker
{
    public class BitmapHelper
    {
        public Bitmap bitmap;

        public BitmapHelper(Bitmap bitmap)
        {
            this.bitmap = bitmap;
        }


        public bool IsPixelColor(Point p, Color color)
        {
            if (bitmap.GetPixel(p.X, p.Y).ToArgb() == color.ToArgb())
                return true;
            else
                return false;
        }


        public Point SearchPixel(List<Color> colors)
        {
            // Перебор всех пикселей
            for (int y = bitmap.Height - 1; y >= 0; y--)
            {
                for (int x = bitmap.Width - 1; x >= 0; x--)
                {
                    // Получение цвета пикселя
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Сравнение цвета пикселя с целевым цветом
                    if (colors.Contains(pixelColor))
                        return new Point(x, y);
                }
            }

            return Point.Empty;
        }


    }
}
