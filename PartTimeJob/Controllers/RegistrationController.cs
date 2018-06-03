using PartTimeJob.DAL;
using PartTimeJob.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartTimeJob.Controllers
{
    public class RegistrationController : Controller
    {
        private PartTimeContext db = new PartTimeContext();

        // GET: Registration/register
        public ActionResult Register()
        {
            return View();
        }

        // GET: Registration/EmployerRegistration
        public ActionResult EmployerRegistration()
        {
            return View();
        }

        // POST: Registration/EmployerRegistration
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EmployerRegistration([Bind(Include = "ID,FirstName,LastName,UserName,Password,Email,PhoneNumber")] Employer employer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Employers.Add(employer);
                    db.SaveChanges();
                    return RedirectToAction("Register");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(employer);

        }

        // GET: Registration/EmployeeRegistration
        public ActionResult EmployeeRegistration()
        {
            return View();
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}