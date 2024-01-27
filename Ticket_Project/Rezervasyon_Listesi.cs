using Npgsql;
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace Ticket_Project
{
    public partial class Rezervasyon_Listesi : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne";

        public Rezervasyon_Listesi()
        {
            InitializeComponent();
        }
        private void ShowPassengers()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT passengerID,tripID,pName,pLastName,gender,pTel,pMail,tSource,tDestination,tDate,sTime,dTime,price,companyName,seatNumber FROM Passenger", con))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        bunifuDataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin ss = new Admin();
            ss.Show();
        }

        private void Rezervasyon_Listesi_Load(object sender, EventArgs e)
        {
            bunifuDataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(bunifuDataGridView1_RowPrePaint);

            ShowPassengers();
        }

        private void bunifuDataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Çift sıra: Arkaplan rengini değiştir
                bunifuDataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
            }
            else
            {
                // Tek sıra: Varsayılan arkaplan rengini kullan
                bunifuDataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = bunifuDataGridView1.DefaultCellStyle.BackColor;
            }
        }
    }
}