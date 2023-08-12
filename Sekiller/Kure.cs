using geometrik.Arayuz;
using System.Drawing;

namespace geometrik.Sekiller
{
    public class Kure : Cember
    {
        public const string Ismi = "Kure";

        public new void Ciz()
        {

            graphics.DrawImage(Ressam.Kure, new Rectangle { X = X, Y = Y, Width = (int)(r + r), Height = (int)(r + r) });
        }
    }
}
