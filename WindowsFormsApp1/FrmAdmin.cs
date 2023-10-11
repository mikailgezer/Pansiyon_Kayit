using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = label3.Text.Substring(1) + label3.Text.Substring(0, 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1 .Text == "Admin" && textBox2 .Text == "12345")
            {
                FrmKayitFrom fr = new FrmKayitFrom();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş yaptınız!!! Yeniden deneyiniz...");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
