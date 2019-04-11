using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
   public  class UrunResimleriManager
    {

        Repository<UrunResimleri> repResimler = new Repository<UrunResimleri>();

        public int ResimBul(int Urun_Id)
        {
            var bulResim = repResimler.VeriBul(k => k.UrunID ==Urun_Id).UrunID;

            return (int)bulResim;

        }


        public void ResimEkle(UrunResimleri tabloResim)
        {
            int AddResim = repResimler.insert(new UrunResimleri() {
                PersonelID = tabloResim.PersonelID,
                UrunID=tabloResim.UrunID,
                Resim=tabloResim.Resim            
            });

        }

        public int ResimSil(int ResimlerId)
        {
            UrunResimleri sil = repResimler.VeriBul(k => k.UrunResimleriID == ResimlerId);

            if (sil!=null)
            {
                if (repResimler.Delete(sil)>0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
