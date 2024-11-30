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
    public partial class Kopling : Form
    {
        RdsController rdsController;
        public Kopling()
        {
            InitializeComponent();
            rdsController = new RdsController();
            Showtable();
            kopling();
        }

        private void lbl_closeKopling_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        bool kopling()
        {
            dgv_dataKopling.DataSource = rdsController.showKopling(new MySqlCommand("SELECT * FROM motor_kopling"));
            dgv_dataKopling.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dgv_dataKopling.Columns[9];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            return true;
        }

        private void Kopling_Load(object sender, EventArgs e)
        {
            kopling();
        }

        public void Showtable()
        {
            dgv_dataKopling.DataSource = rdsController.showKopling(new MySqlCommand("SELECT * FROM motor_kopling"));
            dgv_dataKopling.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        bool verify()
        {
            if ((txt_idKopling.Text == "") || (txt_nama_motorKopling.Text == "") || (txt_nama_jenis_motorKopling.Text == "") ||
               (txt_tipe_mesinKopling.Text == "") || (txt_tipe_rangkaKopling.Text == "") || (txt_bahan_bakarKopling.Text == "")
               || (txt_hargaKopling.Text == "") || (pb_foto_motorKopling.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private void btn_clearKopling_Click(object sender, EventArgs e)
        {
            txt_idKopling.Clear();
            txt_nama_motorKopling.Clear();
            txt_nama_jenis_motorKopling.Clear();
            txt_tipe_mesinKopling.Clear();
            txt_tipe_rangkaKopling.Clear();
            txt_hargaKopling.Clear();
            txt_bahan_bakarKopling.Clear();
            pb_foto_motorKopling.Image = null;
        }

        private void btn_deleteKopling_Click(object sender, EventArgs e)
        {
            if (verify())

            {
                try
                {
                    rdsController.hapusKopling(txt_idKopling.Text);
                    Showtable();
                    btn_deleteKopling.PerformClick();
                    MessageBox.Show("Motor delete succesfully", "delete motor",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error_Motor not delete", "delete motor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void llbl_logregKopling_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dgv_dataKopling_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idKopling.Text = dgv_dataKopling.CurrentRow.Cells[0].Value.ToString();
            txt_nama_motorKopling.Text = dgv_dataKopling.CurrentRow.Cells[1].Value.ToString();
            txt_nama_jenis_motorKopling.Text = dgv_dataKopling.CurrentRow.Cells[2].Value.ToString();
            txt_hargaKopling.Text = dgv_dataKopling.CurrentRow.Cells[3].Value.ToString();
            txt_tipe_mesinKopling.Text = dgv_dataKopling.CurrentRow.Cells[4].Value.ToString();
            txt_tipe_rangkaKopling.Text = dgv_dataKopling.CurrentRow.Cells[5].Value.ToString();
            txt_bahan_bakarKopling.Text = dgv_dataKopling.CurrentRow.Cells[6].Value.ToString();
            byte[] img = (byte[])dgv_dataKopling.CurrentRow.Cells[9].Value;
            MemoryStream foto = new MemoryStream(img);
            pb_foto_motorKopling.Image = Image.FromStream(foto);
        }

        private void btn_addKopling_Click(object sender, EventArgs e)
        {
            addKopling addKopling = new addKopling();
            addKopling.Show();
            this.Hide();
        }

        private void btn_updateKopling_Click(object sender, EventArgs e)
        {
            updeteKopling updeteKopling = new updeteKopling();
            updeteKopling.Show();
            this.Hide();
        }

        private void btn_manualKopling_Click(object sender, EventArgs e)
        {
            Manual manualKopling = new Manual();
            manualKopling.Show();
            this.Hide();
        }

        private void btn_maticKopling_Click(object sender, EventArgs e)
        {
            Matic maticKopling = new Matic();
            maticKopling.Show();
            this.Hide();
        }

        private void btn_beliKopling_Click(object sender, EventArgs e)
        {
            Pembelian beli = new Pembelian();
            beli.Show();
            this.Hide();
        }

        private void btn_jualKopling_Click(object sender, EventArgs e)
        {
            Penjualan jual = new Penjualan();
            jual.Show();
            this.Hide();
        }
    }
}
