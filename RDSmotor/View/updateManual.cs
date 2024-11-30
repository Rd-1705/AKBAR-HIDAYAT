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
    public partial class updateManual : Form
    {
        RdsController rdsController;
        public updateManual()
        {
            InitializeComponent();
            rdsController = new RdsController();
        }

        private void lbl_closeUpdateManual_Click(object sender, EventArgs e)
        {
            Manual manual = new Manual();
            manual.Show();
            this.Hide();
        }

        private void btn_uploadUpdateManual_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pb_uploadfotoUpdateManual.Image = Image.FromFile(opf.FileName);
        }

        private void btn_updateUpdateManual_Click(object sender, EventArgs e)
        {
            MemoryStream memori = new MemoryStream();
            pb_uploadfotoUpdateManual.Image.Save(memori, pb_uploadfotoUpdateManual.Image.RawFormat);
            byte[] img = memori.ToArray();

            rdsController = new RdsController();
            rdsController.updateManual(txt_id_motorUpdateManual.Text, txt_pilihjenisUpdeteManual.Text, txt_namaUpdateManual.Text, txt_tipe_mesinUpdateManual.Text, txt_tipa_rangkaUpdateManual.Text,
                                      txt_dimensiUpdateManual.Text, txt_bahanbakarUpdateManual.Text, txt_hargaUpdateManual.Text, txt_statusUpdateManual.Text, img);
            this.Controls.Clear();
            this.InitializeComponent();
            txt_id_motorUpdateManual.Focus();
            MessageBox.Show("Data berhasil di update");

            Manual manual = new Manual();
            manual.Show();
            this.Hide();
        }

        private void btn_batalUpdateManual_Click(object sender, EventArgs e)
        {
            txt_id_motorUpdateManual.Clear();
            txt_namaUpdateManual.Clear();
            txt_tipe_mesinUpdateManual.Clear();
            txt_tipa_rangkaUpdateManual.Clear();
            txt_dimensiUpdateManual.Clear();
            txt_hargaUpdateManual.Clear();
            txt_bahanbakarUpdateManual.Clear();
            txt_statusUpdateManual.Clear();
            txt_pilihjenisUpdeteManual.Clear();
            pb_uploadfotoUpdateManual.Image = null;
        }

        private void updateManual_Load(object sender, EventArgs e)
        {
            txt_id_motorUpdateManual.MaxLength = 1;
            txt_bahanbakarUpdateManual.MaxLength = 2;
            txt_hargaUpdateManual.MaxLength = 12;
            txt_namaUpdateManual.MaxLength = 25;
            txt_pilihjenisUpdeteManual.MaxLength = 3;
            txt_statusUpdateManual.MaxLength = 10;
            txt_tipa_rangkaUpdateManual.MaxLength = 10;
            txt_tipe_mesinUpdateManual.MaxLength = 10;
        }
    }
}
