using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class FrmKayitFrom : Form
    {
        public FrmKayitFrom()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-71FJKJN;Initial Catalog=pansiyon ;Integrated Security=True");

        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From müsteriler", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From bosoda", baglanti);
            SqlDataReader  oda = komut.ExecuteReader();

            while (oda.Read())
            {
                comboBox1.Items.Add(oda[0].ToString());
            }
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand ("insert into müsteriler (id, Ad, Soyad, OdaNo, GTarih, Telefon, Hesap, CTarih) values ('"+ textBox1 .Text .ToString ()+ "','"+ textBox2 .Text .ToString ()+ "','" +textBox3 .Text .ToString ()+ "','" + comboBox1  .Text .ToString ()+ "','" +dateTimePicker1 .Text .ToString ()+ "','"+ textBox5 .Text .ToString ()+ "','" +textBox6 .Text .ToString ()+ "','" +dateTimePicker2 .Text .ToString ()+ "')",baglanti);
            komut.ExecuteNonQuery();

            komut.CommandText = "insert into doluoda(doluyerler) values ('" + comboBox1.Text + "')";
            komut.ExecuteNonQuery();
            komut.CommandText = ("Delete from bosoda where bosyerler='" + comboBox1.Text + "'");
            komut.ExecuteNonQuery();



            switch (comboBox1 .Text )
            {
                case "1         ":   
                    btn_oda1.BackColor = Color.Red;  
                    break;
                case "2         ":
                    btn_oda2.BackColor = Color.Red;
                    break;
                case "3         ":
                    btn_oda3.BackColor = Color.Red;
                    break;
                case "4         ":
                    btn_oda4.BackColor = Color.Red;
                    break;
                case "5         ":
                    btn_oda5.BackColor = Color.Red;
                    break;
                case "6         ":
                    btn_oda6.BackColor = Color.Red;
                    break;

            }

            baglanti.Close();
            verilerigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        int id = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From müsteriler where id= (" + id + ")", baglanti);
            komut.ExecuteNonQuery();

            komut.CommandText = "insert into bosoda(bosyerler) values ('" + comboBox1.Text + "')";
            komut.ExecuteNonQuery();
            komut.CommandText = ("Delete from doluoda where doluyerler='" + comboBox1.Text + "'");
            komut.ExecuteNonQuery();

            switch (comboBox1.Text)
            {
                case "1         ":
                    btn_oda1.BackColor = Color.Green ;
                    break;
                case "2         ":
                    btn_oda2.BackColor = Color.Green ;
                    break;
                case "3         ":
                    btn_oda3.BackColor = Color.Green ;
                    break;
                case "4         ":
                    btn_oda4.BackColor = Color.Green ;
                    break;
                case "5         ":
                    btn_oda5.BackColor = Color.Green ;
                    break;
                case "6         ":
                    btn_oda6.BackColor = Color.Green ;
                    break;

            }

            baglanti.Close();
            verilerigöster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1 .Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1 .Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update müsteriler set id='" + textBox1.Text.ToString() + "',Ad='" + textBox2.Text.ToString() + "',Soyad='" + textBox3.Text.ToString() + "',OdaNo='" + comboBox1 .Text.ToString() + "',GTarih='" + dateTimePicker1.Text.ToString() + "',Telefon='" + textBox5.Text.ToString() + "',Hesap='" + textBox6.Text.ToString() + "',CTarih='" + dateTimePicker2.Text.ToString() + "' where id = " +id+ "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From müsteriler where Ad like '%" +textBox7 .Text + "%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["OdaNo"].ToString());
                ekle.SubItems.Add(oku["GTarih"].ToString());
                ekle.SubItems.Add(oku["Telefon"].ToString());
                ekle.SubItems.Add(oku["Hesap"].ToString());
                ekle.SubItems.Add(oku["CTarih"].ToString());

                listView1.Items.Add(ekle);
            }
            baglanti.Close();

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void FrmKayitFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Text = label10.Text.Substring(1) + label10.Text.Substring(0, 1);
        }
    }
}
