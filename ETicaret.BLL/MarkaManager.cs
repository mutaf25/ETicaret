using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
  public   class MarkaManager
    {
        //************************************************************
        Repository<Markalar> rep = new Repository<Markalar>();
        //************************************************************
        ETicaretDBEntities db = new ETicaretDBEntities();

        public MarkaManager()
        {
            rep.Liste();
        }

        public void InsertMarka(string adi,int personelId)
        {
            int Ekle = rep.insert(new Markalar()
            {
                MarkaAdi = adi,
                PersonelID=personelId
            });
        }

        public List<Markalar> MarkaGetir()
        {
            return rep.Liste();
        }

        public Markalar KategoriBul(int Marka_Id)
        {
            return rep.VeriBul(k => k.MarkalarID == Marka_Id);
        }

        public Markalar MarkaBul(int Marka_Id)
        {
            return rep.VeriBul(k => k.MarkalarID == Marka_Id);
        }

        //public int MarkaGuncelle(string Marka_Adi,int Personel_ID)
        //{
        //    return rep.Update()
        //}

        public int Guncelle(Markalar tabloGuncelle)
        {
            //Repository yapısı ile güncelleme olmuyor
            db.Entry(tabloGuncelle).State = System.Data.Entity.EntityState.Modified;
            if (db.SaveChanges()>0)
            {
                return 1;
            }
            return 0;
            //rep.Save();
        }
    }
}
