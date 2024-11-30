using Guna.UI2.AnimatorNS;
using Guna.UI2.WinForms;
using MySqlConnector;
using RDSmotor.Controller;
using RDSmotor.View;
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

namespace RDSmotor
{
    public partial class Home : Form
    {
        private RdsController rdsController;
        public Home()
        {
            InitializeComponent();
            rdsController = new RdsController();
            Showtable();
        }

        public void Showtable()
        {
            dgv_dataHome.DataSource = rdsController.tampilmotorgabungan(new MySqlCommand("SELECT * FORM jenis_motor_gabungan"));
            dgv_dataHome.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void dgv_dataHome_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_nama_motorHome.Text = dgv_dataHome.CurrentRow.Cells[1].Value.ToString();
            txt_nama_jenis_motorHome.Text = dgv_dataHome.CurrentRow.Cells[2].Value.ToString();
            txt_hargaHome.Text = dgv_dataHome.CurrentRow.Cells[3].Value.ToString();
            txt_tipe_mesinHome.Text = dgv_dataHome.CurrentRow.Cells[4].Value.ToString();
            txt_tipe_rangkaHome.Text = dgv_dataHome.CurrentRow.Cells[5].Value.ToString();
            txt_bahan_bakarHome.Text = dgv_dataHome.CurrentRow.Cells[6].Value.ToString();
            byte[] img = (byte[])dgv_dataHome.CurrentRow.Cells[9].Value;
            MemoryStream foto = new MemoryStream(img);
            pb_foto_motorHome.Image = Image.FromStream(foto);

        }

        private void Home_Load(object sender, EventArgs e)
        {
            Showtable();
        }

        private void lbl_closeHome_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_maticHome_Click(object sender, EventArgs e)
        {
            Matic matic = new Matic();
            matic.Show();
            this.Hide();
        }

        private void btn_manualHome_Click(object sender, EventArgs e)
        {
            Manual manual = new Manual();
            manual.Show();
            this.Hide();
        }

        private void llbl_logregHome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btn_koplingHome_Click(object sender, EventArgs e)
        {
            Kopling kopling = new Kopling();
            kopling.Show();
            this.Hide();
        }

        private void btn_beliHome_Click(object sender, EventArgs e)
        {
            Pembelian beli = new Pembelian();
            beli.Show();
            this.Hide();
        }

        private void btn_jualHome_Click(object sender, EventArgs e)
        {
            Penjualan jual = new Penjualan();
            jual.Show();
            this.Hide();
        }
    }
}
