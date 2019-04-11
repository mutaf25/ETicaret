using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
   public  class SepetManager
    {
        Repository<Urunler> rep = new Repository<Urunler>();
      private  List<SepetSinifi> _liste = new List<SepetSinifi>();

       public  List<SepetSinifi> SepetSinifi
        {
            get { return _liste; }            
        }

        public decimal SepetToplamFiyat()
        {
            return _liste.Sum(k =>(decimal)k.SepettekiUrun.UrunFiyat * k.SepettekiMiktar);
        }

        public void SepeteUrunEkle(int urun_Id,decimal sep_Miktar)
        {
            Urunler varMiUrun = rep.VeriBul(k => k.UrunlerID == urun_Id);//veritabanında gelen ID değerine sahip ürün var mı,yok mu???
            if (varMiUrun!=null)
            {
                //bu alan sepete ekleme işlemidir
               var eklenecekUrun=_liste.FirstOrDefault(h => h.SepettekiUrun.UrunlerID == varMiUrun.UrunlerID);
                if (eklenecekUrun==null)
                {
                    //sepette bu eklenecek üründen hiç yok ise yeni ürün eklenecek
                    _liste.Add(new SepetSinifi() {
                        SepettekiUrun = varMiUrun,
                        SepettekiMiktar = sep_Miktar
                    });
                }
                else
                {
                    //Sepette varsa miktarı kadar eklemesiini sağlıyoruz
                    eklenecekUrun.SepettekiMiktar = eklenecekUrun.SepettekiMiktar + sep_Miktar;
                }
            }
        }
        public void UrunuSeppettenSil(int urunler_ID)
        {            
            _liste.RemoveAll(k => k.SepettekiUrun.UrunlerID ==urunler_ID);
        }

        public void SepetUrunAzalt(int urunler_id)
        {
            Urunler varMi = rep.VeriBul(k => k.UrunlerID == urunler_id);
            if (varMi!=null)
            {
                var sil = _liste.FirstOrDefault(k => k.SepettekiUrun.UrunlerID == varMi.UrunlerID);

                if (sil.SepettekiMiktar>1)
                {
                    sil.SepettekiMiktar = sil.SepettekiMiktar - 1;
                }
                else
                {
                    _liste.Remove(sil);
                }
                
                // _liste.RemoveAll(k => k.SepettekiUrun.UrunlerID == varMi.UrunlerID);//RemoveAll ile yukarda iki satırla yapılan işlemi, RemoveAll Lambda Expetion sorgusu alarak yapmaktadır
            }

        }
    }

    public class SepetSinifi
    {
        //Sepet sanal tablosu
        public Urunler SepettekiUrun { get; set; }
        public decimal SepettekiMiktar { get; set; }//burdaki miktarı almamızın sebebi  ürünler tablosunda  siparişe gidecek  miktar belli değildir. Kullanıcı için mikar kısmını belirtmemiz gerekli.SepettekiMiktar o nedenle önemlidir
    }
}
