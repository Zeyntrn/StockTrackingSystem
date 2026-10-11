
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System.Data;




namespace StokTakipSistemi
{
    
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            
            // SqlBaglanti sýnýfýný kullanarak veritabaný baðlantýsýný baþlatýyoruz
            var sqlBaglanti = SqlBaglanti.Instance;

            if (!TestDatabaseConnection(sqlBaglanti))
            {
                Console.WriteLine("Veritabanýna baðlanýlamadý. Loglar veritabanýna yazýlamaz.");
                return;
            }

            var sinkOptions = new MSSqlServerSinkOptions
            {
                TableName = "Loglar",
                AutoCreateSqlTable = false
            };

            // Serilog yapýlandýrmasý
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.MSSqlServer(
                    connectionString: sqlBaglanti.GetConnection().ConnectionString,
                    sinkOptions: sinkOptions
                )
                .MinimumLevel.Information()
                .CreateLogger();

            // Serilog hata loglama
            Serilog.Debugging.SelfLog.Enable(msg =>
            {
                Console.WriteLine($"Serilog Hatasý: {msg}");
                System.IO.File.AppendAllText("selflog.txt", $"{msg}{Environment.NewLine}");
            });

            try
            {
                ApplicationConfiguration.Initialize();
                Log.Information("Uygulama baþlatýlýyor...");

                Log.Information("Uygulama baþarýlý bir þekilde baþlatýldý.");

                Application.Run(new KullaniciGiris());
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Uygulama baþlatýlamadý!");
                throw;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static bool TestDatabaseConnection(SqlBaglanti sqlBaglanti)
        {
            try
            {
                sqlBaglanti.OpenConnection();
                // Baðlantý baþarýlý ise
                sqlBaglanti.CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Veritabanýna baðlanýrken hata oluþtu: {ex.Message}");
                return false;
            }
        }

     }
}