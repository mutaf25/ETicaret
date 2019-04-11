using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
  public   class KategorilerManager
    {
        ETicaretDBEntities db = new ETicaretDBEntities();

        Repository<Kategoriler> rep = new Repository<Kategoriler>();

        public KategorilerManager()
        {
            //db.Kategoriler.ToList();
            //db.Set<T>().ToList();
            rep.Liste();
        }

        public void InsertKategori(string adi,int parentID,int personelId)
        {
            int ekle = rep.insert(new Kategoriler() {

                //KategoriAdi = "Elektronik",
                //ParentKategoriID = 0
                KategoriAdi=adi,
                ParentKategoriID=parentID,
                PersonelID=personelId
            });
        }

        public List<Kategoriler> KategoriGetir()
        {
            return rep.Liste();
        }

        public Kategoriler KategoriBul(int KatId)
        {
            return rep.VeriBul(k => k.KategorilerID == KatId);
        }
       
        public int  ParentKategoriGetir(int Kategori_Id)
        {
            //ParentKategoriId almak için bu metodu yazdık
            try
            {
                var Parent_Id = rep.VeriBul(k =>k.KategorilerID == Kategori_Id ).ParentKategoriID;

                return (int)Parent_Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }


        //public void KategoriGuncelle(int Kategori_Id,string Kategori_Adi,int ParentKat_Id,int Personel_Id)
        public int KategoriGuncelle(int Kategori_Id,Kategoriler tabloKategori)
        {
            Kategoriler guncelleSorgu = rep.VeriBul(k => k.KategorilerID == Kategori_Id);

            if (guncelleSorgu!=null)
            {
                guncelleSorgu.KategoriAdi = tabloKategori.KategoriAdi;
                guncelleSorgu.ParentKategoriID = tabloKategori.ParentKategoriID;
                guncelleSorgu.PersonelID = tabloKategori.PersonelID;
                //Kategoriler tabloKategori = new Kategoriler();
                //string isim= tabloKategori.KategoriAdi;
              int GncSonuc=  rep.Update(tabloKategori);
                if (GncSonuc>0)
                {
                    return 1;
                }
                //return 0;
            }
            return 0;
        }


        public int KategoriSil(int IdKategori)
        {
          
            Kategoriler sil = rep.VeriBul(k => k.KategorilerID == IdKategori);

            //var ParentIDVarmi = db.Kategoriler.Where(k => k.ParentKategoriID == IdKategori).Select(x => x.ParentKategoriID).ToList();
            var ParentIDVarmi = rep.ListeFiltre(k => k.ParentKategoriID == IdKategori).ToList();

            if (ParentIDVarmi.Count()==0)
            {
                if (rep.Delete(sil)>0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
