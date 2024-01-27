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

namespace Ticket_Project
{
public partial class Bilet_Satın_Al : Form
    {
        private const string ConnectionString = "Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne";
        static int[] bookedseat;
        static int[] tempbookseat;
         private int totalNumberOfSeats = 30;
        public Bilet_Satın_Al()
        {
            InitializeComponent();
            bookedseat = new int[30];
            tempbookseat = new int[30];
            for (int i = 0; i < tempbookseat.Length; i++)
            {
                tempbookseat[i] = 0;
            }
            alreadybooked();
    
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
        }

        private void pop()
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();

                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT DISTINCT tSource FROM Trip", con))
                {
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox2.Items.Add(reader["tSource"].ToString());
                        }
                    }
                }
            }
        }

        private void alreadybooked()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();

                    string myquery = "SELECT * FROM Bus";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(myquery, con))
                    {
                        using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);

                            int rows = ds.Tables[0].Rows.Count;
                            for (int i = 0; i < rows; i++)
                            {
                                string status = ds.Tables[0].Rows[i]["status"].ToString();
                                UpdateButtonStatus(i + 1, status); // Dizilerde sıfır tabanlı indeksleme kullanıldığı varsayıldı.
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void UpdateButtonStatus(int buttonIndex, string status)
        {
            if (buttonIndex >= 1 && buttonIndex <= bookedseat.Length && buttonIndex <= tempbookseat.Length)
            {
                if (status == "B")
                {
                    bookedseat[buttonIndex - 1] = 1;
                    SetButtonStatus(buttonIndex, Color.Red, false);
                }
                else if (status == "A")
                {
                    bookedseat[buttonIndex - 1] = 0;
                    SetButtonStatus(buttonIndex, Color.Gray, true);
                }
            }
            else
            {
                // Geçersiz indeks hatası durumu
                Console.WriteLine($"Geçersiz indeks: {buttonIndex}");
            }
        }

        private void SetButtonStatus(int buttonIndex, Color backColor, bool enabled)
        {
            if (buttonIndex >= 1 && buttonIndex <= bookedseat.Length)
            {
                Control button = Controls.Find("button" + buttonIndex, true).FirstOrDefault();
                if (button != null && button is Button)
                {
                    ((Button)button).BackColor = backColor;
                    ((Button)button).Enabled = enabled;

                    if (backColor == Color.Red)
                    {
                        ((Button)button).Text = "X";
                    }
                    else
                    {
                        ((Button)button).Text = buttonIndex.ToString();
                    }
                }
            }
            else
            {
                // Geçersiz indeks hatası durumu
                Console.WriteLine($"Geçersiz indeks: {buttonIndex}");
            }
        }

        private void Rezervasyon_Yap_Load(object sender, EventArgs e)
        {
            pop();
        }

        public int fiyat;


        private void ReserveAndAddToPassengerTable(int seatNumber)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();

                // ComboBox'tan seçili seyahatin tripID'sini al
                string selectedTripID = comboBox8.SelectedItem?.ToString();

                // Koltuğu rezerve et
                ReserveSeatAndUpdateComboBox(seatNumber);

                // Passenger tablosuna ekle

            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int selectedSeatNumber = int.Parse(clickedButton.Name.Replace("button", ""));

            // Koltuğu rezerve et ve Passenger tablosuna ekle
            ReserveAndAddToPassengerTable(selectedSeatNumber);

            // Bilet ödeme formunu aç
            Ödeme_İslemleri biletOdemeForm = new Ödeme_İslemleri();

            biletOdemeForm.tSource = comboBox2.SelectedItem?.ToString();
            biletOdemeForm.tDestination = comboBox3.SelectedItem?.ToString();
            biletOdemeForm.tDate = bunifuDatePicker1.Value.Date;
            biletOdemeForm.sTime = TimeSpan.Parse(comboBox4.SelectedItem?.ToString());
            biletOdemeForm.dTime = TimeSpan.Parse(comboBox5.SelectedItem?.ToString());
            biletOdemeForm.price = int.Parse(comboBox6.Text);
            biletOdemeForm.companyName = comboBox1.SelectedItem?.ToString();
            biletOdemeForm.SEYAHAT = comboBox8.SelectedItem?.ToString();
            biletOdemeForm.numberOfSeats = int.Parse(comboBox7.Text);
            biletOdemeForm.SetSelectedSalary(int.Parse(comboBox6.Text));
            biletOdemeForm.SetSelectedtripID(comboBox8.SelectedItem?.ToString());

            MessageBox.Show("Talebiniz alınmıştır. Bilet ödeme formuna yönlendiriliyorsunuz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            biletOdemeForm.ShowDialog();

            if (biletOdemeForm.PaymentSuccessful)
            {
                bookedseat[selectedSeatNumber - 1] = 1;
                SetButtonStatus(selectedSeatNumber, Color.Red, false);
            }
        }

        private void AddToPassengerTable(string tripID, int seatNumber)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();

                    // Passenger tablosuna ekleme SQL sorgusu
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            Kullanıcı_İslemleri ss = new Kullanıcı_İslemleri();
            ss.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
            {
                con.Open();

                string selectedSource = comboBox2.SelectedItem?.ToString();

                comboBox3.Items.Clear();

                string query = "SELECT DISTINCT tDestination FROM Trip WHERE tSource = @tSource";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tSource", selectedSource);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox3.Items.Add(reader["tDestination"].ToString());
                        }
                    }
                }
                comboBox4.Items.Clear();
                comboBox5.Items.Clear();

                query = "SELECT DISTINCT sTime, dTime FROM Trip WHERE tSource = @tSource";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tSource", selectedSource);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox4.Items.Add(reader["sTime"].ToString());
                            comboBox5.Items.Add(reader["dTime"].ToString());
                        }
                    }
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSource = comboBox2.SelectedItem?.ToString();
            string selectedDestination = comboBox3.SelectedItem?.ToString();

            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
            {
                con.Open();

                comboBox4.Items.Clear();
                string timeQuery = "SELECT DISTINCT sTime FROM Trip WHERE tSource = @tSource AND tDestination = @tDestination";
                using (NpgsqlCommand cmd = new NpgsqlCommand(timeQuery, con))
                {
                    cmd.Parameters.AddWithValue("@tSource", selectedSource);
                    cmd.Parameters.AddWithValue("@tDestination", selectedDestination);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox4.Items.Add(reader["sTime"].ToString());
                        }
                    }
                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSource = comboBox2.SelectedItem?.ToString();
            string selectedTime = comboBox4.SelectedItem?.ToString();

            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
            {
                con.Open();

                string query = "SELECT DISTINCT tDate FROM Trip WHERE tSource = @tSource AND sTime = @sTime";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tSource", selectedSource);
                    cmd.Parameters.AddWithValue("@sTime", TimeSpan.Parse(selectedTime));
                }

                comboBox5.Items.Clear();
                string destinationQuery = "SELECT DISTINCT dTime FROM Trip WHERE tSource = @tSource AND sTime = @sTime";
                using (NpgsqlCommand cmd = new NpgsqlCommand(destinationQuery, con))
                {
                    cmd.Parameters.AddWithValue("@tSource", selectedSource);
                    cmd.Parameters.AddWithValue("@sTime", TimeSpan.Parse(selectedTime));

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox5.Items.Add(reader["dTime"].ToString());
                        }
                    }
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedTime = comboBox5.SelectedItem?.ToString();

            if (TimeSpan.TryParse(selectedTime, out TimeSpan parsedTime))
            {
                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
                {
                    con.Open();

                    string query = "SELECT DISTINCT companyName FROM Trip WHERE dTime = @dTime AND tSource = @tSource";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        // Assuming comboBox2, comboBox3, and dateTimePicker1 are your UI controls for tSource, tDestination, and tDate respectively.
                        cmd.Parameters.AddWithValue("@dTime", parsedTime);
                        cmd.Parameters.AddWithValue("@tSource", comboBox2.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@tDestination", comboBox3.SelectedItem?.ToString());

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["companyName"].ToString());
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Geçersiz saat formatı");
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox6.Items.Clear(); // Clear existing items before adding new ones

                string selectedCompanyName = comboBox1.SelectedItem?.ToString();

                using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
                {
                    con.Open();

                    // Fetch unique price values based on the selected criteria
                    string query = "SELECT DISTINCT price FROM Trip WHERE tSource = @tSource AND tDestination = @tDestination AND sTime = @sTime AND dTime = @dTime";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@tSource", comboBox2.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@tDestination", comboBox3.SelectedItem?.ToString());
                        cmd.Parameters.AddWithValue("@sTime", TimeSpan.Parse(comboBox4.SelectedItem?.ToString()));
                        cmd.Parameters.AddWithValue("@dTime", TimeSpan.Parse(comboBox5.SelectedItem?.ToString()));

                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                comboBox6.Items.Add(reader["price"].ToString());
                            }
                        }
                    }
                }

                // Optionally, you can select the first item in comboBox6 if available
                if (comboBox6.Items.Count > 0)
                {
                    comboBox6.SelectedIndex = 0;
                    // Trigger the logic for comboBox6_SelectedIndexChanged
                    comboBox6_SelectedIndexChanged(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                comboBox7.Items.Clear();
                string selectedPrice = comboBox6.SelectedItem?.ToString();

                if (int.TryParse(selectedPrice, out int price))
                {
                    DateTime selectedTDate = CheckSeatStatusForCompany(price);
                    string selectedTripID = GetTripID(price);

                    if (selectedTDate != DateTime.MinValue || !string.IsNullOrEmpty(selectedTripID))
                    {
                        bunifuDatePicker1.Value = selectedTDate;
                        comboBox8.Text = selectedTripID;

                        // Call ReserveSeat method to update seat button colors
                        ReserveSeat();
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz price formatı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetTripID(int salary)
        {
            string tripID = string.Empty;

            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
            {
                con.Open();

                string query = "SELECT DISTINCT tripID FROM Trip WHERE price = @price";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@price", salary);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBox8.Items.Add(reader["tripID"].ToString());

                            tripID = Convert.ToString(reader["tripID"]);
                        }
                    }
                }
            }
            return tripID;
        }

        public DateTime CheckSeatStatusForCompany(int salary)
        {
            DateTime selectedTDate = DateTime.MinValue;

            using (NpgsqlConnection con = new NpgsqlConnection("Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne"))
            {
                con.Open();

                // First, fetch the numberOfSeats from the Seat table
                string seatQuery = "SELECT DISTINCT seatNumber FROM Bus WHERE busID IN (SELECT busID FROM Trip WHERE price = @price)";

                using (NpgsqlCommand seatCmd = new NpgsqlCommand(seatQuery, con))
                {
                    seatCmd.Parameters.AddWithValue("@price", salary);

                    using (NpgsqlDataReader seatReader = seatCmd.ExecuteReader())
                    {
                        while (seatReader.Read())
                        {
                            comboBox7.Items.Add(seatReader["seatNumber"].ToString());
                        }
                    }
                }

                // Then, fetch the tDate, tripID, and price from the Trip table
                string tripQuery = "SELECT DISTINCT tDate, tripID, price FROM Trip WHERE price = @price";

                using (NpgsqlCommand tripCmd = new NpgsqlCommand(tripQuery, con))
                {
                    tripCmd.Parameters.AddWithValue("@price", salary);

                    using (NpgsqlDataReader tripReader = tripCmd.ExecuteReader())
                    {
                        while (tripReader.Read())
                        {
                            selectedTDate = Convert.ToDateTime(tripReader["tDate"]);
                            // You can use the retrieved values for other purposes if needed
                            string selectedTripID = tripReader["tripID"].ToString();
                            int selectedPrice = Convert.ToInt32(tripReader["price"]);
                        }
                    }
                }
            }

            return selectedTDate;
        }

        private void ReserveSeat()
        {
            // Iterate through all seat buttons
            for (int seatNumber = 1; seatNumber <= totalNumberOfSeats; seatNumber++)
            {
                // Koltuk rezerve edilmemişse, duruma göre işlem yap
                Control buttonControl = Controls.Find($"button{seatNumber}", true).FirstOrDefault();

                // Check if the seat is reserved in the database
                if (IsSeatAlreadyReserved(seatNumber))
                {
                    // Koltuk kırmızıya dönsün ve devre dışı bırakılsın
                    if (buttonControl is Button)
                    {
                        ((Button)buttonControl).BackColor = Color.Red;
                        ((Button)buttonControl).Enabled = false;
                    }
                }
                else
                {
                    // Koltuk yeşile dönsün ve etkin bırakılsın
                    if (buttonControl is Button)
                    {
                        ((Button)buttonControl).BackColor = Color.Green;
                        ((Button)buttonControl).Enabled = true;

                        // Koltuk butonuna Click olayını ekle
                        ((Button)buttonControl).Click += button29_Click;
                    }
                }
            }

            // Update comboBox7 based on the available seats
            UpdateComboBox7();
        }

        private void UpdateComboBox7()
        {
            // Clear existing items
            comboBox7.Items.Clear();

            // Iterate through all seat buttons
            for (int seatNumber = 1; seatNumber <= totalNumberOfSeats; seatNumber++)
            {
                // Check if the seat is green (available) and enabled
                Control buttonControl = Controls.Find($"button{seatNumber}", true).FirstOrDefault();
                if (buttonControl is Button && ((Button)buttonControl).BackColor == Color.Green && ((Button)buttonControl).Enabled)
                {
                    // Add the seat number to comboBox7
                    comboBox7.Items.Add(seatNumber.ToString());
                }
            }
        }

        private void ReserveSeatAndUpdateComboBox(int seatNumber)
        {
            // Check if a trip is selected
            if (comboBox8.SelectedItem == null)
            {
                // Show a message prompting the user to select a trip first
                MessageBox.Show("Lütfen bir sefer seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the seat is already reserved
            if (!IsSeatAlreadyReserved(seatNumber))
            {
                ReserveSeat();

                // Find the comboBox7 and update its selected item
                comboBox7.SelectedItem = seatNumber.ToString();

                // Update the status in the database and add to Passenger table
                UpdateButtonStatus(seatNumber, "B");
                AddToPassengerTable(comboBox8.SelectedItem?.ToString(), seatNumber);
            }
            else
            {
                MessageBox.Show($"Koltuk {seatNumber} zaten rezerve edilmiş.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool IsSeatAlreadyReserved(int seatNumber)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();

                // comboBox8.SelectedItem'ın null olup olmadığını kontrol et
                if (comboBox8.SelectedItem == null)
                {
                    // comboBox8.SelectedItem null ise, kullanıcıya bir mesaj göster ve false döndür
                    MessageBox.Show("Lütfen bir sefer seçmeden koltuk rezervasyonu yapmayı denemeyin.");
                    return false;
                }

                string query = "SELECT COUNT(*) FROM Passenger WHERE tripID = @tripID AND seatNumber = @seatNumber";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    // Parametre değerlerini ayarla
                    cmd.Parameters.AddWithValue("@tripID", comboBox8.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@seatNumber", seatNumber);

                    int rowCount = Convert.ToInt32(cmd.ExecuteScalar());

                    return rowCount > 0;
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(2);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(3);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(4);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(5);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(6);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(7);
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(8);
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(9);
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(10);
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(11);
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(12);
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(13);
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(14);
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(15);
        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(16);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(17);
        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(18);
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(19);
        }

        private void button20_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(20);
        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(21);
        }

        private void button22_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(22);
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(23);
        }

        private void button24_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(24);
        }

        private void button25_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(25);
        }

        private void button26_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(26);
        }

        private void button27_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(27);
        }

        private void button28_Click_1(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(28);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            ReserveSeatAndUpdateComboBox(30);
        }
    }
}