using MySqlConnector;
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
    public partial class Pembelian : Form
    {
        RdsController rdsController;
        public Pembelian()
        {
            InitializeComponent();
            rdsController = new RdsController();
            Showtable();
            ShowtablePembelian();
        }

        private void lbl_closeBeli_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void btn_jualBeli_Click(object sender, EventArgs e)
        {
            Penjualan jual = new Penjualan();
            jual.Show();
            this.Hide();
        }

        private void llbl_logregBeli_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btn_ClearBeli_Click(object sender, EventArgs e)
        {
            txt_emailBeli.Clear();
            txt_hargaBeli.Clear();
            txt_idBeli.Clear();
            txt_id_motorBeli.Clear();
            txt_kode_jenisBeli.Clear();
            txt_statusBeli.Clear();
            dtp_tanggalBeli.Value = DateTime.Now;

        }

        bool verify()
        {
            if ((txt_idBeli.Text == "") || (txt_emailBeli.Text == "") || (txt_kode_jenisBeli.Text == "") ||(txt_id_motorBeli.Text == "") ||
                (txt_namamotorBeli.Text == "") || (txt_statusBeli.Text == "") ||  (dtp_tanggalBeli.Value > DateTime.Now) || (txt_hargaBeli.Text == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_addBeli_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {

                    rdsController.addPembelian(txt_idBeli.Text, txt_emailBeli.Text, txt_kode_jenisBeli.Text,txt_id_motorBeli.Text, 
                                         txt_namamotorBeli.Text, txt_statusBeli.Text, dtp_tanggalBeli.Value, txt_hargaBeli.Text);

                    MessageBox.Show("Penambahan data baru berhasil", "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_idBeli.Focus();
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
            dgv_dataBeli.DataSource = rdsController.tampilmotorgabungan(new MySqlCommand("SELECT * FROM tampilmotorgabungan"));
            dgv_dataBeli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void ShowtablePembelian()
        {
            dgv_datapembelianBeli.DataSource = rdsController.showPembelian(new MySqlCommand("SELECT * FROM pembelian"));
            dgv_datapembelianBeli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Pembelian_Load(object sender, EventArgs e)
        {
            txt_emailBeli.MaxLength = 25;
            txt_hargaBeli.MaxLength = 12;
            txt_idBeli.MaxLength = 15;
            txt_id_motorBeli.MaxLength = 1;
            txt_kode_jenisBeli.MaxLength = 3;
            txt_namamotorBeli.MaxLength = 25;
            txt_statusBeli.MaxLength = 10;
        }
    }
}
