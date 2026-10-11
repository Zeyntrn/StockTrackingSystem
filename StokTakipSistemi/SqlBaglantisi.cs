using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi
{
    public class SqlBaglanti
    {
        private static SqlBaglanti _instance;
        private SqlConnection baglanti;
        private readonly string _connectionString = @"Data Source=DESKTOP-HB4GCHL\SQLEXPRESS02;Initial Catalog=stoktakipsistemi;Integrated Security=True;TrustServerCertificate=True";

        private SqlBaglanti()
        {
            baglanti = new SqlConnection(_connectionString);
        }

        public static SqlBaglanti Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SqlBaglanti();
                }
                return _instance;
            }
        }

        public SqlConnection GetConnection()
        {
            if (baglanti == null || baglanti.State == ConnectionState.Closed)
            {
                baglanti = new SqlConnection(_connectionString);
            }
            return baglanti;
        }

        public void OpenConnection()
        {
            try
            {
                if (baglanti.State == System.Data.ConnectionState.Closed)
                {
                    baglanti.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı açılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (baglanti.State == System.Data.ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı kapatılırken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
