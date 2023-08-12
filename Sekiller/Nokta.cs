using geometrik.Arayuz;
using System.Drawing;

namespace geometrik.Sekiller
{
    public class Nokta : Sekil
    {
        // iterator
        public Nokta() { }
        public new const string Ismi = "Nokta";

        public int hacmi { get; set; }

        public void Ciz()
        {
            graphics.DrawLine(
                Ressam.Active, new Point(X, Y), new Point(X + Ressam.boy, Y + Ressam.boy));
        }
    }

}
