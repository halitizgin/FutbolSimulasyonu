using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;

namespace FutbolSimulasyonu
{
    public partial class Form2 : Form
    {
        public Form2(string takim1, string takim2)
        {
            InitializeComponent();
            gTakim1 = takim1;
            gTakim2 = takim2;
        }

        int macsuresi = 0;
        string gTakim1 = "";
        string gTakim2 = "";
        string[] pozisyonlar = { "sağ çapraz", "sol çapraz", "karşı karşıya", "boş kale", "gol", "aut", "kafa", "penaltı", "ofsayt", "kornerkafa" };
        string[] golpozisyonlari = { "penaltı", "frikik", "kafa", "korner kafa", "vole", "savunma arkasına", "karşı karşıya" };
        ArrayList aOyuncular1 = new ArrayList();
        ArrayList aOyuncular2 = new ArrayList();

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=takimlar.accdb");

        public void baglantiYap()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }

        bool ikinci = false;

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = gTakim1.Trim();
            textBox2.Text = gTakim2.Trim();
            baglantiYap();
            OleDbCommand komut1 = new OleDbCommand("SELECT * FROM takimlar WHERE takimadi='" + gTakim1 + "'", baglanti);
            OleDbDataReader okuyucu1 = komut1.ExecuteReader();
                      
            if (okuyucu1.Read())
            {
                string oyuncular1 = okuyucu1["oyunculari"].ToString();
                string[] dOyuncular1 = oyuncular1.Split('|');
                for (int i = 0; i < dOyuncular1.Length; i++)
                {
                    aOyuncular1.Add(dOyuncular1[i]);
                }
            }

            OleDbCommand komut2 = new OleDbCommand("SELECT * FROM takimlar WHERE takimadi='" + gTakim2 + "'", baglanti);
            OleDbDataReader okuyucu2 = komut2.ExecuteReader();

