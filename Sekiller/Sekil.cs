using geometrik.YardimciFunkisyon;
using System;
using System.Drawing;

namespace geometrik.Sekiller
{
    public class Sekil
    {
        public const string Ismi = "Sekil";

        int x = 0, y = 0, _merkez = 0;

        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public int merkez { get { return _merkez; } set { _merkez = value; } }

        public Graphics graphics { get; set; }
        public Point GetPoint()
        {
            return new Point(x, y);
        }




        static bool yok = false;
        public static bool GetCarpisma(object resim1, object resim2)
        {
            if (resim1.GetType() == resim2.GetType())
            {
                if (resim1.GetType() == typeof(Cember))
                    return Carpisma((Cember)resim1, (Cember)resim2);
                else if (resim1.GetType() == typeof(Nokta))
                    return Carpisma((Nokta)resim1, (Nokta)resim2);
                else if (resim1.GetType() == typeof(Dikdortgen))
                    return Carpisma((Dikdortgen)resim1, (Dikdortgen)resim2);
                else if (resim1.GetType() == typeof(Nokta))
                    return Carpisma((Nokta)resim1, (Nokta)resim2);
            }
            else if (resim1.GetType() == typeof(Cember) &&
                    resim2.GetType() == typeof(Nokta)
                    )
                return Carpisma((Nokta)resim2, (Cember)resim1);
            else if (resim1.GetType() == typeof(Cember) &&
                resim2.GetType() == typeof(Dikdortgen))
                return Carpisma((Dikdortgen)resim2, (Cember)resim1);

            if (yok) return false;
            yok = true;
            return GetCarpisma(resim2, resim1);

        }

        /// <summary>
        /// iki nokta carpismasa True,
        /// </summary>
        /// <param name="nokta1"></param>
        /// <param name="nokta2"></param>
        /// <returns></returns>
        public static bool Carpisma(Nokta nokta1, Nokta nokta2)
        {
            if (nokta1.X == nokta2.X &&
               nokta1.Y == nokta2.Y)
                return true;
            return false;
        }

        public static bool Carpisma(Nokta nokta, Cember cember)
        {
            if (yadrimciFun.arasinda(nokta.X,
                (int)(cember.oX() - cember.r),
                (int)(cember.oX() + cember.r)) &&
                yadrimciFun.arasinda(nokta.Y,
                (int)(cember.oY() - cember.r),
                (int)(cember.oY() + cember.r)))
                return true;

            return false;
        }
        public static bool Carpisma(Cember cember, Cember cember2)
        {
            //00 
            var arasindakiX = Math.Abs(cember2.oX() - cember.oX());
            var mesafi = cember.r + cember2.r;

            //00 
            var arasindakiY = Math.Abs(cember2.oY() - cember.oY());

            var arasi = Math.Sqrt(arasindakiY * arasindakiY + arasindakiX * arasindakiX);
            return arasi < mesafi;
        }


        public static bool Carpisma(Dikdortgen dik1, Dikdortgen dik2)
        {
            if (dik1.x > dik2.x)
            {
                var temp = dik2;
                dik2 = dik1;
                dik1 = temp;
            }
            var Xuzunluk = dik1.xUzunluk + dik2.xUzunluk;
            var Yuzunluk = dik1.yUzunluk + dik2.yUzunluk;

            var araskindakiX = dik2.X + dik2.xUzunluk - dik1.X;
            var araskindakiY = dik2.Y + dik2.yUzunluk - dik1.Y;

            return dik2.X < dik1.X + dik1.xUzunluk && dik2.Y < dik1.Y + dik1.yUzunluk;
            //  return Xuzunluk > araskindakiX && Yuzunluk > araskindakiY;
            // x + l/2 
        }




        public static bool Carpisma(Dikdortgen dik1, Cember cember)
        {

            var Xuzunluk = dik1.xUzunluk / 2 + cember.r;
            var Yuzunluk = dik1.yUzunluk / 2 + cember.r;

            var araskindakiX = Math.Abs(dik1.x - cember.x);
            var araskindakiY = Math.Abs(dik1.y - cember.y);

            return araskindakiX < Xuzunluk && araskindakiY < Yuzunluk;
        }

    }
}
