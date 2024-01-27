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
    public partial class Baslangic : Form
    {
        private Timer timer;
        private int progressValue = 0;
        private const int totalSteps = 100;
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += timer1_Tick;
        }
        public Baslangic()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressValue = progressValue+2;
            circularProgressBar1.Value = progressValue;

            if (progressValue >= totalSteps)
            {
                timer.Stop();
                Giris ss = new Giris();
                ss.Show();
            }
        }

        private void Yukleme_Sayfasi_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}