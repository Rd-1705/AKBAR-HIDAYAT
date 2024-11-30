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
    public partial class updateMatic : Form
    {
        RdsController rdsController;
        public updateMatic()
        {
            InitializeComponent();
            rdsController = new RdsController();   
        }

        private void btn_updateUpdateMatic_Click(object sender, EventArgs e)
        {
            MemoryStream memori = new MemoryStream();
            pb_uploadfotoUpdateMatic.Image.Save(memori, pb_uploadfotoUpdateMatic.Image.RawFormat);
            byte[] img = memori.ToArray();

            rdsController = new RdsController();
            rdsController.updateMatic(txt_id_motorUpdateMatic.Text, txt_pilihjenisUpdeteMatic.Text, txt_namaUpdateMatic.Text, txt_tipe_mesinUpdateMatic.Text, txt_tipa_rangkaUpdateMatic.Text,
                                      txt_dimensiUpdateMatic.Text, txt_bahanbakarUpdateMatic.Text, txt_hargaUpdateMatic.Text, txt_statusUpdateMatic.Text, img);
            this.Controls.Clear();
            this.InitializeComponent();
            txt_id_motorUpdateMatic.Focus();
            MessageBox.Show("Data berhasil di update");
            
            Matic matic = new Matic();
            matic.Show();
            this.Hide();

        }

        private void btn_uploadUpdateMatic_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";


            if (opf.ShowDialog() == DialogResult.OK)
                pb_uploadfotoUpdateMatic.Image = Image.FromFile(opf.FileName);
        }

        private void lbl_closeUpdateMatic_Click(object sender, EventArgs e)
        {
            Matic matic = new Matic();
            matic.Show();
            this.Hide();
        }

        private void btn_batalUpdateMatic_Click(object sender, EventArgs e)
        {
            txt_id_motorUpdateMatic.Clear();
            txt_namaUpdateMatic.Clear();
            txt_tipe_mesinUpdateMatic.Clear();
            txt_tipa_rangkaUpdateMatic.Clear();
            txt_dimensiUpdateMatic.Clear();
            txt_hargaUpdateMatic.Clear();
            txt_bahanbakarUpdateMatic.Clear();
            txt_statusUpdateMatic.Clear();
            txt_pilihjenisUpdeteMatic.Clear();
            pb_uploadfotoUpdateMatic.Image = null;

        }

        private void updateMatic_Load(object sender, EventArgs e)
        {
            txt_id_motorUpdateMatic.MaxLength = 1;
            txt_bahanbakarUpdateMatic.MaxLength = 2;
            txt_hargaUpdateMatic.MaxLength = 12;
            txt_namaUpdateMatic.MaxLength = 25;
            txt_pilihjenisUpdeteMatic.MaxLength = 3;
            txt_statusUpdateMatic.MaxLength = 10;
            txt_tipa_rangkaUpdateMatic.MaxLength = 10;
            txt_tipe_mesinUpdateMatic.MaxLength = 10;
        }
    }
}
