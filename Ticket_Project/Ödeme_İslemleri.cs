using System;
using System.Data;
using Npgsql;
using System.Windows.Forms;
using NpgsqlTypes;
 
namespace Ticket_Project
{
    public partial class Ödeme_İslemleri : Form
    {
        // Diğer alanlar...
        public string cardNumber;
        public string cardName;
        public string cardCsv;
        public DateTime cardDate;
        public string cardType;

        // Ödeme işlemleri için gerekli Trip bilgilerini tutan alanlar
        public string SEYAHAT;
        public string tSource;
        public string tDestination;
        public DateTime tDate;
        public int numberOfSeats;
        public TimeSpan sTime;
        public TimeSpan dTime;
        public int price;
        public string companyName;

        // Diğer müşteri bilgilerini tutan alanlar
        public string pName;
        public string pLastName;
        private string pTel;
        public string pMail;
        string gender;
        public string fiyat;

        private const string ConnectionString = "Host=localhost;Port=5432;Database=Bus_Project;Username=postgres;Password=defne";

        public Ödeme_İslemleri()
        {
            InitializeComponent();
        }

        private object GetTripID(string tSource, string tDestination, DateTime tDate, TimeSpan sTime, TimeSpan dTime, int price, string companyName)
        {
            using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
            {
                con.Open();

                string query = "SELECT tripID FROM Trip WHERE tSource = @tSource AND tDestination = @tDestination AND tDate = @tDate AND sTime = @sTime AND dTime = @dTime AND price = @price AND companyName = @companyName";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tSource", NpgsqlDbType.Varchar, tSource);
                    cmd.Parameters.AddWithValue("@tDestination", NpgsqlDbType.Varchar, tDestination);
                    cmd.Parameters.AddWithValue("@tDate", NpgsqlDbType.Date, tDate);
                    cmd.Parameters.AddWithValue("@sTime", NpgsqlDbType.Time, sTime);
                    cmd.Parameters.AddWithValue("@dTime", NpgsqlDbType.Time, dTime);
                    cmd.Parameters.AddWithValue("@price", NpgsqlDbType.Integer, price);
                    cmd.Parameters.AddWithValue("@companyName", NpgsqlDbType.Varchar, companyName);

                    object result = cmd.ExecuteScalar();

                    return result ?? DBNull.Value;
                }
            }
        }

        private void ProcessPayment()
        {
            // Trip tablosundan tripID'yi al
            string tripID = GetTripID(tSource, tDestination, tDate, sTime, dTime, price, companyName).ToString();

          
                using (NpgsqlConnection con = new NpgsqlConnection(ConnectionString))
                {
                    con.Open();

                // Passenger tablosuna müşteri bilgilerini ekleyin
                string insertPassengerQuery = "INSERT INTO Passenger (tripID, pName, pLastName, pTel, pMail,gender, tSource, tDestination, tDate, sTime, dTime, price, companyName, seatNumber, cardNumber, cardName, cardCsv, cardDate, cardtype) " +
                                             "VALUES (@tripID ,@pName, @pLastName, @pTel, @pMail,@gender, @tSource, @tDestination, @tDate, @sTime, @dTime, @price, @companyName, @seatNumber, @cardNumber, @cardName, @cardCsv, @cardDate, @cardtype)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(insertPassengerQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@tripID", NpgsqlDbType.Varchar, GetTripID(tSource, tDestination, tDate, sTime, dTime, price, companyName));
                        cmd.Parameters.AddWithValue("@pName", NpgsqlDbType.Varchar, pName);
                        cmd.Parameters.AddWithValue("@pLastName", NpgsqlDbType.Varchar, pLastName);
                        cmd.Parameters.AddWithValue("@pTel", NpgsqlDbType.Varchar, pTel);
                        cmd.Parameters.AddWithValue("@pMail", NpgsqlDbType.Varchar, pMail);
                        cmd.Parameters.AddWithValue("@gender", NpgsqlDbType.Varchar, gender);

                        cmd.Parameters.AddWithValue("@tSource", NpgsqlDbType.Varchar, tSource);
                        cmd.Parameters.AddWithValue("@tDestination", NpgsqlDbType.Varchar, tDestination);

                        cmd.Parameters.AddWithValue("@tDate", (object)tDate ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@sTime", (object)sTime ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@dTime", (object)dTime ?? DBNull.Value);

                        cmd.Parameters.AddWithValue("@price", NpgsqlDbType.Integer, price);
                        cmd.Parameters.AddWithValue("@companyName", NpgsqlDbType.Varchar, companyName);
                        cmd.Parameters.AddWithValue("@seatNumber", NpgsqlDbType.Integer, numberOfSeats);

                        cmd.Parameters.AddWithValue("@cardNumber", NpgsqlDbType.Varchar, cardNumber);
                        cmd.Parameters.AddWithValue("@cardName", NpgsqlDbType.Varchar, cardName);
                        cmd.Parameters.AddWithValue("@cardCsv", NpgsqlDbType.Varchar, cardCsv);
                        cmd.Parameters.AddWithValue("@cardDate", NpgsqlDbType.Date, cardDate);

                        cmd.Parameters.AddWithValue("@cardtype", NpgsqlDbType.Varchar, cardType);
   
                    cmd.ExecuteNonQuery();
                    }

