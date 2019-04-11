using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class OlcuBirimleriController : Controller
    {

        OlcuBirimiManager olcuBirimMan = new OlcuBirimiManager();

        // GET: OlcuBirimleri
        public ActionResult OlcuBirimleriIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult OlcuBirimleriIndex(string adi,string aciklama)
        {
            return View();
        }


        public ActionResult OlcubirimiGuncelle(int? ID)
        {
            //olcuBirimMan.olcuBirimiBul(ID);
            return View(olcuBirimMan.olcuBirimiBul(ID));
        }
        [HttpPost]
        public ActionResult OlcubirimiGuncelle(OlcuBirimleri tablo)
        {

            int sonuc = olcuBirimMan.OlcuBirimiGuncelle(tablo);
            if (sonuc>0)
            {
                TempData["Mesaj"] = "<h2 style='color:red'>Başarılı</h2>";
            }
            else
            {
                TempData["Mesaj"] = "<h2 style='color:red'>Güncelleme olmadı kontrol ediniz</h2>";
            }
            return View();
        }
    }
}