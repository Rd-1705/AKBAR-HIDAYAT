using Guna.UI2.WinForms;
using MySqlConnector;
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
    public partial class Penjualan : Form
    {
        RdsController rdsController;
        public Penjualan()
        {
            InitializeComponent();
            rdsController = new RdsController();
            Showtable();
            ShowtablePenjualan();
        }

        private void lbl_closeJual_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void btn_beliJual_Click(object sender, EventArgs e)
        {
            Pembelian beli = new Pembelian();
            beli.Show();
            this.Hide();
        }

        private void llbl_logregJual_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btn_clearJual_Click(object sender, EventArgs e)
        {
            txt_emailJual.Clear();
            txt_hargaJual.Clear();
            txt_idJual.Clear();
            txt_id_motorJual.Clear();
            txt_kode_jenisJual.Clear();
            txt_statusJual.Clear();
            dtp_tanggalJual.Value = DateTime.Now;
        }

        bool verify()
        {
            if ((txt_idJual.Text == "") || (txt_emailJual.Text == "") || (txt_kode_jenisJual.Text == "") || (txt_id_motorJual.Text == "") ||
                (txt_namamotorJual.Text == "")|| (txt_statusJual.Text == "")  || (dtp_tanggalJual.Value > DateTime.Now) || (txt_hargaJual.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_addJual_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {

                    rdsController.addPenjualan(txt_idJual.Text, txt_emailJual.Text, txt_kode_jenisJual.Text,txt_id_motorJual.Text,
                                         txt_namamotorJual.Text, txt_statusJual.Text, dtp_tanggalJual.Value,txt_hargaJual.Text);

                    MessageBox.Show("Penambahan data baru berhasil", "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_idJual.Focus();
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

        public void Showtable()
        {
            dgv_dataJual.DataSource = rdsController.tampilmotorgabungan(new MySqlCommand("SELECT * FROM tampilmotorgabungan"));
            dgv_dataJual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void ShowtablePenjualan()
        {
            dgv_datapenjualanJual.DataSource = rdsController.riwayatPenjualan(new MySqlCommand("SELECT * FROM riwayat_penjualan"));
            dgv_datapenjualanJual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Penjualan_Load(object sender, EventArgs e)
        {
            txt_emailJual.MaxLength = 25;
            txt_hargaJual.MaxLength = 12;
            txt_idJual.MaxLength = 15;
            txt_id_motorJual.MaxLength = 1;
            txt_kode_jenisJual.MaxLength = 3;
            txt_namamotorJual.MaxLength = 25;
            txt_statusJual.MaxLength = 10;
        }
    }
}
