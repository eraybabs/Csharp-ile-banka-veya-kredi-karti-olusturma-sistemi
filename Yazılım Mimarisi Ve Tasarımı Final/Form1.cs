using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KartOlustur
{

    public interface IKart
    {
        string KartTip();
        int KartLimit { get; set; }
        string KartNo { get; set; }
        int KartYil { get; set; }
        int KartAy { get; set; }
        string KartAd { get; set; }
        string KartSoyad { get; set; }
        int KartCvv { get; set; }

    }



    public class MasterCard : IKart
    {
        //degisken tanımlamaları
        private string kartno;
        private int kartay;
        private int kartlimit;
        private int kartyil;
        private int kartcvv;
        private string kartad;
        private string kartsoyad;

        //kart numarası olusturma 
        public string KartNo
        {
            get
            {
                return kartno;
            }
            set
            {
                Random random = new Random();
                string Ondorthane = "";
                for (int i = 0; i < 14; i++)
                {
                    Ondorthane += Convert.ToString(random.Next(0, 10));
                }
                kartno = "5" + Convert.ToString(random.Next(1, 6)) + Convert.ToString(random.Next(0, 10)) + Ondorthane;
                kartno = value;
            }
        }

        public int KartLimit
        {
            get
            {
                return kartlimit;
            }

            set
            {
                kartlimit = 5000;
                kartlimit = value;
            }
        }


        public int KartCvv
        {

            get
            {
                return kartcvv;
            }
            set
            {
                Random random = new Random();
                string cvv = "";
                for (int i = 0; i < 3; i++)
                {
                    cvv += Convert.ToString(random.Next(0, 10));
                }
                kartcvv = Convert.ToInt32(cvv);
                kartcvv = value;
            }
        }
        public int KartAy
        {
            get
            {
                return kartay;
            }

            set
            {
                string ay = DateTime.Now.Month.ToString();
                kartay = Convert.ToInt32(ay);
                kartay = value;
            }

        }
        public string KartAd { get; set; }
        public string KartSoyad { get; set; }
        public int KartYil
        {
            get
            {
                return kartyil;
            }
            set
            {
                int yil = DateTime.Now.Year + 5;
                kartyil = yil;
                kartyil = value;
            }
        }
        public string KartTip()
        {
            return "mastercard";
        }


    }


    public abstract class KartFabrikasi
    {
        protected abstract IKart KartOlustur();
        public IKart UrunOlustur()
        {
            return this.KartOlustur();
        }
    }

    public class MasterCardFabrikasi : KartFabrikasi
    {
        protected override IKart KartOlustur()
        {
            IKart product = new MasterCard();
            return product;
        }
    }


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            IKart creditCard = new MasterCardFabrikasi().UrunOlustur();

            MessageBox.Show("Card Type : " + creditCard.KartTip());
        }
    }
}
