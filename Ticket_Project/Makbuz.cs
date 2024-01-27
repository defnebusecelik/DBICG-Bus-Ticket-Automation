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
    
    public partial class Makbuz : Form
    {
 
        public Makbuz()
        {
            InitializeComponent();
        }

        private void print(Panel pnl)
        {
            panel1 = pnl;
            getprintarea(pnl);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private Bitmap memorying;
        private void getprintarea(Panel pnl)
        {
            memorying = new Bitmap(pnl.Width, pnl.Height);
            pnl.DrawToBitmap(memorying, new Rectangle(2, 2, pnl.Width, pnl.Height));
        }
        public string sou, des, firma, nm, em, mno;
        public TimeSpan b_bas, arrival;
        public int price , sno;
        public DateTime tarih;

        private void lblnm_Click(object sender, EventArgs e)
        {

        }

        private void lblat_Click(object sender, EventArgs e)
        {

        }

        private void lblbno_Click(object sender, EventArgs e)
        {

        }

        private void lblsou_Click(object sender, EventArgs e)
        {

        }

        private void lbldes_Click(object sender, EventArgs e)
        {

        }

        private void lblbt_Click(object sender, EventArgs e)
        {

        }

        private void lblseat_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void labeldate_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void lblemail_Click(object sender, EventArgs e)
        {

        }

        private void lblmobile_Click(object sender, EventArgs e)
        {

        }

        private void lblage_Click(object sender, EventArgs e)
        {

        }

        private void lblgender_Click(object sender, EventArgs e)
        {

        }

        private void lblprice_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanıcı_İslemleri ss = new Kullanıcı_İslemleri();
            ss.Show();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Rectangle pagearea = e.PageBounds;
            int x = (pagearea.Width - this.panel1.Width) / 2;
            int y = this.panel1.Location.Y;

            e.Graphics.DrawImage(memorying, new Point(x, y));
        }

        private void bunifuImageButton1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(bunifuImageButton1, "print");
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            print(this.panel1);
        }

        public Image img = null;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            labeldate.Text = tarih.ToString("dd/MM/yyyy");
            lblseat.Text = sno.ToString();
            lblsou.Text = sou;
            lbldes.Text = des;
            lblbt.Text = firma;
            label6.Text = b_bas.ToString("hh\\:mm");
            lblat.Text = arrival.ToString("hh\\:mm");
            lblnm.Text = nm;
            lblemail.Text = em;
            lblmobile.Text = mno;
            lblprice.Text = price.ToString();
        }
    }
}