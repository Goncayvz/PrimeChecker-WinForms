using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gp_ödev_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        void asal(int sayi)
        {
            if(sayi<=1)
            {
                listBox1.Items.Add(sayi + "asal değildir.");
                return;

            }
            for(int i = 2; i <= Math.Sqrt(sayi); i++)
            {
                if (sayi % i == 0)
                {
                    listBox1.Items.Add(sayi + "asal değildir.");
                    return;
                }
            }
            listBox1.Items.Add(sayi + "asal sayıdır.");
        }

        void asal(int bas,int son)
        {
            listBox1.Items.Clear();
            for(int i = bas; i <= son; i++)
            {
                asal(i);
            }
        }
        void asal(params int[] sayilar)
        {
            listBox1.Items.Clear();
            foreach(int sayi in sayilar)
            {
                asal(sayi);
            }
        }
        void asalRekürsif(int bas,int  son)
        {
            if (bas > son)
            {
                return;
            }
            asal(bas);
            asalRekürsif(bas + 1,son);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int sayi;
            int bas, son;
            if (int.TryParse(textBox1.Text, out sayi)) 
            {
                asal(sayi);
            }
            if(int.TryParse(textBox1.Text,out bas) && int.TryParse(textBox2.Text,out son))
            {
                asal(bas,son);
            }
             if(int.TryParse(textBox1.Text,out int r_sayi) && r_sayi > 0)
            {
                Random rnd=new Random();
                int[] sayilar = new int[r_sayi];
                 
                for(int i = 0; i < r_sayi; i++)
                {
                    sayilar[i] = rnd.Next(1, 101);
                }
                asal(sayilar);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int bas, son;
            if(int.TryParse(textBox1.Text,out bas) && int.TryParse(textBox2.Text,out son))
            {
                asalRekürsif(bas,son);
            }
        }
    }
}