using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
   public  class IndirimTurleriManager
    {
        Repository<indirimTurleri> repIndirimturleri = new Repository<indirimTurleri>();

        public void indirimTurleriKaydet(string adi,string aciklama)
        {
            int ekle = repIndirimturleri.insert(new indirimTurleri()
            {
                indirimTuruAdi=adi,
                Aciklama=aciklama
            });
        }

        public int IndirimTurleriGuncelle(int? Indirimturleri_Id,indirimTurleri tabloIndirim)
        {
            indirimTurleri guncelle = repIndirimturleri.VeriBul(k => k.indirimTurleriID == Indirimturleri_Id);

            if (guncelle!=null)
            {
                repIndirimturleri.Update(tabloIndirim);
                //if (repIndirimturleri.Update(tabloIndirim)>0)
                //{
                //    return 1;
                //}
            }
            return 0;
        }


        public List<indirimTurleri> indirimturleriListesi()
        {
            return repIndirimturleri.Liste();
        }

        public indirimTurleri IndirimTuruBul(int? IndirimTurleri_Id)
        {
            return repIndirimturleri.VeriBul(l => l.indirimTurleriID == IndirimTurleri_Id);
        }


    }
}
