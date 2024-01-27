using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using Npgsql;
using System.Drawing;
namespace Ticket_Project
{
    public partial class Sefer_İslemleri : Form
    {
        public Sefer_İslemleri()
        {
            InitializeComponent();
        }
        NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne");

        private void pop()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT tripID, busID, tSource, tDestination, tDate, sTime, dTime, price,companyName,totalSeat FROM Trip", con))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        bunifuDataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtsr.Text == "" || txtd.Text == "" || txtarrival.Text == "" || txtp.Text == "" || txtbas.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz", "Eklenmiyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtsr.Text = "";
                txtd.Text = "";
                txtarrival.Text = "";
                txtp.Text = "";
                txtbas.Text = "";
                bunifuDataGridView1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox10.Text = "";
                return;
            }
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string query = "INSERT INTO Trip(tripID, busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat,companyName) VALUES(@tripID, @busID, @tSource, @tDestination, @tDate, @sTime, @dTime, @price,@totalSeat,@companyName)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tripID", textBox1.Text);
                cmd.Parameters.AddWithValue("@busID", textBox2.Text);
                cmd.Parameters.AddWithValue("@tSource", txtsr.Text);
                cmd.Parameters.AddWithValue("@tDestination", txtd.Text);
                cmd.Parameters.AddWithValue("@tDate", bunifuDatePicker1.Value);
                cmd.Parameters.AddWithValue("@sTime", TimeSpan.Parse(txtbas.Text));
                cmd.Parameters.AddWithValue("@dTime", TimeSpan.Parse(txtarrival.Text));
                cmd.Parameters.AddWithValue("@price", int.Parse(txtp.Text));
                cmd.Parameters.AddWithValue("@companyName", textBox3.Text);
                cmd.Parameters.AddWithValue("@totalSeat", int.Parse(textBox10.Text));

          

                cmd.ExecuteNonQuery();
                MessageBox.Show("Sefer Başarıyla Eklendi");
                UpdateDataGridView();

                reset();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
            // Update the DataGridView         
        }

        private void UpdateDataGridView()
        {
            // Assuming pop() method is used to populate the DataGridView
            pop();
        }

        private void reset()
        {
            txtsr.Text = "";
            txtd.Text = "";
            txtarrival.Text = "";
            txtp.Text = "";
            txtbas.Text = "";
            bunifuDataGridView1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox10.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Admin ss = new Admin();
            ss.Show();
        }

        private void Otobüs_Ekle_Load(object sender, EventArgs e)
        {



            bunifuDataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(bunifuDataGridView1_RowPrePaint);

            pop();
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void bunifuDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == bunifuDataGridView1.Columns["tripID"].Index)
            {
                // Eğer "tripID" sütununa tıklandıysa
                DataGridViewRow row = bunifuDataGridView1.Rows[e.RowIndex];
                string tripID = row.Cells["tripID"].Value.ToString();

                // Silme işlemi için fonksiyonu çağrılarak satır silinsin
                DeleteTrip(tripID);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (bunifuDataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = bunifuDataGridView1.SelectedRows[0];
                string primaryKeyValue = selectedRow.Cells["tripID"].Value.ToString();

                // Silme işlemi için fonksiyonu çağrılarak satır silinsin
                DeleteTrip(primaryKeyValue);
            }
            else
            {
                MessageBox.Show("Lütfen bir sefer seçin.");
            }
        }

        private void DeleteTrip(string tripID)
        {
            con.Open();
            try
            {
                string deleteQuery = "DELETE FROM Trip WHERE tripID = @tripID";
                NpgsqlCommand deleteCommand = new NpgsqlCommand(deleteQuery, con);
                deleteCommand.Parameters.AddWithValue("@tripID", tripID);
                deleteCommand.ExecuteNonQuery();
                con.Close();
                pop();
                MessageBox.Show("Sefer başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("Eksik Bilgi Girdiniz", "Güncellenmiyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";

                return;
            }

            try
            {
                con.Open();

                string updateQuery = "UPDATE Trip SET tSource = @tSource, tDestination = @tDestination, tDate = @tDate, sTime = @sTime, dTime = @dTime, price = @price WHERE tripID = @tripID";
                NpgsqlCommand updateCommand = new NpgsqlCommand(updateQuery, con);
                updateCommand.Parameters.AddWithValue("@tSource", textBox5.Text);
                updateCommand.Parameters.AddWithValue("@tDestination", textBox6.Text);
                updateCommand.Parameters.AddWithValue("@tDate", dateTimePicker1.Value);
                updateCommand.Parameters.AddWithValue("@sTime", TimeSpan.Parse(textBox7.Text));
                updateCommand.Parameters.AddWithValue("@dTime", TimeSpan.Parse(textBox8.Text));
                updateCommand.Parameters.AddWithValue("@price", int.Parse(textBox9.Text));
                updateCommand.Parameters.AddWithValue("@tripID", textBox4.Text);

                int rowsAffected = updateCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Sefer Başarıyla Güncellendi", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";

                    bunifuDataGridView1.Refresh();
                    pop(); 
                }
                else
                {
                    MessageBox.Show("Sefer Güncellenemedi", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
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
    }
}