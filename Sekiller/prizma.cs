using geometrik.Arayuz;
using System.Drawing;

namespace geometrik.Sekiller
{
    public class Prizma : Dikdortgen
    {
        public new const string Ismi = "Prizma";
        public int zUzunluk { get; set; }
        public void Ciz()
        {
            graphics.DrawImage(Ressam.Prizme, new Rectangle
            {
                X = X,
                Y = Y,
                Width = xUzunluk,
                Height = yUzunluk
            });
        }
    }
}
