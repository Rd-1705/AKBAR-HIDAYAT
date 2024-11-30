using Guna.UI2.AnimatorNS;
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
    public partial class Matic : Form
    {
        private RdsController rdsController;
        public Matic()
        {
            InitializeComponent();
            rdsController = new RdsController();
            Showtable();
            matic();
        }

        private void btn_addMatic_Click(object sender, EventArgs e)
        {
           addMatic addMatic = new addMatic();
            addMatic.Show();
            this.Hide();
        }

        bool matic()
        {
            dgv_dataMatic.DataSource = rdsController.showMatic(new MySqlCommand("SELECT * FROM motor_matic"));
            dgv_dataMatic.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dgv_dataMatic.Columns[9];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            return true;
        }

        private void Matic_Load(object sender, EventArgs e)
        {
            matic();
        }

        private void btn_updateMatic_Click(object sender, EventArgs e)
        {
            updateMatic updateMatic = new updateMatic();
            updateMatic.Show();
            this.Hide();

            
        }

        private void lbl_closeMatic_Click_2(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        public void Showtable()
        {
            dgv_dataMatic.DataSource = rdsController.showMatic(new MySqlCommand("SELECT * FROM motor_matic"));
            dgv_dataMatic.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        bool verify()
        {
            if ((txt_idMatic.Text == "") || (txt_nama_motorMatic.Text == "") || (txt_nama_jenis_motorMatic.Text == "") ||
               (txt_tipe_mesinMatic.Text == "") || (txt_tipe_rangkaMatic.Text == "") || (txt_bahan_bakarMatic.Text == "")
               || (txt_hargaMatic.Text == "") || (pb_foto_motorMatic.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void btn_deleteMatic_Click(object sender, EventArgs e)
        {
            if (verify())

            {
                try
                {
                    rdsController.hapusMatic(txt_idMatic.Text);
                    Showtable();
                    btn_deleteMatic.PerformClick();
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

        private void btn_clearMatic_Click(object sender, EventArgs e)
        {
            txt_idMatic.Clear();
            txt_nama_motorMatic.Clear();
            txt_nama_jenis_motorMatic.Clear();
            txt_tipe_mesinMatic.Clear();
            txt_tipe_rangkaMatic.Clear();
            txt_hargaMatic.Clear();
            txt_bahan_bakarMatic.Clear();
            pb_foto_motorMatic.Image = null; 
        }

        private void btn_manualMatic_Click(object sender, EventArgs e)
        {
            Manual manual = new Manual();
            manual.Show();
            this.Hide();
        }

        private void llbl_logregMatic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dgv_dataMatic_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idMatic.Text = dgv_dataMatic.CurrentRow.Cells[0].Value.ToString();
            txt_nama_motorMatic.Text = dgv_dataMatic.CurrentRow.Cells[1].Value.ToString();
            txt_nama_jenis_motorMatic.Text = dgv_dataMatic.CurrentRow.Cells[2].Value.ToString();
            txt_hargaMatic.Text = dgv_dataMatic.CurrentRow.Cells[3].Value.ToString();
            txt_tipe_mesinMatic.Text = dgv_dataMatic.CurrentRow.Cells[4].Value.ToString();
            txt_tipe_rangkaMatic.Text = dgv_dataMatic.CurrentRow.Cells[5].Value.ToString();
            txt_bahan_bakarMatic.Text = dgv_dataMatic.CurrentRow.Cells[6].Value.ToString();
            byte[] img = (byte[])dgv_dataMatic.CurrentRow.Cells[9].Value;
            MemoryStream foto = new MemoryStream(img);
            pb_foto_motorMatic.Image = Image.FromStream(foto);
        }

        private void btn_koplingMatic_Click(object sender, EventArgs e)
        {
            Kopling kopling = new Kopling();
            kopling.Show();
            this.Hide();
        }

        private void btn_beliMatic_Click(object sender, EventArgs e)
        {
            Pembelian pembelian = new Pembelian();
            pembelian.Show();
            this.Hide();
        }

        private void btn_jualMatic_Click(object sender, EventArgs e)
        {
            Penjualan penjualan = new Penjualan();
            penjualan.Show();
            this.Hide();
        }
    }
}
