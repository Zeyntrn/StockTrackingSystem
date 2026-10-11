using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi
{
    public class KullaniciYetkileri
    {
        public string KullaniciTuru { get; private set; }

        public KullaniciYetkileri(string kullaniciTuru)
        {
            KullaniciTuru = kullaniciTuru;
        }

        // Buton yetkilerini yönetme
        public bool YetkiKontrol(string butonAdi)
        {
            if (KullaniciTuru == "Yönetici")
            {
                return true; // Yönetici her butona erişebilir
            }
            else if (KullaniciTuru == "Personel")
            {
                // Personelin erişebileceği butonlar burada tanımlanabilir
                if (butonAdi == "btnKategoriler" || butonAdi == "btnUrunler" || butonAdi == "btnStoklar" || butonAdi == "btnSatislar")
                {
                    return true; // Personel bu butonlara erişebilir
                }
                return false; // Diğer butonlara erişemez
            }
            else
            {
                return false; // Varsayılan olarak erişim yok
            }
        }
    }
}

