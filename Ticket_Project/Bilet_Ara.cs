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
    public partial class Bilet_Ara : Form
    {
        public Bilet_Ara()
        {
            InitializeComponent();
        }

        private void pop()
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT tSource FROM Trip", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader["tSource"].ToString());
                        }
                    }
                }
            }
        }

        private bool IsDateValid(DateTime date)
        {
            // Örneğin, tarihin şu andan ileri bir tarih olup olmadığını kontrol edelim
            return date > DateTime.Now;
        }

        private List<string> GetDestinations(string source, DateTime date)
        {
            // Tarih ve kaynak değerlerine göre destinasyonları getir
            List<string> destinations = new List<string>();

            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
            {
                con.Open();

                string query = "SELECT DISTINCT tDestination FROM Trip WHERE tSource = @tSource AND tDate = @tDate";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tSource", source);
                    cmd.Parameters.AddWithValue("@tDate", date);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            destinations.Add(reader["tDestination"].ToString());
                        }
                    }
                }
            }

            return destinations;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDateValid(dateTimePicker1.Value))
                {
                    MessageBox.Show("Geçersiz tarih girdiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    return;
                }

                // Tarih ve kaynak değerlerini al
                DateTime selectedDate = dateTimePicker1.Value.Date;
                string selectedSource = comboBox1.SelectedItem?.ToString();

                // Tarih ve kaynak değerlerine göre destinasyonları getir
                List<string> destinations = GetDestinations(selectedSource, selectedDate);

                // Eğer destinasyon listesi boşsa veya null ise hata mesajı göster
                if (destinations == null || destinations.Count == 0)
                {
                    MessageBox.Show("Geçerli destinasyon bulunamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    return;
                }

                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
                {
                    con.Open();
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT tSource, tDestination, tDate, sTime, dTime FROM Trip WHERE tSource=@tSource AND tDestination=@tDestination AND tDate=@tDate AND sTime=@sTime AND dTime=@dTime", con))
                    {
                        cmd.Parameters.AddWithValue("@tSource", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@tDestination", comboBox2.Text);
                        cmd.Parameters.AddWithValue("@tDate", dateTimePicker1.Value.Date);
                        cmd.Parameters.AddWithValue("@sTime", TimeSpan.Parse(comboBox3.Text));
                        cmd.Parameters.AddWithValue("@dTime", TimeSpan.Parse(comboBox4.Text));

                        cmd.CommandType = CommandType.Text;
                        using (NpgsqlDataAdapter dp = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            dp.Fill(dt);

                            // DataGridView'e verileri bağla
                            bunifuDataGridView1.DataSource = dt;

                            // DataGridView'i görünür yap
                            bunifuDataGridView1.Visible = true;
                            comboBox1.Text = "";
                            comboBox2.Text = "";
                            comboBox3.Text = "";
                            comboBox4.Text = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lütfen Eksik Girmeyiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kullanıcı_İslemleri ss = new Kullanıcı_İslemleri();
            ss.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
                {
                    con.Open();

                    string selectedSource = comboBox1.SelectedItem?.ToString();

                    // comboBox2'yi temizle
                    comboBox2.Items.Clear();

                    string query = "SELECT DISTINCT tDestination FROM Trip WHERE tSource = @tSource";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@tSource", selectedSource);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            // comboBox2'yi temizle ve yeni bilgileri ekle
                            while (reader.Read())
                            {
                                comboBox2.Items.Add(reader["tDestination"].ToString());
                            }
                        }
                    }

                    // comboBox3 ve comboBox4'ü temizle
                    comboBox3.Items.Clear();
                    comboBox4.Items.Clear();

                    // comboBox3 ve comboBox4'e saat bilgilerini ekle
                    query = "SELECT DISTINCT sTime, dTime FROM Trip WHERE tSource = @tSource";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@tSource", selectedSource);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox3.Items.Add(reader["sTime"].ToString());
                                comboBox4.Items.Add(reader["dTime"].ToString());
                            }
                        }
                    }
                } // 'con' burada otomatik olarak kapatılır ve bellekten temizlenir.
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Bilet_Ara_Load(object sender, EventArgs e)
        {
            bunifuDataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(bunifuDataGridView1_RowPrePaint);

            pop();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Seçili tarih değerini al
                string selectedTime = comboBox4.SelectedItem?.ToString();

                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
                {
                    con.Open();

                    // comboBox4 seçildikten sonra ilgili tDate değerini al
                    string query = "SELECT DISTINCT tDate FROM Trip WHERE dTime = @dTime";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@dTime", TimeSpan.Parse(selectedTime));

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // tDate değerini al ve dateTimePicker1'e atayarak göster
                                dateTimePicker1.Value = reader.GetDateTime(0);
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


        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Seçili tarih ve kaynak değerini al
                string selectedSource = comboBox1.SelectedItem?.ToString();
                string selectedTime = comboBox3.SelectedItem?.ToString();

                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
                {
                    con.Open();

                    // comboBox3 seçildikten sonra ilgili tDate değerini al
                    string query = "SELECT DISTINCT tDate FROM Trip WHERE tSource = @tSource AND sTime = @sTime";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@tSource", selectedSource);
                        cmd.Parameters.AddWithValue("@sTime", TimeSpan.Parse(selectedTime));
                    }

                    // comboBox3 seçildikten sonra comboBox4'ü güncelle
                    comboBox4.Items.Clear();
                    string destinationQuery = "SELECT DISTINCT dTime FROM Trip WHERE tSource = @tSource AND sTime = @sTime";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(destinationQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@tSource", selectedSource);
                        cmd.Parameters.AddWithValue("@sTime", TimeSpan.Parse(selectedTime));

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox4.Items.Add(reader["dTime"].ToString());
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // Seçili tarih ve kaynak değerlerini al
                string selectedSource = comboBox1.SelectedItem?.ToString();
                string selectedDestination = comboBox2.SelectedItem?.ToString();

                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
                {
                    con.Open();

                    // comboBox2 seçildikten sonra comboBox3'ü güncelle
                    comboBox3.Items.Clear();
                    string timeQuery = "SELECT DISTINCT sTime FROM Trip WHERE tSource = @tSource AND tDestination = @tDestination";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(timeQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@tSource", selectedSource);
                        cmd.Parameters.AddWithValue("@tDestination", selectedDestination);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox3.Items.Add(reader["sTime"].ToString());
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