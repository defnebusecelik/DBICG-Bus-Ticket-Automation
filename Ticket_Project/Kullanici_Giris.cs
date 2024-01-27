using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.Drawing;

namespace Ticket_Project
{
    public partial class Kullanici_Giris : Form
    {
        private NpgsqlConnection connection;
        private string connectionString = "server=localHost;Port=5432;Database=Bus_Project; user ID=postgres; password=defne";

        public Kullanici_Giris()
        {
            InitializeComponent();
            connection = new NpgsqlConnection(connectionString);
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            try
            {
                connection.Open();

                // PostgreSQL sorgusunu burada düzenle
                string query = "SELECT * FROM tbKullanicilar WHERE kullanici_adi = @kullanici_adi AND kullanici_sifresi = @kullanici_sifresi";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@kullanici_adi", username);
                    cmd.Parameters.AddWithValue("@kullanici_sifresi", password);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Kullanıcı bulundu
                            AnaSayfa form2 = new AnaSayfa();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Kullanıcı bulunamadı
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı hatası: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                label1.ForeColor = Color.Lime;
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
    