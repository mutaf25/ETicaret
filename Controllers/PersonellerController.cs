using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class PersonellerController : Controller
    {
        PersonelManager persMan = new PersonelManager();
        // GET: Personeller
        public ActionResult PersonelListeIndex()
        {
            return View(persMan.PersonelListesi());
        }

        public ActionResult PersonelEkleIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkleIndex(string adi)
        {
            return View();
        }

        public ActionResult PersonelGuncelleIndex(int Personeller_ID)
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelGuncelleIndex(int Personeller_ID,int g)
        {
            return View();
        }


        [HttpPost]
        public void PersonelSil(int gelenpers_id)
        {
            persMan.PersSil(gelenpers_id);

        }

    }
}