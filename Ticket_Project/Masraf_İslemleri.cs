using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.Data.OleDb;
using System.Drawing;

namespace Ticket_Project
{
    public partial class Masraf_İslemleri : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne";

        public Masraf_İslemleri()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin ss = new Admin();
            ss.Show();
        }

        private void pop()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();

                    // Retrieve values of cost_type enum from PostgreSQL
                    string query = "SELECT unnest(enum_range(NULL::cost_type))::text AS cost_type_value";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear existing items in comboBox1
                            comboBox1.Items.Clear();

                            // Add retrieved cost_type values to comboBox1
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["cost_type_value"].ToString());
                            }
                        }
                    }

                    // Refresh DataGridView
                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Costs", con))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dgvMasraf.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox2.Text) || comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Eksik Bilgi Girdiniz", "Eklenmiyor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    return;
                }

                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();

                    // Insert data into Costs table
                    string otobusMasrafQuery = "INSERT INTO Costs (busID, costTypeID, costType, totalCost) VALUES (@busID, @costTypeID, @costType, @totalCost)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(otobusMasrafQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@busID", textBox4.Text);
                        cmd.Parameters.AddWithValue("@costTypeID", Convert.ToInt32(textBox1.Text)); // costTypeID değerini belirtin
                        cmd.Parameters.AddWithValue("@costType", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@totalCost", Convert.ToInt32(textBox2.Text));

                        // Execute the query only once
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Otobüs Masraf Bilgisi Başarıyla Eklendi");
                    // Clear and refresh DataGridView
                    dgvMasraf.DataSource = null;
                    dgvMasraf.Refresh();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";

                    // Retrieve and bind the updated data
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter("SELECT * FROM Costs", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvMasraf.DataSource = dt;

                    // Refresh comboBox1 with the latest costType values
                    pop();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                int selectedCostID = GetSelectedCostID();
                if (selectedCostID == -1)
                {
                    MessageBox.Show("Lütfen silmek istediğiniz Masrafı seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM Costs WHERE costID=@costID", con))
                    {
                        cmd.Parameters.AddWithValue("@costID", selectedCostID);

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                String BusID = Convert.ToString(reader["busID"]);
                                reader.Close();

                                DialogResult result = MessageBox.Show("Masrafı iptal etmek istediğinize emin misiniz?", "Kaydı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    using (NpgsqlCommand deleteCmd = new NpgsqlCommand("DELETE FROM Costs WHERE costID = @costID", con))
                                    {
                                        deleteCmd.Parameters.AddWithValue("@costID", selectedCostID);

                                        int affectedRows = deleteCmd.ExecuteNonQuery();

                                        if (affectedRows > 0)
                                        {
                                            MessageBox.Show("Masraf başarıyla silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            textBox1.Text = "";
                                            textBox2.Text = "";
                                            textBox4.Text = "";
                                            comboBox1.Text = "";

                                            // Yeniden veri çekerek DataGridView'i güncelle
                                            pop();
                                        }
                                        else
                                        {
                                            MessageBox.Show("Masraf silinemedi.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Eşleşen kayıt bulunamadı.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                textBox1.Text = "";
                                textBox2.Text = "";
                                textBox4.Text = "";
                                comboBox1.Text = "";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Masraf Bilgileri silinemedi: " + ex.Message);
            }
        }

        private void dgvMasraf_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                OleDbConnection con = new OleDbConnection("server=localHost;Port=5432;Database=Bus_Project;user ID=postgres;password=defne");
                con.Open();
                int studno = Convert.ToInt16(dgvMasraf.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
                DialogResult res;
                res = MessageBox.Show("Masrafı iptal etmek istediğinize emin misiniz ?", "Kaydı Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    OleDbCommand cmd = new OleDbCommand("delete from Costs where busID=" + studno + "", con);
                    int ans = cmd.ExecuteNonQuery();
                    // Yeniden veri çekerek DataGridView'i güncelle
                    pop();
                    con.Close();
                }
            }
        }

        // Seçili maliyetin costID'sini döndüren yardımcı fonksiyon
        private int GetSelectedCostID()
        {
            if (dgvMasraf.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvMasraf.SelectedRows[0].Cells["costID"].Value);
            }
            return -1; // Eğer seçili bir satır yoksa -1 döndür
        }

        private void Masraf_Detay_Load(object sender, EventArgs e)
        {
            dgvMasraf.RowPrePaint += new DataGridViewRowPrePaintEventHandler(dgvMasraf_RowPrePaint);
            pop();
        }

        private void dgvMasraf_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                // Çift sıra: Arkaplan rengini değiştir
                dgvMasraf.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aqua;
            }
            else
            {
                // Tek sıra: Varsayılan arkaplan rengini kullan
                dgvMasraf.Rows[e.RowIndex].DefaultCellStyle.BackColor = dgvMasraf.DefaultCellStyle.BackColor;
            }
        }
    }
}