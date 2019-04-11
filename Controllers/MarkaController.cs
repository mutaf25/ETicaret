using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret.BLL;
using ETicaret.DLL;

namespace ETicaretHiSabah.Admin.Controllers
{
    public class MarkaController : Controller
    {
        MarkaManager markman = new MarkaManager();
        // GET: Marka
        public ActionResult MarkaIndex()
        {
            //Form load
            return View();
        }

        [HttpPost]
        public ActionResult MarkaIndex(string textmarkaAdi,string personelId)
        {
            string mesaj = null;
            if (!string.IsNullOrWhiteSpace(textmarkaAdi))
            {
                personelId = "1";
                markman.InsertMarka(textmarkaAdi, Convert.ToInt32(personelId));
                mesaj = "Başarılı bir şekilde eklendi";
            }
            else
            {
                mesaj = "Boş alanları doldurun";
            }

            return View();
        }

        public ActionResult MarkaGuncelle(int Marka_ID)
        {
            return View(markman.KategoriBul(Marka_ID));
        }

        [HttpPost]
        public ActionResult MarkaGuncelle(Markalar markTablo)
        {
            //db.Entry(tabloGuncelle).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
           int gnc= markman.Guncelle(markTablo);
            if (gnc>0)
            {
                TempData["GuncelleMesaji"] = "<h3 style='color:red;'>Marka Güncellemesi başarılı</h3>";
            }
            else
            {
                TempData["GuncelleMesaji"] = "<hr style='border:1px;color:red'>Olmadı, kontrol ediniz";
            }
            return View();
        }
    }
}