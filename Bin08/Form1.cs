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

namespace Bin08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"..\..\Soubory\VyskyVeTtride.dat", FileMode.Create);
        
            fs.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            FileStream fs = new FileStream(@"..\..\Soubory\VyskyVeTtride.dat", FileMode.Open, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            string jmeno = textBox1.Text;
            int vyska = int.Parse(textBox2.Text);
            fs.Seek(0, SeekOrigin.End);
            bw.Write(jmeno);
            bw.Write(vyska);       
            fs.Close();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream fs = new FileStream(@"..\..\Soubory\VyskyVeTtride.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
          
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                
                string jmeno = br.ReadString();
                int vyska = br.ReadInt32();
                listBox1.Items.Add(jmeno + " vyska: " + vyska + " cm");


            }
            fs.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double max = double.MinValue;
            double min = double.MaxValue;
            double soucet = 0;
            double pocet = 0;


            FileStream fs = new FileStream(@"..\..\Soubory\VyskyVeTtride.dat", FileMode.Open, FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.Default);
            while (br.BaseStream.Position < br.BaseStream.Length)
            {
                string jmeno = br.ReadString();
                double vyska = br.ReadI();
                if (vyska > max) max = vyska;
                else if (vyska < min) min = vyska;
                soucet += vyska;
                ++pocet;
            }
            fs.Close();

            double prumer = soucet / pocet;

            label1.Text = prumer.ToString();
            label2.Text = max.ToString();
            label3.Text = min.ToString();
        }
    }
}