                // Seat tablosundaki koltuğu rezerve et
                string updateSeatQuery = "UPDATE Bus SET status = 'B' WHERE busID = @busID AND seatNumber = @seatNumber";

                using (NpgsqlCommand cmd = new NpgsqlCommand(updateSeatQuery, con))
                {
                    cmd.Parameters.AddWithValue("@busID", NpgsqlDbType.Varchar, SEYAHAT);
                    cmd.Parameters.AddWithValue("@seatNumber", NpgsqlDbType.Integer, numberOfSeats);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        private bool isPaymentProcessed = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isPaymentProcessed)
            {
                try
                {

                    if (!IsValidEmail(txtem.Text))
                    {
                        MessageBox.Show("Geçerli bir e-posta adresi giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Validate phone number format
                    if (!IsValidPhoneNumber(textBox2.Text))
                    {
                        MessageBox.Show("Geçerli bir telefon numarası giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Ödeme bilgilerini al
                    SEYAHAT = label13.Text;
                    pName = txtnm.Text;
                    pLastName = textBox3.Text;
                    pTel = textBox2.Text;
                    pMail = txtem.Text;
                    gender = textBox1.Text;
                    cardName = txtKartUzerindekiIsim.Text;
                    cardNumber = txtKartNumarasi.Text;
                    cardCsv = txtCvvKodu.Text;
                    price = int.Parse(lblToplamUcret.Text);
                    cardDate = dtpSKT.Value.Date;

                    // cardType değerini seçilen RadioButton'a göre ayarlayın
                    if (rdbVisa.Checked)
                    {
                        cardType = "Visa";
                    }
                    else if (rdbMasterCard.Checked)
                    {
                        cardType = "MasterCard";
                    }
                    else
                    {
                        // Hiçbir RadioButton seçilmediyse bir işlem yapmayın veya hata mesajı gösterin
                        MessageBox.Show("Lütfen bir kredi kartı tipi seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Ödeme işlemleri için gerekli metodu çağırın
                    ProcessPayment();

                    MessageBox.Show($"Bilet ödendi. Teşekkür ederiz! Ödeme Tutarı: {lblToplamUcret.Text} TL", "Ödeme Onayı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Yolcu bilgilerini Makbuz formuna aktarın
                    Makbuz rs = new Makbuz();
                    rs.nm = pName;
                    rs.em = pMail;
                    rs.mno = pTel;
                    rs.sou = tSource;
                    rs.des = tDestination;
                    rs.b_bas = sTime;
                    rs.arrival = dTime;
                    rs.firma = companyName;
                    rs.price = price;
                    rs.tarih = tDate;
                    rs.sno = numberOfSeats;

                    // Makbuz formunu gösterin
                    rs.Show();
                    rs.Focus();

                    // İşlem tamamlandı olarak işaretleyin
                    isPaymentProcessed = true;
                }
                catch (NpgsqlException ex)
                {
                    // Handle database exceptions here (if needed)
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    // Handle other exceptions here (if needed)
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+[.][A-Za-z]+$");
        }

        // Phone number validation method
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^05[0-9]{9}$");
        }


        public bool PaymentSuccessful { get; set; }

        private int selectedSalary;
        private string selectedtripID;

        public void SetSelectedSalary(int salary)
        {
            selectedSalary = salary;
        }

        public void SetSelectedtripID(string ID)
        {
            selectedtripID = ID;
        }

        private void Bilet_Ödeme_Load(object sender, EventArgs e)
        {

            try
            {
                // Display the selected salary on the form
                lblToplamUcret.Text = selectedSalary.ToString();
                label13.Text = selectedtripID.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}