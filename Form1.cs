using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nurettinyilmazfinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String[] dugum_degerleri;
        int[,] dugum_iliski_matrisi;
        String[] dugum_iliski_matrisi_satir;
        private void Form1_Load(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("data1.txt");
            String line = sr.ReadToEnd();
            dugum_degerleri = line.Split(' ');
            dugum_iliski_matrisi = new int[dugum_degerleri.Length, dugum_degerleri.Length];
            sr = new StreamReader("data2.txt");
            String satirlar = sr.ReadToEnd();
            dugum_iliski_matrisi_satir = satirlar.Split('\n');
            for (int i = 0; i < dugum_degerleri.Length; i++)
            {
                String[] satir_elemanlar = dugum_iliski_matrisi_satir[i].Split(' ');
                for (int j = 0; j < dugum_degerleri.Length; j++)
                {
                    if (satir_elemanlar[j] == "0")
                        dugum_iliski_matrisi[i, j] = 0;
                    else
                        dugum_iliski_matrisi[i, j] = 1;
                }
            }
            dugumPuanHesapla();
        }
        
        void dugumPuanHesapla()
        {
            
            for (int i = 0; i < dugum_degerleri.Length; i++)
            {
                hesaplananDugum = new bool[dugum_degerleri.Length];
                dugumpuan = Convert.ToInt32(dugum_degerleri[i]);
                for (int j = 0; j < dugum_degerleri.Length; j++)
                {
                    if (dugum_iliski_matrisi[i, j] == 1)
                    {
                        birSonrakiDugum(j);
                    }
                }
                textBox1.Text += dugumpuan.ToString()+" ";
                
            }
        }
        int dugumpuan = 0;
        bool[] hesaplananDugum;
        void birSonrakiDugum(int index)
        {
            if (hesaplananDugum[index] == false)
            {
                dugumpuan += Convert.ToInt32(dugum_degerleri[index]);
                hesaplananDugum[index] = true;
            }
            for (int i = 0; i < dugum_degerleri.Length; i++)
            {
                if (dugum_iliski_matrisi[index, i] == 1)
                {
                    birSonrakiDugum(i);
                }
            }
        }
    }
}
