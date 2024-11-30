using Guna.UI2.WinForms;
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
    public partial class addMatic : Form
    {
        private RdsController rdsController;
        public addMatic()
        {
            InitializeComponent();
            rdsController = new RdsController();
        }

        private void btn_uploadAddMatic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pb_uploadfotoAddMatic.Image = Image.FromFile(opf.FileName);
        }

        private void btn_batalAddMatic_Click(object sender, EventArgs e)
        {
            txt_id_motorAddMatic.Clear();
            txt_namaAddMatic.Clear();
            txt_tipe_mesinAddMatic.Clear();
            txt_tipa_rangkaAddMatic.Clear();
            txt_dimensiAddMatic.Clear();
            txt_hargaAddMatic.Clear();
            txt_bahanbakarAddMatic.Clear();
            txt_statusAddMatic.Clear();
            txt_pilihjenisAddMatic.Clear();
            pb_uploadfotoAddMatic.Image = null;

        }

        bool verify()
        {
            if ((txt_id_motorAddMatic.Text == "") || (txt_namaAddMatic.Text == "") || (txt_tipe_mesinAddMatic.Text == "") || (txt_tipa_rangkaAddMatic.Text == "") ||
                (txt_dimensiAddMatic.Text == "") || (txt_bahanbakarAddMatic.Text == "") || (txt_hargaAddMatic.Text == "") || (txt_statusAddMatic.Text == "") || (txt_pilihjenisAddMatic.Text == "") || (pb_uploadfotoAddMatic.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_tambahAddMatic_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {
                    MemoryStream memori = new MemoryStream();
                    pb_uploadfotoAddMatic.Image.Save(memori, pb_uploadfotoAddMatic.Image.RawFormat);
                    byte[] img = memori.ToArray();

                    // Panggil addMatic
                    rdsController.addMatic(txt_id_motorAddMatic.Text, txt_pilihjenisAddMatic.Text, txt_namaAddMatic.Text, txt_tipe_mesinAddMatic.Text, txt_tipa_rangkaAddMatic.Text,
                                            txt_dimensiAddMatic.Text, txt_bahanbakarAddMatic.Text, txt_hargaAddMatic.Text, txt_statusAddMatic.Text, img );

                    MessageBox.Show("Penambahan data baru berhasil", "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_id_motorAddMatic.Focus();
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

        private void lbl_closeAddMatic_Click(object sender, EventArgs e)
        {
            Matic mt = new Matic();
            mt.Show();
            this.Hide();
        }

        private void addMatic_Load(object sender, EventArgs e)
        {
            txt_id_motorAddMatic.MaxLength = 1;
            txt_bahanbakarAddMatic.MaxLength = 2;
            txt_hargaAddMatic.MaxLength = 12;
            txt_namaAddMatic.MaxLength = 25;
            txt_pilihjenisAddMatic.MaxLength = 3;
            txt_statusAddMatic.MaxLength = 10;
            txt_tipa_rangkaAddMatic.MaxLength = 10;
            txt_tipe_mesinAddMatic.MaxLength = 10;
        }
    }
}
