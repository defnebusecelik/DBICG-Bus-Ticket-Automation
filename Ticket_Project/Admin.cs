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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sefer_İslemleri ss = new Sefer_İslemleri();
            ss.Show();
        }

        private void düzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rezervasyon_Listesi ss = new Rezervasyon_Listesi();
            ss.Show();
        }

        private void yeniÇalışanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personel_İslemleri ss = new Personel_İslemleri();
            ss.Show();
        }

        private void masrafDetaylarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masraf_İslemleri ss = new Masraf_İslemleri();
            ss.Show();
        }

        private void şehirVeŞubelerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aktif_Seferler ss = new Aktif_Seferler();
            ss.Show();
        }

        private void girişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giris ss = new Giris();
            ss.Show();
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}