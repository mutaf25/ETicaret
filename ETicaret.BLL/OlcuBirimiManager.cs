using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
   public class OlcuBirimiManager
    {
        Repository<OlcuBirimleri> repOlc = new Repository<OlcuBirimleri>();
        ETicaretDBEntities db = new ETicaretDBEntities();

        public List<OlcuBirimleri> OlcuBirimleriGetir()
        {
            return repOlc.Liste();
        }

        public OlcuBirimleri olcuBirimiBul(int? OlcuBirimi_ID)
        {
            return repOlc.VeriBul(k => k.OlcuBirimleriID == OlcuBirimi_ID);

        }

        public List<OlcuBirimleri> OlcuBirimiListesi()
        {
            return repOlc.Liste();
        }

        public int OlcuBirimiGuncelle(OlcuBirimleri tabloAdi)
        {
             db.Entry(tabloAdi).State = System.Data.Entity.EntityState.Modified;

            if (db.SaveChanges()>0)
            {
                return 1;
            }
            return 0;
        }
    }
}
