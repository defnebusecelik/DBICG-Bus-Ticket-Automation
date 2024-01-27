using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Drawing;

namespace Ticket_Project
{
    public partial class Personel_İslemleri : Form
    {
        private const string ConnectionString = ("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne");

        public Personel_İslemleri()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin ss = new Admin();
            ss.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string driverName = textBox1.Text;
                string driverPhone = textBox3.Text;
                string driverLicenseDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                string driverLicenseNo = textBox4.Text;
                string driverdate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string company = comboBox1.Text;
                string driverID = textBox6.Text;
                string tripID = textBox8.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Drivers (driverID,driverName, driverPhone, driverDate, driverLicenseNo, driverLicenseDate, companyName, tripID) VALUES " +
                                         "(@driverID, @driverName, @driverPhone, @driverDate, @driverLicenseNo, @driverLicenseDate, @companyName, @tripID)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@driverID", driverID);
                        cmd.Parameters.AddWithValue("@driverName", driverName);
                        cmd.Parameters.AddWithValue("@driverPhone", driverPhone);
                        cmd.Parameters.AddWithValue("@driverDate", DateTime.Parse(driverdate));
                        cmd.Parameters.AddWithValue("@driverLicenseNo", driverLicenseNo);
                        cmd.Parameters.AddWithValue("@driverLicenseDate", DateTime.Parse(driverLicenseDate));
                        cmd.Parameters.AddWithValue("@companyName", company);
                        cmd.Parameters.AddWithValue("@tripID", tripID);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla eklendi.");
                        GetDataForDataGridView();
                        comboBox1.Text = "";
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox6.Text = "";
                        textBox8.Text = "";                  
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
            }
        }

        private void GetDataForDataGridView()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT driverID, driverName, driverPhone, driverDate, driverLicenseNo, driverLicenseDate, companyName, tripID FROM Drivers", con))
                    {
                        using (NpgsqlDataAdapter dp = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            dp.Fill(dt);
                            // DataGridView'e verileri yükle
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PostgreSQL Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
            }
        }

        private void GetDataForDataGridView1()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Assistants", con))
                    {
                        using (NpgsqlDataAdapter dp = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            dp.Fill(dt);
                            // DataGridView'e verileri yükle
                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PostgreSQL Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox8.Text = "";
            }
        }

        // Silinen satırın verisini direkt olarak çıkararak DataGridView'i güncelle
        private void RefreshDataGridViewAfterDelete(int deletedRowIndex)
        {
            if (dataGridView1.DataSource != null)
            {
                DataTable dataTable = (DataTable)dataGridView1.DataSource;
                dataTable.Rows.RemoveAt(deletedRowIndex);
                dataGridView1.DataSource = dataTable;
            }
        }

        private void RefreshDataGridViewAfterDelete1(int deletedRowIndex)
        {
            if (dataGridView2.DataSource != null)
            {
                DataTable dataTable = (DataTable)dataGridView2.DataSource;
                dataTable.Rows.RemoveAt(deletedRowIndex);
                dataGridView2.DataSource = dataTable;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0 || dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Server=localhost;Port=5432;Database=Bus_Project;User Id=postgres;Password=defne;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridView1.SelectedRows[0].Index;

                    using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM Drivers WHERE driverID = @driverID", connection))
                    {
                        string driverID = dataGridView1.Rows[selectedRowIndex].Cells["driverID"].Value.ToString();
                        cmd.Parameters.AddWithValue("@driverID", driverID);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kayıt başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Silinen satırın index'ini kullanarak sadece o satırı güncelle
                    RefreshDataGridViewAfterDelete(selectedRowIndex);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int asistanID = int.Parse(textBox7.Text);
                string asistanName = textBox2.Text;
                string asistanphone =  textBox5.Text;
                string asistandate = dateTimePicker4.Value.ToString("yyyy-MM-dd");
                string company = comboBox2.Text;
                string tripID = textBox9.Text;

                using (NpgsqlConnection connection = new NpgsqlConnection(ConnectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Assistants (assistantID, assistantName, assistantPhone, assistantDate, companyName, tripID) VALUES " +
                                        "(@assistantID, @assistantName, @assistantPhone, @assistantDate, @companyName, @tripID)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@assistantID", asistanID);
                        cmd.Parameters.AddWithValue("@assistantName", asistanName);
                        cmd.Parameters.AddWithValue("@assistantPhone", asistanphone);
                        cmd.Parameters.AddWithValue("@assistantDate", DateTime.Parse(asistandate));
                        cmd.Parameters.AddWithValue("@companyName", company);
                        cmd.Parameters.AddWithValue("@tripID", tripID);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Kayıt başarıyla eklendi.");
                        GetDataForDataGridView1();
                        comboBox2.Text = "";
                        textBox2.Text = "";
                        textBox5.Text = "";
                        textBox7.Text = "";
                        textBox9.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox2.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                textBox7.Text = "";
                textBox9.Text = "";

            }
        }

        private void ShowPassengers()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT driverID, driverName, driverPhone, driverDate, driverLicenseNo, driverLicenseDate, companyName, tripID FROM Drivers", con))
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

        private void ShowPassengers1()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT assistantID, assistantName, assistantPhone, assistantDate, companyName, tripID FROM Assistants", con))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView2.DataSource = dt;
                    }
                }
            }

        }
        private void Calısan_Ekle_Load(object sender, EventArgs e)
        {
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView1_RowPrePaint);
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dataGridView2_RowPrePaint);


            ShowPassengers();
            ShowPassengers1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string connectionString = "Server=localhost;Port=5432;Database=Bus_Project;User Id=postgres;Password=defne;";

                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    int studno = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    DialogResult res;
                    res = MessageBox.Show("Bileti iptal etmek istediğinize emin misiniz ?", "Kaydı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string query = "DELETE FROM Drivers WHERE driverID = @driverID";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@driverID", studno);
                            int ans = cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                string connectionString = "Server=localhost;Port=5432;Database=Bus_Project;User Id=postgres;Password=defne;";

                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    con.Open();
                    int studno = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                    DialogResult res;
                    res = MessageBox.Show("Bileti iptal etmek istediğinize emin misiniz ?", "Kaydı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string query = "DELETE FROM Assistants WHERE assistantID = @assistantID";

                        using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@assistantID", studno);
                            int ans = cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count == 0 || dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek bir kayıt seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string connectionString = "Server=localhost;Port=5432;Database=Bus_Project;User Id=postgres;Password=defne;";

            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                if (dataGridView2.SelectedRows.Count > 0)
                {
                    int selectedRowIndex = dataGridView2.SelectedRows[0].Index;

                    using (NpgsqlCommand cmd = new NpgsqlCommand("DELETE FROM Assistants WHERE assistantID = @assistantID", connection))
                    {
                        // assistantID değerini doğrudan integer'a çevir
                        int assistantID = Convert.ToInt32(dataGridView2.Rows[selectedRowIndex].Cells["assistantID"].Value);

                        cmd.Parameters.AddWithValue("@assistantID", assistantID);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Kayıt başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Silinen satırın index'ini kullanarak sadece o satırı güncelle
                    RefreshDataGridViewAfterDelete1(selectedRowIndex);
                }
            }
        }

        private void LoadCompanyNames()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT companyName FROM Company", con))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            // comboBox1'yi temizle
                            comboBox1.Items.Clear();

                            while (reader.Read())
                            {
                                // Company tablosundan companyName değerlerini comboBox1'e ekle
                                comboBox1.Items.Add(reader["companyName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCompanyNames1()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT companyName FROM Company", con))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            // comboBox1'yi temizle
                            comboBox2.Items.Clear();

                            while (reader.Read())
                            {
                                // Company tablosundan companyName değerlerini comboBox1'e ekle
                                comboBox2.Items.Add(reader["companyName"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            LoadCompanyNames();

        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            LoadCompanyNames1();
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Çift sıra: Arkaplan rengini değiştir
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
            }
            else
            {
                // Tek sıra: Varsayılan arkaplan rengini kullan
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView1.DefaultCellStyle.BackColor;
            }
        }

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView2.Rows.Count)
            {
                if (e.RowIndex % 2 == 0)
                {
                    // Çift sıra: Arkaplan rengini değiştir
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
                }
                else
                {
                    // Tek sıra: Varsayılan arkaplan rengini kullan
                    dataGridView2.Rows[e.RowIndex].DefaultCellStyle.BackColor = dataGridView2.DefaultCellStyle.BackColor;
                }
            }
        }
    }
}