            if (okuyucu2.Read())
            {
                string oyuncular2 = okuyucu2["oyunculari"].ToString();
                string[] dOyuncular2 = oyuncular2.Split('|');
                for (int i = 0; i < dOyuncular2.Length; i++)
                {
                    aOyuncular2.Add(dOyuncular2[i]);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rast = new Random();
            int pozisyonolasiligi = rast.Next(0, 101);
            if (pozisyonolasiligi >= 0 && pozisyonolasiligi <= 70)
            {

            }
            else if (pozisyonolasiligi >= 71 && pozisyonolasiligi <= 100)
            {
                string pozisyontakim = "";
                int uretilecek = rast.Next(0, 101);
                if (uretilecek % 2 == 0)
                {
                    pozisyontakim = gTakim1;
                }
                else
                {
                    pozisyontakim = gTakim2;
                }
                int uretilecekoyuncu = 0;
                string uretilenoyuncu = "";
                if (pozisyontakim == gTakim1)
                {
                    uretilecekoyuncu = rast.Next(0, aOyuncular1.Count);
                    uretilenoyuncu = aOyuncular1[uretilecekoyuncu].ToString();
                    int uretilenpozisyon = rast.Next(0, pozisyonlar.Length);
                    string sUretilenpozisyon = pozisyonlar[uretilenpozisyon];
                    int uretilengol = -1;
                    string sUretilengol = null;
                    string pozisyonmetini = "";
                    switch (sUretilenpozisyon)
                    {
                        case "sağ çarpaz":
                            pozisyonmetini = "Ceza sahası sağ çaprazında topla buluşan " + uretilenoyuncu + " vuruşunu yapıyor ancak top dışarı gidiyor.";
                            break;
                        case "sol çapraz":
                            pozisyonmetini = "Ceza sahası sol çarpazında topla buluşan " + uretilenoyuncu + " vuruşunu yapıyor ancak top dışarı gidiyor.";
                            break;
                        case "karşı karşıya":
                            pozisyonmetini = "Karşı karşıya kalan " + uretilenoyuncu + " vuruşunu yapıyor ancak kaleci başarılı.";
                            break;
                        case "boş kale":
                            pozisyonmetini = "Bir anda boş kalan kaleye " + uretilenoyuncu + " vuruşunu yapıyor ancak top çerçeveyi bulmuyor.";
                            break;
                        case "gol":
                            uretilengol = rast.Next(0, golpozisyonlari.Length);
                            sUretilengol = golpozisyonlari[uretilengol];
                            int fark = -1;
                            if (int.Parse(skor1.Text) > int.Parse(skor2.Text))
                            {
                                fark = int.Parse(skor1.Text) - int.Parse(skor2.Text);
                            }
                            else if (int.Parse(skor2.Text) > int.Parse(skor1.Text))
                            {
                                fark = int.Parse(skor2.Text) - int.Parse(skor1.Text); 
                            }
                            else
                            {
                                fark = 0;
                            }
                                switch (sUretilengol)
                                {
                                    case "penaltı":
                                        if (pozisyontakim == gTakim1)
                                        {
                                            pozisyonmetini = "Hakem penaltı noktasını gösterdikten sonra topun başına geçen " + uretilenoyuncu + " vuruşunu yapıyor ve skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + "yapıyor.";
                                            skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                        }
                                        else if (pozisyontakim == gTakim2)
                                        {
                                            pozisyonmetini = "Hakem penaltı noktasını gösterdikten sonra topun başına geçen " + uretilenoyuncu + " vuruşunu yapıyor ve skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                            skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                        }
                                        break;
                                    case "frikik":
                                        if (pozisyontakim == gTakim1)
                                        {
                                            pozisyonmetini = "Kullanılan faulde frikiği kullanan " + uretilenoyuncu + " mükemmel bir vuruşla topu ağlara göndererek skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                            skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                        }
                                        else if (pozisyontakim == gTakim2)
                                        {
                                            pozisyonmetini = "Kullanılan faulde frikiği kullanan " + uretilenoyuncu + " mükemmel bir vuruşla topu ağlara göndererek skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                            skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                        }
                                        break;
                                    case "kafa":
                                        if (pozisyontakim == gTakim1)
                                        {
                                            pozisyonmetini = "Yapılan ortada kafayı vuran " + uretilenoyuncu + " mükemmel bir kafa vuruşuyla skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                            skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                        }
                                        else if (pozisyontakim == gTakim2)
                                        {
                                            pozisyonmetini = "Yapılan ortada kafayı vuran " + uretilenoyuncu + " mükemmel bir kafa vuruşuyla skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                            skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                        }
                                        break;
                                    case "korner kafa":
                                        if (pozisyontakim == gTakim1)
                                        {
                                            pozisyonmetini = "Kullanılan köşe vuruşunda kafayı vuran " + uretilenoyuncu + " vuruşunu kalecinin ulaşamayacağı köşeye gönderiyor ve skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                            skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                        }
                                        else if (pozisyontakim == gTakim2)
                                        {
                                            pozisyonmetini = "Kullanılan köşe vuruşunda kafayı vuran " + uretilenoyuncu + " vuruşunu kalecinin ulaşamayacağı köşeye gönderiyor ve skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                            skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                        }
                                        break;
                                    case "vole":
                                        if (pozisyontakim == gTakim1)
                                        {
                                            pozisyonmetini = "Çizgiyi inerek yapılan ortada voleyi vuran " + uretilenoyuncu + " topu doksana asarak skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                            skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                        }
                                        else if (pozisyontakim == gTakim2)
                                        {
                                            pozisyonmetini = "Çizgiyi inerek yapılan ortada voleyi vuran " + uretilenoyuncu + " topu doksana asarak skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                            skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                        }
                                        break;
                                    case "savunma arkasına":
                                        if (pozisyontakim == gTakim1)
                                        {
                                            pozisyonmetini = "Savunma arkasında çok iyi sarkan " + uretilenoyuncu + " düzgün bir vuruşla skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                            skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                        }
                                        else if (pozisyontakim == gTakim2)
                                        {
                                            pozisyonmetini = "Savunma arkasında çok iyi sarkan " + uretilenoyuncu + " düzgün bir vuruşla skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                            skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                        }
                                        break;
                                    case "karşı karşıya":
                                        if (pozisyontakim == gTakim1)
                                        {
                                            pozisyonmetini = "Çok iyi bir deparla karşı karşıya kalan " + uretilenoyuncu + " harika bir vuruşla skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                            skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                        }
                                        else if (pozisyontakim == gTakim2)
                                        {
                                            pozisyonmetini = "Çok iyi bir deparla karşı karşıya kalan " + uretilenoyuncu + " harika bir vuruşla skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                            skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                        }
                                        break;
                                }
                            break;
                        case "aut":
                            pozisyonmetini = "Ceza sahası dışından " + uretilenoyuncu + " çok sert vuruyor. Ancak top auta gidiyor.";
                            break;
                        case "kafa":
                            pozisyonmetini = "İçeri doğru yapılan ortada " + uretilenoyuncu + " kafayı vuruyor ancak top kalecide kalıyor.";
                            break;
                        case "kornerkafa":
                            pozisyonmetini = "Kullanılan köşe vuruşunda kale sahası içinde kafayı vuran " + uretilenoyuncu + " kaleyi bulamıyor.";
                            break;
                        case "penaltı":
                            pozisyonmetini = "Hakem beyaz noktayı gösterdikten sonra " + uretilenoyuncu + " vuruşunu yapıyor ancak kaleci penaltıyı kurtarıyor.";
                            break;
                        case "ofsayt":
                            pozisyonmetini = "Savunma arkasında sarkmaya çalışan " + uretilenoyuncu + " ofsayta yakalanıyor.";
                            break;
                    }

                    if (pozisyonmetini != "")
                    {
                        if (richTextBox1.Text != "")
                        {
                            richTextBox1.Text += "\n" + sure.Text + "\' " + pozisyonmetini;
                        }
                        else
                        {
                            richTextBox1.Text += sure.Text + "\' " + pozisyonmetini;
                        }
                    }
                }
                else if (pozisyontakim == gTakim2)
                {
                    uretilecekoyuncu = rast.Next(0, aOyuncular2.Count);
                    uretilenoyuncu = aOyuncular2[uretilecekoyuncu].ToString();
                    int uretilenpozisyon = rast.Next(0, pozisyonlar.Length);
                    string sUretilenpozisyon = pozisyonlar[uretilenpozisyon];
                    int uretilengol = -1;
                    string sUretilengol = null;
                    string pozisyonmetini = "";
                    switch (sUretilenpozisyon)
                    {
                        case "sağ çarpaz":
                            pozisyonmetini = "Ceza sahası sağ çaprazında topla buluşan " + uretilenoyuncu + " vuruşunu yapıyor ancak top dışarı gidiyor.";
                            break;
                        case "sol çapraz":
                            pozisyonmetini = "Ceza sahası sol çarpazında topla buluşan " + uretilenoyuncu + " vuruşunu yapıyor ancak top dışarı gidiyor.";
                            break;
                        case "karşı karşıya":
                            pozisyonmetini = "Karşı karşıya kalan " + uretilenoyuncu + " vuruşunu yapıyor ancak kaleci başarılı.";
                            break;
                        case "boş kale":
                            pozisyonmetini = "Bir anda boş kalan kaleye " + uretilenoyuncu + " vuruşunu yapıyor ancak top çerçeveyi bulmuyor.";
                            break;
                        case "gol":
                            uretilengol = rast.Next(0, golpozisyonlari.Length);
                            sUretilengol = golpozisyonlari[uretilengol];
                            int fark = -1;
                            if (int.Parse(skor1.Text) > int.Parse(skor2.Text))
                            {
                                fark = int.Parse(skor1.Text) - int.Parse(skor2.Text);
                            }
                            else if (int.Parse(skor2.Text) > int.Parse(skor1.Text))
                            {
                                fark = int.Parse(skor2.Text) - int.Parse(skor1.Text);
                            }
                            else
                            {
                                fark = 0;
                            }
                            switch (sUretilengol)
                            {
                                case "penaltı":
                                    if (pozisyontakim == gTakim1)
                                    {
                                        pozisyonmetini = "Hakem penaltı noktasını gösterdikten sonra topun başına geçen " + uretilenoyuncu + " vuruşunu yapıyor ve skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + "yapıyor.";
                                        skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                    }
                                    else if (pozisyontakim == gTakim2)
                                    {
                                        pozisyonmetini = "Hakem penaltı noktasını gösterdikten sonra topun başına geçen " + uretilenoyuncu + " vuruşunu yapıyor ve skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                        skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                    }
                                    break;
                                case "frikik":
                                    if (pozisyontakim == gTakim1)
                                    {
                                        pozisyonmetini = "Kullanılan faulde frikiği kullanan " + uretilenoyuncu + " mükemmel bir vuruşla topu ağlara göndererek skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                        skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                    }
                                    else if (pozisyontakim == gTakim2)
                                    {
                                        pozisyonmetini = "Kullanılan faulde frikiği kullanan " + uretilenoyuncu + " mükemmel bir vuruşla topu ağlara göndererek skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                        skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                    }
                                    break;
                                case "kafa":
                                    if (pozisyontakim == gTakim1)
                                    {
                                        pozisyonmetini = "Yapılan ortada kafayı vuran " + uretilenoyuncu + " mükemmel bir kafa vuruşuyla skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                        skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                    }
                                    else if (pozisyontakim == gTakim2)
                                    {
                                        pozisyonmetini = "Yapılan ortada kafayı vuran " + uretilenoyuncu + " mükemmel bir kafa vuruşuyla skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                        skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                    }
                                    break;
                                case "korner kafa":
                                    if (pozisyontakim == gTakim1)
                                    {
                                        pozisyonmetini = "Kullanılan köşe vuruşunda kafayı vuran " + uretilenoyuncu + " vuruşunu kalecinin ulaşamayacağı köşeye gönderiyor ve skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                        skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                    }
                                    else if (pozisyontakim == gTakim2)
                                    {
                                        pozisyonmetini = "Kullanılan köşe vuruşunda kafayı vuran " + uretilenoyuncu + " vuruşunu kalecinin ulaşamayacağı köşeye gönderiyor ve skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                        skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                    }
                                    break;
                                case "vole":
                                    if (pozisyontakim == gTakim1)
                                    {
                                        pozisyonmetini = "Çizgiyi inerek yapılan ortada voleyi vuran " + uretilenoyuncu + " topu doksana asarak skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                        skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                    }
                                    else if (pozisyontakim == gTakim2)
                                    {
                                        pozisyonmetini = "Çizgiyi inerek yapılan ortada voleyi vuran " + uretilenoyuncu + " topu doksana asarak skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                        skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                    }
                                    break;
                                case "savunma arkasına":
                                    if (pozisyontakim == gTakim1)
                                    {
                                        pozisyonmetini = "Savunma arkasında çok iyi sarkan " + uretilenoyuncu + " düzgün bir vuruşla skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                        skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                    }
                                    else if (pozisyontakim == gTakim2)
                                    {
                                        pozisyonmetini = "Savunma arkasında çok iyi sarkan " + uretilenoyuncu + " düzgün bir vuruşla skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                        skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                    }
                                    break;
                                case "karşı karşıya":
                                    if (pozisyontakim == gTakim1)
                                    {
                                        pozisyonmetini = "Çok iyi bir deparla karşı karşıya kalan " + uretilenoyuncu + " harika bir vuruşla skoru " + (int.Parse(skor1.Text) + 1) + " - " + int.Parse(skor2.Text) + " yapıyor.";
                                        skor1.Text = (int.Parse(skor1.Text) + 1).ToString();
                                    }
                                    else if (pozisyontakim == gTakim2)
                                    {
                                        pozisyonmetini = "Çok iyi bir deparla karşı karşıya kalan " + uretilenoyuncu + " harika bir vuruşla skoru " + int.Parse(skor1.Text) + " - " + (int.Parse(skor2.Text) + 1) + " yapıyor.";
                                        skor2.Text = (int.Parse(skor2.Text) + 1).ToString();
                                    }
                                    break;
                            }
                            break;
                        case "aut":
                            pozisyonmetini = "Ceza sahası dışından " + uretilenoyuncu + " çok sert vuruyor. Ancak top auta gidiyor.";
                            break;
                        case "kafa":
                            pozisyonmetini = "İçeri doğru yapılan ortada " + uretilenoyuncu + " kafayı vuruyor ancak top kalecide kalıyor.";
                            break;
                        case "kornerkafa":
                            pozisyonmetini = "Kullanılan köşe vuruşunda kale sahası içinde kafayı vuran " + uretilenoyuncu + " kaleyi bulamıyor.";
                            break;
                        case "penaltı":
                            pozisyonmetini = "Hakem beyaz noktayı gösterdikten sonra " + uretilenoyuncu + " vuruşunu yapıyor ancak kaleci penaltıyı kurtarıyor.";
                            break;
                        case "ofsayt":
                            pozisyonmetini = "Savunma arkasında sarkmaya çalışan " + uretilenoyuncu + " ofsayta yakalanıyor.";
                            break;
                    }

                    if (pozisyonmetini != "")
                    {
                        if (richTextBox1.Text != "")
                        {
                            richTextBox1.Text += "\n" + sure.Text + "\' " + pozisyonmetini;
                        }
                        else
                        {
                            richTextBox1.Text += sure.Text + "\' " + pozisyonmetini;
                        }
                    }
                }

            }

            if (macsuresi == 45 && ikinci == false)
            {
                richTextBox1.Text += "\n45' Hakem mücadelenin ilk yarısını bitiren düdüğünü çalıyor ve mücadelenin ilk yarısı " + skor1.Text + " - " + skor2.Text + " sona eriyor.";
                timer1.Stop();
                button1.Enabled = true;
                button1.Text = "Başlat";
            }
            else if (macsuresi == 90 && ikinci == true)
            {
                if (Convert.ToInt32(skor1.Text) > Convert.ToInt32(skor2.Text))
                {
                    richTextBox1.Text += "\n90' Hakem mücadelenin son düdüğünü çalıyor ve mücadele " + skor1.Text + " - " + skor2.Text + " " + textBox1.Text + " üstünlüğüyle sona eriyor.";
                    timer1.Stop();
                }
                else if (Convert.ToInt32(skor2.Text) > Convert.ToInt32(skor1.Text))
                {
                    richTextBox1.Text += "\n90' Hakem mücadelenin son düdüğünü çalıyor ve mücadele " + skor1.Text + " - " + skor2.Text + " " + textBox2.Text + " üstünlüğüyle sona eriyor.";
                    timer1.Stop();
                }
                else
                {
                    richTextBox1.Text += "\n90' Hakem mücadelenin son düdüğünü çalıyor ve mücadele " + skor1.Text + " - " + skor2.Text + " berabere sona eriyor.";
                    timer1.Stop();
                }
            }
            else
            {
                macsuresi++;
                sure.Text = macsuresi.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Başlat")
            {
                timer1.Start();
                ikinci = true;
                button1.Enabled = false;
            }
        }
    }
}
