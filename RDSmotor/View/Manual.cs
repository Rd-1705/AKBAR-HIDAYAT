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
    public partial class Manual : Form
    {
        private RdsController rdsController;
        public Manual()
        {
            rdsController = new RdsController();
            InitializeComponent();
            Showtable();
            manual();
        }

        private void lbl_closeManual_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }


        bool manual()
        {
            dgv_dataManual.DataSource = rdsController.showManual(new MySqlCommand("SELECT * FROM motor_manual"));
            dgv_dataManual.RowTemplate.Height = 80;
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn = (DataGridViewImageColumn)dgv_dataManual.Columns[9];
            imageColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;
            return true;
        }

        private void Manual_Load(object sender, EventArgs e)
        {
            manual();
        }

        private void dgv_dataManual_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_idManual.Text = dgv_dataManual.CurrentRow.Cells[0].Value.ToString();
            txt_nama_motorManual.Text = dgv_dataManual.CurrentRow.Cells[1].Value.ToString();
            txt_nama_jenis_motorManual.Text = dgv_dataManual.CurrentRow.Cells[2].Value.ToString();
            txt_hargaManual.Text = dgv_dataManual.CurrentRow.Cells[3].Value.ToString();
            txt_tipe_mesinManual.Text = dgv_dataManual.CurrentRow.Cells[4].Value.ToString();
            txt_tipe_rangkaManual.Text = dgv_dataManual.CurrentRow.Cells[5].Value.ToString();
            txt_bahan_bakarManual.Text = dgv_dataManual.CurrentRow.Cells[6].Value.ToString();
            byte[] img = (byte[])dgv_dataManual.CurrentRow.Cells[9].Value;
            MemoryStream foto = new MemoryStream(img);
            pb_foto_motorManual.Image = Image.FromStream(foto);
        }
        private void btn_addManual_Click(object sender, EventArgs e)
        {
            addManual manual = new addManual();
            manual.Show();
            this.Hide();
        }

        private void btn_updateManual_Click(object sender, EventArgs e)
        {
            updateManual manual = new updateManual();
            manual.Show();
            this.Hide();
        }

        public void Showtable()
        {
            dgv_dataManual.DataSource = rdsController.showManual(new MySqlCommand("SELECT * FROM motor_manual"));
            dgv_dataManual.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        bool verify()
        {
            if ((txt_idManual.Text == "") || (txt_nama_motorManual.Text == "") || (txt_nama_jenis_motorManual.Text == "") ||
               (txt_tipe_mesinManual.Text == "") || (txt_tipe_rangkaManual.Text == "") || (txt_bahan_bakarManual.Text == "")
               || (txt_hargaManual.Text == "") || (pb_foto_motorManual.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_clearManual_Click(object sender, EventArgs e)
        {
            txt_idManual.Clear();
            txt_nama_motorManual.Clear();
            txt_nama_jenis_motorManual.Clear();
            txt_tipe_mesinManual.Clear();
            txt_tipe_rangkaManual.Clear();
            txt_hargaManual.Clear();
            txt_bahan_bakarManual.Clear();
            pb_foto_motorManual.Image = null;
        }

        private void btn_deleteManual_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {
                    rdsController.hapusMatic(txt_idManual.Text);
                    Showtable();
                    btn_deleteManual.PerformClick();
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
                MessageBox.Show("Error_motor not delete", "delete motor",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_maticManual_Click(object sender, EventArgs e)
        {
            Matic matic = new Matic();
            matic.Show();
            this.Hide();
        }

        private void llbl_logregManual_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }

        private void btn_manualManual_Click(object sender, EventArgs e)
        {
            Manual manual = new Manual();
            manual.Show();
            this.Hide();
        }

        private void btn_koplingManual_Click(object sender, EventArgs e)
        {
            Kopling kopling = new Kopling();
            kopling.Show();
            this.Hide();

        }

        private void btn_belManual_Click(object sender, EventArgs e)
        {
            Pembelian pembelian = new Pembelian();
            pembelian.Show();
            this.Hide();
        }

        private void btn_jualManual_Click(object sender, EventArgs e)
        {
            Penjualan jual = new Penjualan();
            jual.Show();
            this.Hide();
        }
    }
}
