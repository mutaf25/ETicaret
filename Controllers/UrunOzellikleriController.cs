using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class UrunOzellikleriController : Controller
    {
        UrunManager urunMan = new UrunManager();
        OlcuBirimiManager olcMan = new OlcuBirimiManager();
        // GET: UrunOzellikleri
        public ActionResult UrunOzellikListeIndex()
        {
            return View();
        }

        public ActionResult UrunOzellikEkleIndex()
        {
            ViewBag.urunler = urunMan.UrunListesi();
            ViewBag.olculer = olcMan.OlcuBirimiListesi();
            return View();
        }

        //[HttpPost]
        //public ActionResult UrunOzellikEkleIndex(??)
        //{
        //    ViewBag.urunler = urunMan.UrunListesi();
        //    return View();
        //}
    }
}