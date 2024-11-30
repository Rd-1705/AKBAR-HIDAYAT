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
    public partial class addKopling : Form
    {
        private RdsController rdsController;
        public addKopling()
        {
            InitializeComponent();
            rdsController = new RdsController();
        }

        private void lbl_closeAddKopling_Click(object sender, EventArgs e)
        {
            Kopling kopling = new Kopling();
            kopling.Show();
            this.Hide();
        }

        private void btn_uploadAddKopling_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pb_uploadfotoAddKopling.Image = Image.FromFile(opf.FileName);
        }

        private void btn_batalAddKopling_Click(object sender, EventArgs e)
        {
            txt_id_motorAddKopling.Clear();
            txt_namaAddKopling.Clear();
            txt_tipe_mesinAddKopling.Clear();
            txt_tipa_rangkaAddKopling.Clear();
            txt_dimensiAddKopling.Clear();
            txt_hargaAddKopling.Clear();
            txt_bahanbakarAddKopling.Clear();
            txt_statusAddKopling.Clear();
            txt_pilihjenisAddKopling.Clear();
            pb_uploadfotoAddKopling.Image = null;
        }

        bool verify()
        {
            if ((txt_id_motorAddKopling.Text == "") || (txt_namaAddKopling.Text == "") || (txt_tipe_mesinAddKopling.Text == "") || (txt_tipa_rangkaAddKopling.Text == "") ||(txt_dimensiAddKopling.Text == "") ||
                (txt_bahanbakarAddKopling.Text == "") || (txt_hargaAddKopling.Text == "") || (txt_statusAddKopling.Text == "") || (txt_pilihjenisAddKopling.Text == "") || (pb_uploadfotoAddKopling.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btn_tambahAddKopling_Click(object sender, EventArgs e)
        {
            if (verify())
            {
                try
                {
                    MemoryStream memori = new MemoryStream();
                    pb_uploadfotoAddKopling.Image.Save(memori, pb_uploadfotoAddKopling.Image.RawFormat);
                    byte[] img = memori.ToArray();

                    // Panggil addMatic
                    rdsController.addKopling(txt_id_motorAddKopling.Text, txt_pilihjenisAddKopling.Text, txt_namaAddKopling.Text, txt_tipe_mesinAddKopling.Text, txt_tipa_rangkaAddKopling.Text,
                                            txt_dimensiAddKopling.Text, txt_bahanbakarAddKopling.Text, txt_hargaAddKopling.Text, txt_statusAddKopling.Text, img);

                    MessageBox.Show("Penambahan data baru berhasil", "Simpan data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txt_id_motorAddKopling.Focus();
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

       
        private void addKopling_Load_1(object sender, EventArgs e)
        {
            txt_id_motorAddKopling.MaxLength = 1;
            txt_bahanbakarAddKopling.MaxLength = 2;
            txt_hargaAddKopling.MaxLength = 12;
            txt_namaAddKopling.MaxLength = 25;
            txt_pilihjenisAddKopling.MaxLength = 3;
            txt_statusAddKopling.MaxLength = 10;
            txt_tipa_rangkaAddKopling.MaxLength = 10;
            txt_tipe_mesinAddKopling.MaxLength= 10;
        }
    }
}
