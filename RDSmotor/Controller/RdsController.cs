using MySqlConnector;
using RDSmotor.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace RDSmotor.Controller
{
    internal class RdsController : Model.Connection
    {
        private Connection connection = new Connection();

        public DataTable admin(MySqlCommand c)
        {
            DataTable data = new DataTable();
            try
            {
                string tampil = "SELECT * FROM aadmin";
                da = new MySqlConnector.MySqlDataAdapter(tampil, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        public void adminLOGRES(string email, string password)
        {
            string add = "INSERT INTO aadmin VALUES (" + "@email_admin ,@pasword)";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(add, GetConn());
                cmd.Parameters.Add("@email_admin", MySqlConnector.MySqlDbType.VarChar).Value = email;
                cmd.Parameters.Add("@pasword", MySqlConnector.MySqlDbType.VarChar).Value = password;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Date Failed!!" + ex.Message);
            }
        }

        //===============================================================================
        public DataTable tampilmotorgabungan(MySqlCommand c)
        {
            DataTable data = new DataTable();
            try
            {
                string tampil = "SELECT * FROM jenis_motor_gabungan";
                da = new MySqlConnector.MySqlDataAdapter(tampil, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        // ==============================================================================

        public DataTable showMatic(MySqlCommand c)
        {
            DataTable data = new DataTable();
            try
            {
                string show = "SELECT * FROM motor_matic";
                da = new MySqlConnector.MySqlDataAdapter(show, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        public void addMatic(string id_motor, string kode_jenis_motor, string nama_motor, string tipe_mesin, string tipe_rangka, string dimensi,
            string kapasitas_bahan_bakar, string harga, string status, byte[] gambar)
        {
            string addsup = "INSERT INTO motor_matic values(" + "@id_motor, @kode_jenis_motor, @nama_motor, @tipe_mesin, @tipe_rangka, @dimensi, @kapasitas_bahan_bakar, @harga, @status_motor, @gambar)";

            try
            {
                cmd = new MySqlConnector.MySqlCommand(addsup, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@nama_motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@tipe_mesin", MySqlConnector.MySqlDbType.VarChar).Value = tipe_mesin;
                cmd.Parameters.Add("@tipe_rangka", MySqlConnector.MySqlDbType.VarChar).Value = tipe_rangka;
                cmd.Parameters.Add("@dimensi", MySqlConnector.MySqlDbType.VarChar).Value = dimensi;
                cmd.Parameters.Add("@kapasitas_bahan_bakar", MySqlConnector.MySqlDbType.VarChar).Value = kapasitas_bahan_bakar;
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@status_motor", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@gambar", MySqlConnector.MySqlDbType.VarChar).Value = gambar;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tambah Motor Gagal" + ex.Message);
            }
        }

        public void updateMatic(string id_motor, string kode_jenis_motor, string nama_motor, string tipe_mesin, string tipe_rangka, string dimensi,
            string kapasitas_bahan_bakar, string harga, string status, byte[] gambar)
        {
            string update = "UPDATE motor_matic SET kode_jenis_motor = @kode_jenis_motor, nama_motor = @nama_motor, tipe_mesin = @tipe_mesin, tipe_rangka = @tipe_rangka," +
                "dimensi = @dimensi,kapasitas_bahan_bakar = @kapasitas_bahan_bakar, harga = @harga, status_motor = @status_motor, gambar = @gambar WHERE id_motor = @id_motor";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@nama_motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@tipe_mesin", MySqlConnector.MySqlDbType.VarChar).Value = tipe_mesin;
                cmd.Parameters.Add("@tipe_rangka", MySqlConnector.MySqlDbType.VarChar).Value = tipe_rangka;
                cmd.Parameters.Add("@dimensi", MySqlConnector.MySqlDbType.VarChar).Value = dimensi;
                cmd.Parameters.Add("@kapasitas_bahan_bakar", MySqlConnector.MySqlDbType.VarChar).Value = kapasitas_bahan_bakar;
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@status_motor", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@gambar", MySqlConnector.MySqlDbType.VarChar).Value = gambar;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Motor Gagal" + ex.Message);
            }
        }

        public void hapusMatic(string id_motor)
        {
            string hapus = "DELETE FROM motor_matic WHERE id_motor = @id_motor";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(hapus, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("delete Data Motor gagal" + ex.Message);
            }
        }

        // =========================================================================================================

        public DataTable showManual(MySqlCommand c)
        {
            DataTable data = new DataTable();
            try
            {
                string show = "SELECT * FROM motor_manual";
                da = new MySqlConnector.MySqlDataAdapter(show, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        public void addManual(string id_motor, string kode_jenis_motor, string nama_motor, string tipe_mesin, string tipe_rangka, string dimensi,
            string kapasitas_bahan_bakar, string harga, string status, byte[] gambar)
        {
            string addsup = "INSERT INTO motor_manual values(" + "@id_motor, @kode_jenis_motor, @nama_motor, @tipe_mesin, @tipe_rangka, @dimensi, @kapasitas_bahan_bakar, @harga, @status_motor, @gambar)";

            try
            {
                cmd = new MySqlConnector.MySqlCommand(addsup, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@nama_motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@tipe_mesin", MySqlConnector.MySqlDbType.VarChar).Value = tipe_mesin;
                cmd.Parameters.Add("@tipe_rangka", MySqlConnector.MySqlDbType.VarChar).Value = tipe_rangka;
                cmd.Parameters.Add("@dimensi", MySqlConnector.MySqlDbType.VarChar).Value = dimensi;
                cmd.Parameters.Add("@kapasitas_bahan_bakar", MySqlConnector.MySqlDbType.VarChar).Value = kapasitas_bahan_bakar;
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@status_motor", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@gambar", MySqlConnector.MySqlDbType.VarChar).Value = gambar;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tambah Motor Gagal" + ex.Message);
            }
        }

        public void updateManual(string id_motor, string kode_jenis_motor, string nama_motor, string tipe_mesin, string tipe_rangka, string dimensi,
            string kapasitas_bahan_bakar, string harga, string status, byte[] gambar)
        {
            string update = "UPDATE motor_manual SET kode_jenis_motor = @kode_jenis_motor, nama_motor = @nama_motor, tipe_mesin = @tipe_mesin, tipe_rangka = @tipe_rangka," +
                "dimensi = @dimensi,kapasitas_bahan_bakar = @kapasitas_bahan_bakar, harga = @harga, status_motor = @status_motor, gambar = @gambar WHERE id_motor = @id_motor";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@nama_motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@tipe_mesin", MySqlConnector.MySqlDbType.VarChar).Value = tipe_mesin;
                cmd.Parameters.Add("@tipe_rangka", MySqlConnector.MySqlDbType.VarChar).Value = tipe_rangka;
                cmd.Parameters.Add("@dimensi", MySqlConnector.MySqlDbType.VarChar).Value = dimensi;
                cmd.Parameters.Add("@kapasitas_bahan_bakar", MySqlConnector.MySqlDbType.VarChar).Value = kapasitas_bahan_bakar;
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@status_jenis", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@gambar", MySqlConnector.MySqlDbType.VarChar).Value = gambar;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Motor Gagal" + ex.Message);
            }
        }

        public void hapusManual(string id_motor)
        {
            string hapus = "DELETE FROM motor_manual WHERE id_motor = @id_motor";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(hapus, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("delete data motor gagal" + ex.Message);
            }
        }

        // =========================================================================================================

        public DataTable showKopling(MySqlCommand c)
        {
            DataTable data = new DataTable();
            try
            {
                string show = "SELECT * FROM motor_kopling";
                da = new MySqlConnector.MySqlDataAdapter(show, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        public void addKopling(string id_motor, string kode_jenis_motor, string nama_motor, string tipe_mesin, string tipe_rangka, string dimensi,
            string kapasitas_bahan_bakar, string harga, string status, byte[] gambar)
        {
            string addsup = "INSERT INTO motor_kopling values(" + "@id_motor, @kode_jenis_motor, @nama_motor, @tipe_mesin, @tipe_rangka, @dimensi, @kapasitas_bahan_bakar, @harga, @status_motor, @gambar)";

            try
            {
                cmd = new MySqlConnector.MySqlCommand(addsup, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@nama_motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@tipe_mesin", MySqlConnector.MySqlDbType.VarChar).Value = tipe_mesin;
                cmd.Parameters.Add("@tipe_rangka", MySqlConnector.MySqlDbType.VarChar).Value = tipe_rangka;
                cmd.Parameters.Add("@dimensi", MySqlConnector.MySqlDbType.VarChar).Value = dimensi;
                cmd.Parameters.Add("@kapasitas_bahan_bakar", MySqlConnector.MySqlDbType.VarChar).Value = kapasitas_bahan_bakar;
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@status_motor", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@gambar", MySqlConnector.MySqlDbType.VarChar).Value = gambar;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tambah Motor Gagal" + ex.Message);
            }
        }

        public void updateKopling(string id_motor, string kode_jenis_motor, string nama_motor, string tipe_mesin, string tipe_rangka, string dimensi,
            string kapasitas_bahan_bakar, string harga, string status, byte[] gambar)
        {
            string update = "UPDATE motor_kopling SET kode_jenis_motor = @kode_jenis_motor, nama_motor = @nama_motor, tipe_mesin = @tipe_mesin, tipe_rangka = @tipe_rangka," +
                "dimensi = @dimensi,kapasitas_bahan_bakar = @kapasitas_bahan_bakar, harga = @harga, status_motor = @status_motor, gambar = @gambar WHERE id_motor = @id_motor";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(update, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@nama_motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@tipe_mesin", MySqlConnector.MySqlDbType.VarChar).Value = tipe_mesin;
                cmd.Parameters.Add("@tipe_rangka", MySqlConnector.MySqlDbType.VarChar).Value = tipe_rangka;
                cmd.Parameters.Add("@dimensi", MySqlConnector.MySqlDbType.VarChar).Value = dimensi;
                cmd.Parameters.Add("@kapasitas_bahan_bakar", MySqlConnector.MySqlDbType.VarChar).Value = kapasitas_bahan_bakar;
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.Parameters.Add("@status_jenis", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@gambar", MySqlConnector.MySqlDbType.VarChar).Value = gambar;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Update motor Gagal" + ex.Message);
            }
        }

        public void hapusKopling(string id_motor)
        {
            string hapus = "DELETE FROM motor_kopling WHERE id_motor = @id_motor";
            try
            {
                cmd = new MySqlConnector.MySqlCommand(hapus, GetConn());
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("delete data motor gagal" + ex.Message);
            }
        }

        // =========================================================================================================


        public DataTable showPembelian(MySqlCommand c)
        {
            DataTable data = new DataTable();
            try
            {
                string show = "SELECT * FROM riwayat_pembelian";
                da = new MySqlConnector.MySqlDataAdapter(show, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        public void addPembelian(string id_pembelian, string email_admin, string kode_jenis_motor, string id_motor, string nama_motor, string status,
            DateTime tanggalbeli,string harga)
        {
            string addsup = "INSERT INTO pembelian values(" + "@id_pembelian, @email_admin, @kode_jenis_motor, @id_motor, @nama_motor, @status_motor, @tanggal_pembelian, @harga)";

            try
            {
                cmd = new MySqlConnector.MySqlCommand(addsup, GetConn());
                cmd.Parameters.Add("@id_pembelian", MySqlConnector.MySqlDbType.VarChar).Value = id_pembelian;
                cmd.Parameters.Add("@email_admin", MySqlConnector.MySqlDbType.VarChar).Value = email_admin;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@nama_motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@status_motor", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@tanggal_pembelian", MySqlConnector.MySqlDbType.DateTime).Value = tanggalbeli.ToString("yyyy-MM-dd");
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tambah Pembelian Gagal" + ex.Message);
            }
        }

        // =========================================================================================================

        public DataTable riwayatPenjualan(MySqlCommand c)
        {
            DataTable data = new DataTable();
            try
            {
                string tampil = "SELECT * FROM riwayat_penjualan";
                da = new MySqlConnector.MySqlDataAdapter(tampil, GetConn());
                da.Fill(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        public void addPenjualan(string id_penjualan, string email_admin, string kode_jenis_motor, string id_motor, string nama_motor,
            string status, DateTime tanggaljual, string harga)
        {
            string addsup = "INSERT INTO penjualan values(" + "@id_penjualan, @email_admin, @kode_jenis_motor, @id_motor, @nama_motor, @status_motor, @tanggal_penjualan, @harga)";

            try
            {
                cmd = new MySqlConnector.MySqlCommand(addsup, GetConn());
                cmd.Parameters.Add("@id_penjualan", MySqlConnector.MySqlDbType.VarChar).Value = id_penjualan;
                cmd.Parameters.Add("@email_admin", MySqlConnector.MySqlDbType.VarChar).Value = email_admin;
                cmd.Parameters.Add("@kode_jenis_motor", MySqlConnector.MySqlDbType.VarChar).Value = kode_jenis_motor;
                cmd.Parameters.Add("@id_motor", MySqlConnector.MySqlDbType.VarChar).Value = id_motor;
                cmd.Parameters.Add("@nama motor", MySqlConnector.MySqlDbType.VarChar).Value = nama_motor;
                cmd.Parameters.Add("@status_motor", MySqlConnector.MySqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@tanggal_penjualan", MySqlConnector.MySqlDbType.DateTime).Value = tanggaljual.ToString("yyyy-MM-dd"); ;
                cmd.Parameters.Add("@harga", MySqlConnector.MySqlDbType.VarChar).Value = harga;
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Tambah Penjualan Gagal" + ex.Message);
            }
        }

    }
}
