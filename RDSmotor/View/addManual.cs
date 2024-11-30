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
    public partial class addManual : Form
    {
        private RdsController rdsController;
        public addManual()
        {
            rdsController = new RdsController();
            InitializeComponent();
        }

        private void lbl_closeAddManual_Click(object sender, EventArgs e)
        {
            Manual manual = new Manual();
            manual.Show();
            this.Hide();
        }

        private void btn_uploadAddManual_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pb_uploadfotoAddManual.Image = Image.FromFile(opf.FileName);
        }

        private void btn_batalAddManual_Click(object sender, EventArgs e)
        {
            txt_id_motorAddManual.Clear();
            txt_namaAddManual.Clear();
            txt_tipe_mesinAddManual.Clear();
            txt_tipa_rangkaAddManual.Clear();
            txt_dimensiAddManual.Clear();
            txt_hargaAddManual.Clear();
            txt_bahanbakarAddManual.Clear();
            txt_ststusAddManual.Clear();
            txt_pilihjenisAddManual.Clear();
            pb_uploadfotoAddManual.Image = null;
        }

        bool verify()
        {
            if ((txt_id_motorAddManual.Text == "") || (txt_namaAddManual.Text == "") || (txt_tipe_mesinAddManual.Text == "") || (txt_tipa_rangkaAddManual.Text == "") ||
                (txt_dimensiAddManual.Text == "") || (txt_bahanbakarAddManual.Text == "") || (txt_hargaAddManual.Text == "") || (txt_ststusAddManual.Text == "") || (txt_pilihjenisAddManual.Text == "") || (pb_uploadfotoAddManual.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_tambahAddManual_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {
                    MemoryStream memori = new MemoryStream();
                    pb_uploadfotoAddManual.Image.Save(memori, pb_uploadfotoAddManual.Image.RawFormat);
                    byte[] img = memori.ToArray();

                    rdsController.addManual(txt_id_motorAddManual.Text, txt_pilihjenisAddManual.Text, txt_namaAddManual.Text, txt_tipe_mesinAddManual.Text, txt_tipa_rangkaAddManual.Text,
                                            txt_dimensiAddManual.Text, txt_bahanbakarAddManual.Text, txt_hargaAddManual.Text, txt_ststusAddManual.Text, img);

                    MessageBox.Show("Penambahan data baru berhasil", "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_id_motorAddManual.Focus();
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

        private void addManual_Load(object sender, EventArgs e)
        {
            txt_id_motorAddManual.MaxLength = 1;
            txt_bahanbakarAddManual.MaxLength = 2;
            txt_hargaAddManual.MaxLength = 12;
            txt_namaAddManual.MaxLength = 25;
            txt_pilihjenisAddManual.MaxLength = 3;
            txt_ststusAddManual.MaxLength = 10;
            txt_tipa_rangkaAddManual.MaxLength = 10;
            txt_tipe_mesinAddManual.MaxLength = 10;
        }
    }
}
