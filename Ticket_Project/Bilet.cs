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
    public partial class Bilet : Form
    {
        public Bilet()
        {
            InitializeComponent();
        }
        public class idBilet
        {
            public static int id;
        }
        public class kolt
        {
            public static int kol;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            AnaSayfa frm = new AnaSayfa();
            frm.Show();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            Kullanici_Giris frm2 = new Kullanici_Giris();
            frm2.Show();
            Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void Bilet_Load(object sender, EventArgs e)
        {
            koltukKaldır();
            subeYukle();
        }
    }
}
