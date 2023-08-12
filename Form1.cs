using geometrik.Arayuz;
using geometrik.Sekiller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace geometrik
{
    public partial class Form1 : Form
    {

        int xUzunluk, yUzunluk;

        // pointer (mouse)
        Point Fare = new Point(0, 0);

        // cezgi . 
        bool cizer_mu = false;
        bool cizer_biti_mu = false;

        Point cizer_basla_noktasi = new Point(0, 0);
        Point cizer_bitis_noktasi = new Point(0, 0);


        List<object> CizmisCekiller = new List<object>();
        Point[] RessamNoktalar = new Point[4];
        // object[] CizmisCekiller = new object[6];





        #region start 
        public Form1()
        {
            InitializeComponent();
            new Ressam();
            Ressam.Kure = Properties.Resources.sphere;
            Ressam.Silinder = Properties.Resources.cylinder;
            Ressam.Prizme = Properties.Resources.rectangular;

        }

        #endregion  











        #region events
        private void Cizim_Tahtasi_MouseDown(object sender, MouseEventArgs e)
        {
            // MessageBox.Show((e.X).ToString());

            cizer_basla_noktasi.X = e.X;
            cizer_basla_noktasi.Y = (e.Y);
            cizer_mu = true;
        }
        int i = 0;
        private void Cizim_Tahtasi_MouseUp(object sender, MouseEventArgs e)
        {
            if (!active)
            {
                RessamNoktalar[i] = (new Point(e.X, e.Y));
                i++;
                if (i == 4) active = true;
                else return;
            }
            cizer_bitis_noktasi.X = e.X;
            cizer_bitis_noktasi.Y = (e.Y);

            xUzunluk = Math.Abs(cizer_bitis_noktasi.X - cizer_basla_noktasi.X);
            yUzunluk = Math.Abs(cizer_bitis_noktasi.Y - cizer_basla_noktasi.Y);

            cizer_biti_mu = true;


            if (cizer_mu && cizer_biti_mu && active)
            {
                cizer_biti_mu = false;
                cizer_mu = false;
                ciziyor();
            }

        }
        /// <summary>
        /// bu Polgon isin... ise polygon active = false. 
        /// </summary>
        bool active = true;
        private void Cizim_Tahtasi_MouseMove(object sender, MouseEventArgs e)
        {
            Fare.X = e.X;
            Fare.Y = e.Y;
            gorsterHali();
        }

        #endregion events





        #region Cekiller Ciz

        Nokta CizNokta()
        {

            var nokta = new Nokta();
            nokta.graphics = ciz();
            nokta.hacmi = (xUzunluk + yUzunluk) / 2;
            nokta.X = cizer_basla_noktasi.X;
            nokta.Y = cizer_basla_noktasi.Y;

            nokta.Ciz();
            return nokta;
        }
        Cember CizCember()
        {

            var daire = new Cember();
            daire.graphics = ciz();
            daire.r = (float)(Math.Sqrt(xUzunluk * xUzunluk + yUzunluk * yUzunluk) / 2);
            daire.X = cizer_basla_noktasi.X;
            daire.Y = cizer_basla_noktasi.Y;

            daire.Ciz();
            return daire;
        }
        Dikdortgen CizDikdortgen()
        {
            var xUzunluk = Math.Abs(cizer_bitis_noktasi.X - cizer_basla_noktasi.X);
            var yUzunluk = Math.Abs(cizer_bitis_noktasi.Y - cizer_basla_noktasi.Y);


            var dik = new Dikdortgen();
            if (cizer_basla_noktasi.X > cizer_bitis_noktasi.X && cizer_basla_noktasi.Y > cizer_bitis_noktasi.Y)
            {
                dik.X = cizer_bitis_noktasi.X;
                dik.Y = cizer_bitis_noktasi.Y;
            }
            else
            {
                dik.X = cizer_basla_noktasi.X;
                dik.Y = cizer_basla_noktasi.Y;
            }
            dik.xUzunluk = xUzunluk;
            dik.yUzunluk = yUzunluk;

            dik.Ciz(ciz());
            return dik;
        }
        Polygon CizPolygon()
        {
            i = 0; active = false;
            var polygon = new Polygon();
            polygon.graphics = ciz();
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            int len = RessamNoktalar.Length;
            Point[] Points = { RessamNoktalar[len-1],
                RessamNoktalar[len-2],
                RessamNoktalar[len-3],
                RessamNoktalar[len-4],
            };
            polygon.Noktalar = Points;

            // Draw polygon to screen.
            polygon.Ciz();
            return polygon;
        }
        Kure CizKure()
        {
            Kure kure = new Kure
            {
                graphics = ciz(),
                X = cizer_basla_noktasi.X,
                Y = cizer_basla_noktasi.Y,
                r = (float)(Math.Sqrt(xUzunluk * xUzunluk + yUzunluk * yUzunluk) / 2)
            };
            kure.Ciz();
            return kure;
        }



        Prizma CizPrizma()
        {
            var xUzunluk = Math.Abs(cizer_bitis_noktasi.X - cizer_basla_noktasi.X);
            var yUzunluk = Math.Abs(cizer_bitis_noktasi.Y - cizer_basla_noktasi.Y);


            var prizma = new Prizma();
            if (cizer_basla_noktasi.X > cizer_bitis_noktasi.X && cizer_basla_noktasi.Y > cizer_bitis_noktasi.Y)
            {
                prizma.X = cizer_bitis_noktasi.X;
                prizma.Y = cizer_bitis_noktasi.Y;
            }
            else
            {
                prizma.X = cizer_basla_noktasi.X;
                prizma.Y = cizer_basla_noktasi.Y;
            }
            prizma.zUzunluk = (Fare.X + Fare.Y) / 2;
            prizma.xUzunluk = xUzunluk;
            prizma.yUzunluk = yUzunluk;
            prizma.graphics = ciz();

            prizma.Ciz();
            return prizma;
        }
        Silindir CizSilinder()
        {
            var xUzunluk = Math.Abs(cizer_bitis_noktasi.X - cizer_basla_noktasi.X);
            var yUzunluk = Math.Abs(cizer_bitis_noktasi.Y - cizer_basla_noktasi.Y);


            var silinder = new Silindir();
            if (cizer_basla_noktasi.X > cizer_bitis_noktasi.X && cizer_basla_noktasi.Y > cizer_bitis_noktasi.Y)
            {
                silinder.X = cizer_bitis_noktasi.X;
                silinder.Y = cizer_bitis_noktasi.Y;
            }
            else
            {
                silinder.X = cizer_basla_noktasi.X;
                silinder.Y = cizer_basla_noktasi.Y;
            }
            silinder.xUzunluk = xUzunluk;
            silinder.yUzunluk = yUzunluk;

            silinder.Z = Fare.X / 8;

            silinder.graphics = ciz();

            silinder.Ciz();
            return silinder;
        }
        #endregion



        void ciziyor()
        {

            switch (sekil)
            {
                case Cember.Ismi:
                    {
                        CizmisCekiller.Add(CizCember());
                        break;
                    }
                case Dikdortgen.Ismi:
                    {
                        CizmisCekiller.Add(CizDikdortgen());
                        break;
                    }
                case Polygon.Ismi:
                    {
                        CizmisCekiller.Add(CizPolygon());
                        break;
                    }
                case Nokta.Ismi:
                    {
                        CizmisCekiller.Add(CizNokta());
                        break;
                    }
                case Kure.Ismi:
                    {
                        CizmisCekiller.Add(CizKure());
                        break;
                    }
                case Silindir.Ismi:
                    {
                        CizmisCekiller.Add(CizSilinder());
                        break;
                    }
                case Prizma.Ismi:
                    {
                        CizmisCekiller.Add(CizPrizma());
                        break;
                    }


            }

            int len = CizmisCekiller.Count - 1;
            if (len < 1) return;
            bool CarpismaMu = Sekil.GetCarpisma(CizmisCekiller[len - 1], CizmisCekiller[len]);
            GosterCarpisi(CarpismaMu);
        }








        #region اختيار الشكل للرسم 
        string sekil;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            sekil = Sekiller.Polygon.Ismi;
            active = false;
            i = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            sekil = Sekiller.Cember.Ismi;
            active = true;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sekil = Sekiller.Dikdortgen.Ismi;
            active = true;

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            sekil = Sekiller.Nokta.Ismi;
            active = true;

        }
        public Image Kure_foto;
        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            sekil = Sekiller.Kure.Ismi;
            active = true;

        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            sekil = Sekiller.Silindir.Ismi;
            active = true;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Ressam.boy = trackBar1.Value;
            label1.Text = Ressam.boy.ToString();
        }
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            sekil = Sekiller.Prizma.Ismi;
            active = true;
        }

        #endregion




        Graphics ciz()
        {
            return Cizim_Tahtasi.CreateGraphics();
        }


        private void YeniRengi(object sender, EventArgs e)
        {
            Ressam.rengi = ((Button)sender).BackColor;
            label1.Text = Ressam.boy.ToString();
        }



        void gorsterHali()
        {
            Tfare.Text = Fare.ToString();
            TcizirBasla.Text = cizer_basla_noktasi.ToString();
            TcizirSon.Text = cizer_bitis_noktasi.ToString();
        }

        void GosterCarpisi(bool mu = false)
        {
            if (mu)
            {
                pictureBox7.Image = Properties.Resources.warning;
                int len = CizmisCekiller.Count() - 1;
                Thali.ForeColor = Color.MediumVioletRed;
                Thali.Text = $"{CizmisCekiller[len].GetType().Name} ve {CizmisCekiller[len - 1].GetType().Name}" +
                    $" birlikte kesişmek";
            }
            else
            {
                pictureBox7.Image = Properties.Resources.accept;
                int len = RessamNoktalar.Count() - 1;
                Thali.ForeColor = Color.DarkOliveGreen;
                Thali.Text = $"çarpışma yok";
            }
        }



    }
}
