using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.Drawing;

namespace Ticket_Project
{
    public partial class Aktif_Seferler : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne";

        public Aktif_Seferler()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin ss = new Admin();
            ss.Show();
        }

        private void ShowTrips()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT tripID, busID, tSource, tDestination, tDate, sTime, dTime, price, companyName FROM Trip WHERE tDate >= CURRENT_DATE", con))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
        }

        private void Aktif_Seferler_Load(object sender, EventArgs e)
        {
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);

            ShowTrips();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
            }
        }
    }
}