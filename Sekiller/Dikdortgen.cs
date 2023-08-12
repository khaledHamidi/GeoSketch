using geometrik.Arayuz;
using System.Drawing;

namespace geometrik.Sekiller
{
    public class Dikdortgen : Sekil
    {


        public new const string Ismi = "Dikdortgen";
        public Dikdortgen() { }

        public int yUzunluk { get; set; }
        public int xUzunluk { get; set; }
        public Dikdortgen(int x, int y, int xUzunluk, int yUzunluk)
        {
            X = x;
            Y = y;
            this.xUzunluk = xUzunluk;
            this.yUzunluk = yUzunluk;
        }

        public void Ciz(Graphics graphics)
        {
            graphics.DrawRectangle(
                Ressam.Active,
            X,
            Y,
            xUzunluk,
            yUzunluk);
        }
    }
}
