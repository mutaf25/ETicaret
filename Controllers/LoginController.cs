using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class LoginController : Controller
    {

        PersonelManager persMan = new PersonelManager();

        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginIndex(string kullaniciAdi,string sifre)
        {

            var loginGiris = persMan.Giris(kullaniciAdi, sifre);

            if (loginGiris!=null)
            {
                Session["PersonelAdi"] = loginGiris.Adi + " " + loginGiris.Soyadi;
                //Admin sayfasına yönlendirme yapılacak
                ViewBag.personelID = loginGiris.PersonellerID;
                //PersonellerID değerini bütün sayfalarda 
                return RedirectToAction("DefaultIndex", "Default");
            }
            ViewBag.mesaj = "<hr/><h5 style='color:red;'>Kullanıcı adı veya şifre hatalıdır </h5>";
            return View();
        }

        public ActionResult xxx()
        {
            return View();

        }
    }
}