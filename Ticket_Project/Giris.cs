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
    public partial class Giris : Form
    {
        private string connString = "server=localHost;Port=5432;Database=Bus_Project;user ID=postgres;password=defne";
        public Giris()
        {
            InitializeComponent();
        }

        private void btn_giris_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                con.Open();

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Eksik bilgi girdiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                else
                {
                    string query = "SELECT * FROM Users WHERE userName = @userName AND upassword = @upassword";
                    using (NpgsqlCommand cmdMusteri = new NpgsqlCommand(query, con))
                    {
                        cmdMusteri.Parameters.AddWithValue("@userName", textBox1.Text);
                        cmdMusteri.Parameters.AddWithValue("@upassword", textBox2.Text);

                        using (NpgsqlDataReader drMusteri = cmdMusteri.ExecuteReader())
                        {
                            if (drMusteri.Read())
                            {
                                MessageBox.Show("Başarıyla Giriş Yapıldı", "Müşteri Girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Kullanıcı_İslemleri musteriForm = new Kullanıcı_İslemleri();
                                musteriForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox1.Focus();
                            }
                        }
                    }
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
            textBox2.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(connString))
            {
                con.Open();

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Eksik bilgi girdiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Focus();
                }
                else
                {
                    string query = "SELECT * FROM Manager WHERE managerUserName = @managerUserName AND mpassword = @mpassword";
                    using (NpgsqlCommand cmdAdmin = new NpgsqlCommand(query, con))
                    {
                        cmdAdmin.Parameters.AddWithValue("@managerUserName", textBox1.Text);
                        cmdAdmin.Parameters.AddWithValue("@mpassword", textBox2.Text);

                        using (NpgsqlDataReader drAdmin = cmdAdmin.ExecuteReader())
                        {
                            if (drAdmin.Read())
                            {
                                MessageBox.Show("Başarıyla Giriş Yapıldı", "Admin Girişi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Admin ss = new Admin();
                                ss.Show();
                            }
                            else
                            {
                                MessageBox.Show("Yanlış Kullanıcı Adı veya Şifre", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox1.Focus();
                            }
                        }
                    }
                }
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre alanlarını doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                textBox2.Clear();
                textBox1.Focus();
                return;
            }

            using (NpgsqlConnection con = new NpgsqlConnection("server=localHost;Port=5432;Database=Bus_Project;user ID=postgres;password=defne"))
            {
                con.Open();

                string queryCheckUser = "SELECT COUNT(*) FROM Users WHERE userName = @userName";
                using (NpgsqlCommand cmdCheckUser = new NpgsqlCommand(queryCheckUser, con))
                {
                    cmdCheckUser.Parameters.AddWithValue("@userName", kullaniciAdi);
                    long userCount = (long)cmdCheckUser.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten kullanımda. Lütfen farklı bir hesap tercih edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                        return;
                    }
                }

                string queryCheckManager = "SELECT COUNT(*) FROM Manager WHERE managerUserName = @managerUserName";
                using (NpgsqlCommand cmdCheckManager = new NpgsqlCommand(queryCheckManager, con))
                {
                    cmdCheckManager.Parameters.AddWithValue("@managerUserName", kullaniciAdi);
                    long managerCount = (long)cmdCheckManager.ExecuteScalar();

                    if (managerCount > 0)
                    {
                        MessageBox.Show("Bu Yönetici adı zaten kullanımda. Lütfen farklı bir hesap tercih edin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox1.Focus();
                        return;
                    }
                }

                string queryInsertUser = "INSERT INTO Users(userName, upassword) VALUES (@userName, @upassword)";
                using (NpgsqlCommand cmdInsertUser = new NpgsqlCommand(queryInsertUser, con))
                {
                    cmdInsertUser.Parameters.AddWithValue("@userName", kullaniciAdi);
                    cmdInsertUser.Parameters.AddWithValue("@upassword", sifre);
                    MessageBox.Show("Başarıyla Kayıt Olundu","Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Text = "";
                    textBox2.Text = "";

                   cmdInsertUser.ExecuteNonQuery();
                }
            }
        }
    }
}