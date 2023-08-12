using geometrik.Arayuz;
using System.Drawing;

namespace geometrik.Sekiller
{
    public class Polygon : Sekil
    {

        public const string Ismi = "dortgen";
        public Polygon() { }

        public int yUzunluk { get; set; }
        public int xUzunluk { get; set; }
        public Polygon(int x, int y, int xUzunluk, int yUzunluk)
        {
            X = x;
            Y = y;
            this.xUzunluk = xUzunluk;
            this.yUzunluk = yUzunluk;
        }
        public Point[] Noktalar { get; set; }
        public void Ciz()
        {


            // Draw polygon to screen.
            graphics.FillPolygon(Ressam.Active.Brush, Noktalar);

        }
    }

}
