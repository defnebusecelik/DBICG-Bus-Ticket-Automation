using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticket_Project
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Kullanici_Giris frm = new Kullanici_Giris();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bilet frm = new Bilet();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sefer_Bilgileri frm = new Sefer_Bilgileri();
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Rapor_Ekle frm = new Rapor_Ekle();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Otobus_Bilgileri frm = new Otobus_Bilgileri();
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sube_Bilgileri frm = new Sube_Bilgileri();
            frm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Personel_Bilgileri frm = new Personel_Bilgileri();
            frm.Show();
        }

 
    }
}
