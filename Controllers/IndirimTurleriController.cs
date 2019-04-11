using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class IndirimTurleriController : Controller
    {
        IndirimTurleriManager indirMan = new IndirimTurleriManager();
        // GET: IndirimTurleri
        public ActionResult Index()
        {
            
            return View(indirMan.indirimturleriListesi());
        }
        public ActionResult IndirimTurleriKaydetIndex()
        {
            return View();
        }

        public ActionResult IndirimTurleriGuncelleIndex(int? ID)
        {
            return View(indirMan.IndirimTuruBul((int)ID));
        }

        [HttpPost]
        public ActionResult IndirimTurleriGuncelleIndex(int ID, indirimTurleri tabloNesne)
        {
            indirMan.IndirimTurleriGuncelle(ID, tabloNesne);
            return View();
        }
    }
}