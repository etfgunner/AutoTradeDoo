using AutoTradeDoo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace AutoTradeDoo.Controllers
{
    public class HomeController : Controller
    {
       // static Automobil auto=new Automobil(2,3,"dsa","fa,",2.3,2.4,3.5);
        AutoTradeDooDb _db = new AutoTradeDooDb();
        public ActionResult Index()
        {
            var model = _db.automobili.ToList();
            return View(model);
        }

        public ActionResult About()
        {
            //ViewBag.naziv = auto.Marka;
            //ViewBag.potrosnja = auto.kombinovano();
            ViewBag.Message = "O nama";

            return View();
        }
        public ActionResult Sent()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Kontakt stranica";

            return View();
        }
        public ActionResult Email()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Email(EmailForm model)
        {
            if (ModelState.IsValid)
            {
                

                MailMessage mail = new MailMessage();
                var model1 = _db.newsletterLista.ToList();
                for(int i=0;i<model1.Count();i++)
                mail.To.Add(model1.ElementAt(i).email);
                mail.From = new MailAddress("autotradedoo@outlook.com");
                mail.Subject = "Novost";
                mail.Body = model.Message ;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("autotrade129@gmail.com", "Autotrade1");
                smtp.Send(mail);


                return RedirectToAction("Index");


            
            }
            return View(model);
        }
        protected override void Dispose(bool disposing)
        {
            if (_db != null)
                _db.Dispose();
            base.Dispose(disposing);
        }
        
    }
}