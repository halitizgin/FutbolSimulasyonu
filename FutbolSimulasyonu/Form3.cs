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
    public partial class Form3 : Form
    {
        public Form3()
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "" && richTextBox1.Text.Trim() != "")
            {
                string final = "";
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    if (richTextBox1.Lines[i].Trim() != "")
                    {
                        if (i == richTextBox1.Lines.Length - 1)
                        {
                            final += richTextBox1.Lines[i].Trim();
                        }
                        else
                        {
                            final += richTextBox1.Lines[i].Trim() + "|";
                        }
                    }
                }
                baglantiYap();
                OleDbCommand komut = new OleDbCommand("INSERT INTO takimlar (takimadi, kaleci, oyunculari) VALUES ('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + final + "')", baglanti);
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("\"" + textBox1.Text.Trim() + "\" adlı takım başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int sayisi = richTextBox1.Lines.Length;
            label1.Text = sayisi + " adet oyuncu var.";
        }
    }
}
