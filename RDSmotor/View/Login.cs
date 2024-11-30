using RDSmotor.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDSmotor.View
{
    public partial class Login : Form
    {
        RdsController rdsController;

        public Login()
        {
            InitializeComponent();
            rdsController = new RdsController();
        }

        private void lbl_closeLogin_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void btn_loginLogin_Click(object sender, EventArgs e)
        {
            if ((txt_emailLogin.Text == "") || (txt_passwordLogin.Text == ""))
            {
                MessageBox.Show("Need login data", "Wrong Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string username = txt_emailLogin.Text;
                string password = txt_passwordLogin.Text;


                DataTable table = rdsController.admin(new MySqlConnector.MySqlCommand
                ("SELECT * FROM Admin WHERE username = '" + username + "' AND passwordd = '" + password + "'"));
            }


            //Home home = new Home();
            //home.Show();
            //this.Hide();
        }

        private void lbl_KATAdaftarakunLogin_Click(object sender, EventArgs e)
        {
            Registrasi Registrasi = new Registrasi();  
            Registrasi.Show();
            this.Hide();
        }

        private void pb_mataterbukaRegis_Click(object sender, EventArgs e)
        {
            // Jika mata terbuka diklik, tampilkan mata tertutup dan tampilkan password
            pb_mataterbukaLogin.Visible = false;
            pb_matatertutupLogin.Visible = true;
            txt_passwordLogin.PasswordChar = '*'; // Menggunakan karakter khusus
        }

        private void pb_matatertutupLogin_Click(object sender, EventArgs e)
        {
            // Jika mata tertutup diklik, tampilkan mata terbuka dan sembunyikan password
            pb_mataterbukaLogin.Visible = true;
            pb_matatertutupLogin.Visible = false;
            txt_passwordLogin.PasswordChar = '\0'; // Menampilkan password
        }

        private void Login_Load(object sender, EventArgs e)
        {
            // Setel awal dengan mata terbuka (password tersembunyi)
            pb_mataterbukaLogin.Visible = false;  // Mata terbuka
            pb_matatertutupLogin.Visible = true; // Mata tertutup
            txt_passwordLogin.PasswordChar = '*'; // Menggunakan karakter khusus
        }


    }
}
