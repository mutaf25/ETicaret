using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
   public  class UrunYorumlariManager
    {
        Repository<Yorumlar> repYorumlar = new Repository<Yorumlar>();

        public void YorumKaydet(int uye_ID,int Urun_ID,string Yorum_Basligi,string Yorum_Metni,int Yorum_stars,DateTime Yorum_Tarihi,int Begenme_Sayisi,int Begenmeme_Sayisi)
        {
            int ekle = repYorumlar.insert(new Yorumlar() {
                UyeID = uye_ID,
                UrunID = Urun_ID,
                YorumBasligi = Yorum_Basligi,
                YorumMetni = Yorum_Metni,
                Star = Yorum_stars,
                Tarihi = Yorum_Tarihi,
                BegenmeSayisi = Begenme_Sayisi,
                BegenmemeSayisi = Begenmeme_Sayisi,
                OnayDurumu = false

            });
        }


        public List<Yorumlar> Liste(int urunlerID)
        {

            //return repYorumlar.ListeFiltre(k => k.UrunID == urunlerID && k.OnayDurumu==true).ToList();
            return repYorumlar.ListeFiltre(k => k.UrunID == urunlerID).ToList();
        }
    }
}
