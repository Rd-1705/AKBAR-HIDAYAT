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
    public partial class updeteKopling : Form
    {
        private  RdsController rdsController;

        public updeteKopling()
        {
            InitializeComponent();
            rdsController = new RdsController();
        }

        private void lbl_closeUpdateKopling_Click(object sender, EventArgs e)
        {
            Kopling kopling = new Kopling();
            kopling.Show();
            this.Hide();
        }

        private void btn_updateUpdateKopling_Click(object sender, EventArgs e)
        {
            MemoryStream memori = new MemoryStream();
            pb_uploadfotoUpdateKopling.Image.Save(memori, pb_uploadfotoUpdateKopling.Image.RawFormat);
            byte[] img = memori.ToArray();

            rdsController = new RdsController();
            rdsController.updateKopling(txt_id_motorUpdateKopling.Text, txt_pilihjenisUpdeteKopling.Text, txt_namaUpdateKopling.Text, txt_tipe_mesinUpdateKopling.Text, txt_tipa_rangkaUpdateKopling.Text,
                                      txt_dimensiUpdateKopling.Text, txt_bahanbakarUpdateKopling.Text, txt_hargaUpdateKopling.Text, txt_statusUpdateKopling.Text, img);
            this.Controls.Clear();
            this.InitializeComponent();
            txt_id_motorUpdateKopling.Focus();
            MessageBox.Show("Data berhasil di update");

            Matic matic = new Matic();
            matic.Show();
            this.Hide();
        }

        private void btn_uploadUpdateKopling_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pb_uploadfotoUpdateKopling.Image = Image.FromFile(opf.FileName);
        }

        private void btn_batalUpdateKopling_Click(object sender, EventArgs e)
        {
            txt_id_motorUpdateKopling.Clear();
            txt_namaUpdateKopling.Clear();
            txt_tipe_mesinUpdateKopling.Clear();
            txt_tipa_rangkaUpdateKopling.Clear();
            txt_dimensiUpdateKopling.Clear();
            txt_hargaUpdateKopling.Clear();
            txt_bahanbakarUpdateKopling.Clear();
            txt_statusUpdateKopling.Clear();
            txt_pilihjenisUpdeteKopling.Clear();
            pb_uploadfotoUpdateKopling.Image = null;
        }

        private void updeteKopling_Load(object sender, EventArgs e)
        {
            txt_id_motorUpdateKopling.MaxLength = 1;
            txt_bahanbakarUpdateKopling.MaxLength = 2;
            txt_hargaUpdateKopling.MaxLength = 12;
            txt_namaUpdateKopling.MaxLength = 25;
            txt_pilihjenisUpdeteKopling.MaxLength = 3;
            txt_statusUpdateKopling.MaxLength = 10;
            txt_tipa_rangkaUpdateKopling.MaxLength = 10;
            txt_tipe_mesinUpdateKopling.MaxLength = 10;
        }
    }
}
