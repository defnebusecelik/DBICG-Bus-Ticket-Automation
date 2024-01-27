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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Bilgiler.GidisTarihi = dtpGidisTarihi.Value.Date;
            Bilgiler.DonusTarihi = dtpDonusTarihi.Value.Date;
            Bilgiler.NeredenSehir = (int)cmbNereden.SelectedValue;
            Bilgiler.NereyeSehir = (int)cmbNereye.SelectedValue;
            Bilgiler.RezerveMi = rdbRezervasyon.Checked;
            Bilgiler.SeyahatTipi = rdbGidisDonus.Checked ? SeyehatTipi.GidisDonus : SeyehatTipi.TekYon;

            if ((int)cmbNereden.SelectedValue == (int)cmbNereye.SelectedValue)
            {
                MessageBox.Show("Kalkış ve varış lokasyonları aynı olamaz!", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (rdbGidisDonus.Checked)
            {
                GidisDonus gd = new GidisDonus(this);
                gd.Show();
            }
            else
            {
                Gidis g = new Gidis(this);
                g.Show();
            }


            Hide();
        }
        private void btnPnrSorgula_Click_1(object sender, EventArgs e)
        {
            PNRSorgulamaEkrani pnr = new PNRSorgulamaEkrani();
            pnr.Show();
            Hide();
        }
    }
}
