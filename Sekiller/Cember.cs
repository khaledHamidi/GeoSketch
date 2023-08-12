using geometrik.Arayuz;

namespace geometrik.Sekiller
{
    public class Cember : Sekil
    {
        // iterator
        public Cember() { }
        public const string Ismi = "Cember";

        private float _r;
        public float r { get { return _r; } set { _r = value; } }

        public Cember(int x, int y, float r)
        {
            X = x;
            Y = y;
            this.r = r;
        }

        /// <summary>
        /// merkez O(X,y) return X
        /// </summary>
        /// <returns></returns>
        public int oX()
        {
            return (int)(X + r);
        }
        public int oY()
        {
            return (int)(Y + r);
        }


        public void Ciz()
        {

            // x y w h
            // x2-x1 = x+
            graphics.DrawEllipse(Ressam.Active, X, Y,
                r + r, r + r);


        }
    }
}
