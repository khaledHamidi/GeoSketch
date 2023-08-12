using geometrik.Arayuz;
using System.Drawing;

namespace geometrik.Sekiller
{
    public class Silindir : Dikdortgen
    {
        public new const string Ismi = "Silindir";
        public int Z = 0;

        public new void Ciz()
        {
            graphics.DrawImage(Ressam.Silinder, new Rectangle
            {
                X = X,
                Y = Y,
                Width = xUzunluk,
                Height = yUzunluk + xUzunluk / 8
            });
        }
    }
}
