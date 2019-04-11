using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
   public  class UrunManager
    {

        Repository<Urunler> repUrunler = new Repository<Urunler>();
        
        public void UrunKaydet(int kategoriId,int markaId,string olcuBirimi,string urunAdi,decimal fiyat,decimal stok,string aciklama,int personelId)
        {
            int ekleUrun = repUrunler.insert(new Urunler() {
                KategoriID=kategoriId,
                MarkaID=markaId,
                UrunOlcuTanimi=olcuBirimi,
                UrunAdi=urunAdi,
                UrunFiyat=fiyat,
                UrunStok=stok,
                UrunAciklama=aciklama,
                PersonelID=personelId
            });
        }

        public List<Urunler> UrunListesi()
        {
            return repUrunler.Liste();
        }

        public Urunler  urunDetay(int urunId)
        {
            return repUrunler.ListeFiltre(k => k.UrunlerID == urunId).FirstOrDefault();
            //FirstOrDefault() ==> varsa veri >0==> true
            //FirstOrDefault() ==> yoksa veri 0 olacak==> false
        }

        public Urunler UrunBul(int? Urunler_Id)
        {
            //where içinde bir sorguya ihtiyacımız olduğundan
            return repUrunler.ListeFiltre(k => k.UrunlerID == Urunler_Id).FirstOrDefault();
           
        }

        public int UrunGuncelle(Urunler tabloObj)
        {
            Urunler guncelle = repUrunler.VeriBul(k => k.UrunlerID == tabloObj.UrunlerID);

            if (guncelle!=null)
            {
                guncelle.UrunAdi = tabloObj.UrunAdi;
                guncelle.KategoriID = tabloObj.KategoriID;
                guncelle.MarkaID = tabloObj.MarkaID;
                guncelle.UrunFiyat = tabloObj.UrunFiyat;
                guncelle.UrunOlcuTanimi = tabloObj.UrunOlcuTanimi;
                guncelle.UrunStok = tabloObj.UrunStok;
                guncelle.UrunAciklama = tabloObj.UrunAciklama;
                guncelle.PersonelID = tabloObj.PersonelID;

                if (repUrunler.Update(tabloObj)>0)
                {
                    return 1;
                }
                //return 0;
            }
            return 0;
        }

        public int UrunSil(int IdUrun)
        {
            Urunler silUrun = repUrunler.VeriBul(v => v.UrunlerID == IdUrun);
            if (silUrun!=null)
            {
                if (repUrunler.Delete(silUrun)>0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
