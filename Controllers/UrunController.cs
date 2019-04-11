using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class UrunController : Controller
    {
        KategorilerManager katMan = new KategorilerManager();
        MarkaManager markMan = new MarkaManager();
        OlcuBirimiManager olcMan = new OlcuBirimiManager();
        UrunManager urunMan = new UrunManager();
        UrunResimleriManager resimMan = new UrunResimleriManager();
        // GET: Urun
        #region ürün ekleme 
        public ActionResult UrunIndex()
        {
            DropDownListeler();
            return View();
        }

        [HttpPost]
        public ActionResult UrunIndex(int KategoriId, int MarkaId, string OlcuBirimiAdi, string UrunAdi, decimal Fiyat, decimal Stok, string Aciklama, int? PersonelId)
        {
            PersonelId = 1;
            urunMan.UrunKaydet(KategoriId, MarkaId, OlcuBirimiAdi, UrunAdi, Fiyat, Stok, Aciklama, (int)PersonelId);

            DropDownListeler();
            return View();
        } 
        #endregion

        private void  DropDownListeler()
        {
            ViewBag.Kategoriler = katMan.KategoriGetir();
            ViewBag.Markalar = markMan.MarkaGetir();
            ViewBag.Olculer = olcMan.OlcuBirimleriGetir();
        }
        //************************************************
        //Ürün Listesini farklı bir sayfada yapacağız
        public ActionResult UrunListesiView()
        {
            return View(urunMan.UrunListesi());
        }

        #region Ürün Güncelleme
        public ActionResult UrunGuncelleIndex(int? UrunlerID)
        {
            //List<SelectListItem> KategoriListesi = new List<SelectListItem>();
            //KategoriListesi = (from kt in katMan.KategoriGetir()
            //                   select new SelectListItem {
            //                       Text=kt.KategoriAdi,
            //                       Value=kt.KategorilerID.ToString()
            //                   }).ToList();

            ViewBag.KategoriGetir = katMan.KategoriGetir();
            ViewBag.Markalar_Getir = markMan.MarkaGetir();
            ViewBag.olcubirimi_Getir = olcMan.OlcuBirimleriGetir();
            //UrunListesiView sayfasında Düzenle buttonuna tıklanınca bir ID değeri bu Metotta gönderilecek. Bu ID değerini Parametrede tanımlanan değişken ismi ile aynı olacak şekilde ayarlanacak ve Manager classın da tanımlanan metota Bu ID değerini vererek Düzenle buttonu ile hangi Ürüne tıklandıysa o ürünün bilgilerini UrunGuncelleIndex sayfasına gönderecek
            return View(urunMan.UrunBul(UrunlerID));
            #region Katmanlı Mimariler ve MVC Çalışma Mantığı
            /*
               * ----------------------
               1-Repository
               ----------------------
               Bütün tablolar için interface class olacak şekilde ayarlandı. Ürünler için gerekli listeleme,sorgulama,veri bulma,Ekleme,güncelleme,Silme işlemlerini alabiliriz
               ----------------------
               2-Veritabanından Model'deki Urunler alınacak
               ----------------------
               Urunler tablosundan Repository ye T yapıları için referans verilecek
               -------------------
              3- Urun Manager
               ----------------
               Urunmanager class'ı , Repository class'ndan metot alarak işlem yapacaktır. Biz Ürün güncelleme işlemleri için VeriBul(int ID) diye bir metot oluşturduk. Bu metot Repository class'ında ListeFiltre metodundan Referans alır(interface metot)
               -------------------------------
               4-UrunController
               ------------------------------
               UrunController    sayfasından UrunManager classînda VeriBul metodunu çağırarak her düzenle buttonuna tıklanınca bir ürün bulması için Repository'deki sorguya gidecek
               ---------------
              5- View
               ------------------
               Return view ile UrunGuncelleIndex sayfasına  tıklanan ürünün bilgileri ilgili tag'lere doldurulacak
               */
            #endregion
        }

        [HttpPost]
        public ActionResult UrunGuncelleIndex(Urunler obj)
        {
            //obj.UrunlerID = 12;
           int sonuc= urunMan.UrunGuncelle(obj);
            if (sonuc>0)
            {
                ViewBag.mesaj = "<h5>Ürün başarılı bir şekilde güncellendi</h5>";
            }
            else
            {
             ViewBag.mesaj = "<h5>Güncelleme BAŞARISISZ!!!! Kontrol ediniz</h5>";
            }
            ViewBag.KategoriGetir = katMan.KategoriGetir();
            ViewBag.Markalar_Getir = markMan.MarkaGetir();
            ViewBag.olcubirimi_Getir = olcMan.OlcuBirimleriGetir();
            return View(urunMan.UrunBul(obj.UrunlerID));
        }

        #endregion


        public ActionResult UrunDetayIndex(int? UrunDetay_ID)
        {
            //Kaç adet resim var...
            return View(urunMan.UrunBul(UrunDetay_ID));
        }

        public ActionResult UrunResimEkleIndex(int? Urun_ID)
        {
            return View();

        }


        [HttpPost]
        public void UrunSil(int urunler_id)        
        {
            urunMan.UrunSil(urunler_id);
            

        }


        //bu metot geriye bir json döndürecektir.View tarafında yazılacak json scriptini döndürecek
        public JsonResult UrunFileUpload(HttpPostedFileBase file,int? id)
        {
            //HttpPostedFile resim eklemek için bu yapıya ihtiyacaımız var. Sadece resim dosya da eklemek iin bu türde bir class yapısına ihtiyaç vardır
            if (file!=null && (file.ContentType=="image/jpg" || file.ContentType=="image/jpeg" || file.ContentType=="image/png" ))
            {
                //her ekelnen resime bir kod ile benzersiz yapmak için aşağıdaki kod yapısını kullanıyoruz
                string filename = $"Urun_{ Guid.NewGuid()}.{file.ContentType.Split('/')[1] }";
                string path = Server.MapPath($"~/EklenenResimler/{filename}");
                //file.SaveAs(Server.MapPath($"~/EklenenResimler/{filename}"));
                file.SaveAs(path);

            UrunResimleri urunRess = new UrunResimleri();
            urunRess.Resim= filename;
            urunRess.UrunID = id;
            resimMan.ResimEkle(urunRess);
                return Json("csd");
            }

            return Json("sfsdfs");
        }

        public JsonResult UrunResimSil(int? UrunResimID)
        {
           int sonuc= resimMan.ResimSil((int)UrunResimID);
            if (sonuc>0)
            {
                return Json(new { Durum = true }, JsonRequestBehavior.AllowGet);//silinen resimleri bulunduğu alandan kaldırır
            }
            return Json(new { Durum = false });
            //return Json("");

        }
    }
}