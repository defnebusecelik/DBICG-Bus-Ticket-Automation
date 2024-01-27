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

namespace Ticket_Project
{
    public partial class Kullanıcı_İslemleri : Form
    {
        public Kullanıcı_İslemleri()
        {
            InitializeComponent();
        }
        private void düzenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bilet_Satın_Al ss = new Bilet_Satın_Al();
            ss.Show();
        }

        private void görünümToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bilet_İptal ss = new Bilet_İptal();
            ss.Show();
        }

        private void paragrafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bilet_Ara ss = new Bilet_Ara();
            ss.Show();
        }

        private void girisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giris ss = new Giris();
            ss.Show();
        }

        private void kapatToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}