using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class KategoriController : Controller
    {
        //*******************************************************
        KategorilerManager katMan = new KategorilerManager();
        //*********************************************************
        // GET: Kategori
        public ActionResult KategoriIndex()
        {
            //UstKategori değişkeni bir liste yapısı çağırdık ve bu liste yapısını view safyasında select tagi içinde foreach ile listeleyeceğiz
            ViewBag.UstKategori = katMan.KategoriGetir();
            return View();
        }

        [HttpPost]
        public ActionResult KategoriIndex(string kadi, int? PKatID, int? personelID)
        {
            //üstkat var mı seçeneği ile kullanıcının seçtiği seçeneğe göre burdaki işlemler yapılacaktır
            string ustKatVarmi = "var";
            if (ustKatVarmi == "var")
            {
                personelID = 1;
                katMan.InsertKategori(kadi, (int)PKatID, (int)personelID);
            }
            else
            {
                katMan.InsertKategori(kadi, 0, (int)personelID);
            }
            ViewBag.UstKategori = katMan.KategoriGetir();
            return View();
        }

        public ActionResult KategoriGuncelle(int? Kategori_Id)
        {

            //ViewBag.UstKategori = new SelectList(katMan.KategoriGetir(), "KategorilerID", "KategoriAdi", katMan.ParentKategoriGetir((int)Kategori_Id));
            //*********************************************
            //tanımlama yapılacak...
            ViewBag.UstKategori = katMan.KategoriGetir();

            //ViewBag ile Selectlist yapısının içine Manager dan aldığımız listenin içinden KategorilerID ile Id değerini, KategoriAdi ile kategori adını List yapısının çine attık.View sayfasında Dropdownlist ile yakalayacağız

            return View(katMan.KategoriBul((int)Kategori_Id));
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(int? Kategori_Id, Kategoriler KatTablo)
        {

            int sonuc = katMan.KategoriGuncelle((int)Kategori_Id, KatTablo);
            if (sonuc > 0)
            {
                TempData["KategoriGuncelle"] = "<h2 style='color:green'> Güncelleme Başarılı</h2>";
            }
            else
            {
                TempData["KategoriGuncelle"] = "<h2 style='color:red'> Başarısız, kontrol ediniz</h2>";
            }
            //ViewBag.ParentKategoriID1 = new SelectList(katMan.KategoriGetir(), "KategorilerID", "KategoriAdi", katMan.ParentKategoriGetir((int)Kategori_Id));
            ViewBag.UstKategori = katMan.KategoriGetir();

            return View(katMan.KategoriBul((int)Kategori_Id));
        }

        public ActionResult KategoriSil(int kategorilerSil_Id)
        {
            return View(katMan.KategoriBul(kategorilerSil_Id));
        }

        //MVC'de aynı özelliklere sahip , aynı ismi taşıyan metotlar yapmak zorunda kalabiliriz. Özellikle silme işlemlerinde buna ihtiyaç duyarız.Bu gibi işlemlerde Metot adını değiştirip post yapısından sonra  [ActionName("KategoriSil")] yazıp, bu metot isminin post işlemlerini gerçekleştireceğini gösterir
        [HttpPost]
        [ActionName("KategoriSil")]//KategoriSil metodunun post işlemini yapacak
        public ActionResult KategorilerDelete(int kategorilerSil_Id)
        {
            try
            {
                int sonuc = katMan.KategoriSil(kategorilerSil_Id);
                if (sonuc > 0)
                {
                    return RedirectToAction("KategoriIndex", "Kategori");
                }
                ViewBag.mesajSil = "<h5 style='color:red'>Bir Hata Oluştu</h5>";
                return View(katMan.KategoriBul(kategorilerSil_Id));
            }
            catch (Exception)
            {
                ViewBag.mesajSil = "<h5 style='color:red'>Silme gerçekleşmedi lütfen kontrol ediniz</h5>";
                return View(katMan.KategoriBul(kategorilerSil_Id));
            }
        }


    }
}