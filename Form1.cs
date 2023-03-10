using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TEST_MATURA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            DateTime datum;
            if (Rodnecislo(text, out datum) == true)
            {
                label1.Text = datum.ToString();
            }
        }
        public bool Rodnecislo(string text, out DateTime datum)
        {
            bool je = true;
            datum = new DateTime();
            if (text.Length != 11)
            {
                throw new Exception("MUSI MIT 11 ZNAKU !");
            }
            if (text[6] != '/')
            {
                throw new Exception("MUSI BYT LOMITKO NA POICI 7 !");
            }
            try
            {
                string date = text[0] + text[1].ToString();
                int rok = Convert.ToInt32(date);
                try
                {
                    date = text[2] + text[3].ToString();
                    int mesic = Convert.ToInt32(date);
                    try
                    {
                        date = text[4] + text[5].ToString();
                        int den = Convert.ToInt32(date);
                        datum = new DateTime(rok, mesic, den);
                        text = text.Remove(6, 1);
                        long cislo = Convert.ToInt64(text);
                        if (cislo % 11 != 0)
                        {
                            throw new Exception("MUSI BYT DELITELNE11 !");
                        }
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("NENI PLATNE !");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("NENI PLATNE !");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("NENI PLATNE !");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("DATUM NEEXISTUJE !");
            }
            return true;
        }

        
    }
}
