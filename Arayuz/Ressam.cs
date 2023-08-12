using System.Drawing;

namespace geometrik.Arayuz
{
    public class Ressam
    {
        static Color _rengi = Color.Blue;
        static int _boy = 3;
        public static Color rengi
        {
            get { return _rengi; }

            set
            {
                _rengi = value;
                Active = new Pen(_rengi, _boy);

            }
        }
        public static int boy
        {
            get { return _boy; }
            set
            {
                _boy = value;
                Active = new Pen(_rengi, _boy);
            }
        }
        public static Pen Active = new Pen(Color.Blue, 3);



        public static Image Silinder { get; set; }
        public static Image Prizme { get; set; }
        public static Image Kure { get; set; }


        public Ressam()
        {
            // etkinlestirme
        }

    }
}
