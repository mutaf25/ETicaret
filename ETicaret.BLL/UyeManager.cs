using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;


namespace ETicaret.BLL
{
   public class UyeManager
    {
        Repository<Uyeler> repUye = new Repository<Uyeler>();

        public void UyeKaydet(string Uye_Adi,string Uye_Soyadi,DateTime Kayit_Tarihi,string E_Mail,string Telefon,DateTime? Dogum_Tarihi,string Cinsiyet,string Medeni_Hali,string Meslek,string Kullanici_Adi,string Kullanici_Sifre)
        {
            int ekle = repUye.insert(new Uyeler()
            {
                UyeAdi=Uye_Adi, UyeSoyadi=Uye_Soyadi,
                KayitTarihi=Kayit_Tarihi,DogumTarihi=Dogum_Tarihi,
                EMail=E_Mail,Telefon=Telefon,Cinsiyet=Cinsiyet,
                MedeniHali =Medeni_Hali,Meslek=Meslek,KullaniciAdi=Kullanici_Adi,
                KullaniciSifre =Kullanici_Sifre
            });
        }
        public void UyeGuncelle(int Uyeler_Id,string Uye_Adi, string Uye_Soyadi, DateTime Kayit_Tarihi, string E_Mail, string Telefon, DateTime Dogum_Tarihi, string Cinsiyet, string Medeni_Hali, string Meslek, string Kullanici_Adi, string Kullanici_Sifre)
        {
            Uyeler upt = repUye.VeriBul(g => g.UyelerID == Uyeler_Id);
            //var upt1 = repUye.ListeFiltre(k => k.UyelerID == Uyeler_Id).FirstOrDefault();
            if (upt!=null)
            {
                //
            }



        }


        public Uyeler UyeGiris(string k_Adi,string k_Sifre)
        {
            Uyeler Giris = repUye.VeriBul(k => (k.KullaniciAdi == k_Adi || k.EMail == k_Adi) && k.KullaniciSifre == k_Sifre);

            if (Giris!=null)
            {
                return Giris;
            }
            return Giris;

        }

    }
}
