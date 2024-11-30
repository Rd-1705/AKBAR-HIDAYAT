using RDSmotor.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDSmotor.View
{
    public partial class Registrasi : Form
    {
        RdsController rdsController;
        public Registrasi()
        {
            InitializeComponent();
            rdsController = new RdsController();
        }

        private void lbl_closeRegistrasi_Click(object sender, EventArgs e)
        {
            Login login = new Login(); 
            login.Show();
            this.Hide();
        }

        private void lbl_KATAmasukRegistrasi_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btn_daftarRegistrasi_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        bool verify()
        {
            if ((txt_emailRegistrasi.Text == "") || (txt_passwordRegistrasi.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void lbl_ketentuanPWRegistrasi_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {
                    rdsController.adminLOGRES(txt_emailRegistrasi.Text, txt_passwordRegistrasi.Text);

                    MessageBox.Show("Penambahan data baru berhasil", "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_emailRegistrasi.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Inputan kosong", "Tambah data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pb_mataterbukaRegis_Click(object sender, EventArgs e)
        {
            // Jika mata terbuka diklik, tampilkan mata tertutup dan tampilkan password
            pb_mataterbukaRegis.Visible = false;
            pb_matatertutupRegis.Visible = true;
            txt_passwordRegistrasi.PasswordChar = '*'; // Menggunakan karakter khusus
        }

        private void pb_matatertutupRegis_Click(object sender, EventArgs e)
        {
            // Jika mata tertutup diklik, tampilkan mata terbuka dan sembunyikan password
            pb_mataterbukaRegis.Visible = true;
            pb_matatertutupRegis.Visible = false;
            txt_passwordRegistrasi.PasswordChar = '\0'; // Menampilkan password

        }

        private void Registrasi_Load(object sender, EventArgs e)
        {
            // Setel awal dengan mata terbuka (password tersembunyi)
            pb_mataterbukaRegis.Visible = false;  // Mata terbuka
            pb_matatertutupRegis.Visible = true; // Mata tertutup
            txt_passwordRegistrasi.PasswordChar = '*'; // Menggunakan karakter khusus

        }
    }
}
