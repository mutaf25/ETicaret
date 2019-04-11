using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class SiparisTakibiController : Controller
    {
        // GET: SiparisTakibi
        public ActionResult SiparisTakibiIndex()
        {
            /*MUTAFF
             Bu alanda tarihe göre siparişler listelenecek. Her sipariş için bir detay buttonu olacak. Bu detay buttonunda siparişin genel bilgileri, siparişin kargo bilgileri, müşteri bilgileri,... gibi bilgiler yer alacak
             */
            return View();
        }

        public ActionResult IadeEdilenSiparisler()
        {
            return View();
        }
        public ActionResult HataliGidenSiparisler()
        {
            return View();
        }
    }
}
