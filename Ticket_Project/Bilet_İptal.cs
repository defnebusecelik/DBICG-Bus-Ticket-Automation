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
using Npgsql;

namespace Ticket_Project
{
    public partial class Bilet_İptal : Form
    {
        private int[] tempbookseat;

        public Bilet_İptal()
        {
            InitializeComponent();
            tempbookseat = new int[29];
            temp();
        }

        private void temp()
        {
            string connectionString = "Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne";

            using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
            {
                con.Open();

                for (int i = 0; i < 29; i++)
                {
                    if (tempbookseat[i] == 1)
                    {
                        string updateData = $"UPDATE Seat SET status='A' WHERE numberOfSeats = {i + 1}";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(updateData, con))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox2.Text = "";
                return;
            
            }

            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=defne;Database=Bus_Project"))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT passengerID,tripID,pName,pLastName,gender,pTel,pMail,tSource,tDestination,tDate,sTime,dTime,price,companyName,seatNumber,cardNumber,cardName,cardCsv,cardDate,cardtype FROM Passenger WHERE pLastName='" + textBox1.Text + "' AND pMail='" + textBox2.Text + "'", con))
                    {
                        NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            bunifuDataGridView1.DataSource = dt;
                        }
                        else
                        {
                            MessageBox.Show("Veriye bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                OleDbConnection con = new OleDbConnection("server=localHost;Port=5432;Database=Bus_Project;user ID=postgres;password=defne");
                con.Open();
                int studno = Convert.ToInt16(bunifuDataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                DialogResult res;
                res = MessageBox.Show("Bileti iptal etmek istediğinize emin misiniz ?", "Kaydı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand("delete from Passenger where pMail=" + studno + "", con);
                    int ans = cmd.ExecuteNonQuery();
                    temp();
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcı_İslemleri ss = new Kullanıcı_İslemleri();
            ss.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text))
            {
                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=defne;Database=Bus_Project"))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Passenger WHERE pLastName=@pLastName AND pMail=@pMail", con))
                    {
                        cmd.Parameters.AddWithValue("@pLastName", textBox1.Text);
                        cmd.Parameters.AddWithValue("@pMail", textBox2.Text);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int passengerID = Convert.ToInt32(reader["passengerID"]);
                                reader.Close();

                                DialogResult result = MessageBox.Show("Bileti iptal etmek istediğinize emin misiniz ?", "Kaydı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    using (NpgsqlCommand deleteCmd = new NpgsqlCommand("DELETE FROM Passenger WHERE passengerID = @passengerID", con))
                                    {
                                        deleteCmd.Parameters.AddWithValue("@passengerID", passengerID);

                                        int affectedRows = deleteCmd.ExecuteNonQuery();

                                        if (affectedRows > 0)
                                        {
                                            MessageBox.Show("Bilet Başarıyla İptal Edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            // Clear the DataGridView
                                            bunifuDataGridView1.DataSource = null;
                                        }
                                        else
                                        {
                                            MessageBox.Show("Bilet İptal Edilemedi.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }

                            else
                            {
                                MessageBox.Show("Eşleşen kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox1.Text = "";
                                textBox2.Text = "";
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen her iki metin kutusuna da değerleri girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Text = "";
                textBox2.Text = "";
            }
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

        private void Bilet_İptal_Load(object sender, EventArgs e)
        {
            bunifuDataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(bunifuDataGridView1_RowPrePaint);
        }
    }
}