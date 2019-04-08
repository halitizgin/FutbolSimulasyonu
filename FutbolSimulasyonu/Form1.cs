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

namespace FutbolSimulasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=takimlar.accdb");

        public void baglantiYap()
        {
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
        }

        public void yenile()
        {
            baglantiYap();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM takimlar", baglanti);
            OleDbDataReader okuyucu = komut.ExecuteReader();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            while (okuyucu.Read())
            {
                comboBox1.Items.Add(okuyucu["takimadi"].ToString());
                comboBox2.Items.Add(okuyucu["takimadi"].ToString());
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != comboBox2.Text && comboBox1.Text != "" && comboBox2.Text != "")
            {
                Form2 form2 = new Form2(comboBox1.Text, comboBox2.Text);
                form2.ShowDialog();
            }
        }
    }
}
