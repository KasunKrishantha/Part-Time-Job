using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PartTimeJob.DAL;
using PartTimeJob.Models;

namespace PartTimeJob.Controllers
{
    public class JobController : Controller
    {
        private PartTimeContext db = new PartTimeContext();

        // GET: Job
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.LocationSortParm = String.IsNullOrEmpty(sortOrder) ? "location_desc" : "";
            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.SalarySortParm = String.IsNullOrEmpty(sortOrder) ? "salary_desc" : "";

            //ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            //Display Page Number
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;


            var jobs = from s in db.Jobs
                           select s;

            //Search function
            if (!String.IsNullOrEmpty(searchString))
            {
                jobs = jobs.Where(s => s.Catagory.Contains(searchString)
                                       || s.Position.Contains(searchString) 
                                       || s.Title.Contains(searchString));
            }

            //Sort Function
            switch (sortOrder)
            {
                case "name_desc":
                    jobs = jobs.OrderByDescending(s => s.Catagory);
                    break;
                case "location_desc":
                    jobs = jobs.OrderByDescending(s => s.Location);
                    break;
                case "title_desc":
                    jobs = jobs.OrderByDescending(s => s.Title);
                    break;
                //case "Date":
                  //  jobs = jobs.OrderBy(s => s.Position);
                    //break;
                case "salary_desc":
                    jobs = jobs.OrderByDescending(s => s.Salary);
                    break;
                default:
                    jobs = jobs.OrderBy(s => s.Catagory);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(jobs.ToPagedList(pageNumber, pageSize));

            //var job = db.Jobs.Include(j => j.Employer);
            //return View(job.ToList());
            //return View(jobs.ToList());
        }

        // GET: Job/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        

        // GET: Job/Create
        public ActionResult Create()
        {
            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "FirstName");
            return View();
        }

        // POST: Job/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployerID,Catagory,Title,Position,Location,Salary,Description,AgeRange,ContactNumber,GenderType,EmployeementType,Qualification,NumberOfEmp,District,JobRole,Education,Requirement,Status")] Job job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Jobs.Add(job);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            //ViewBag.EmployerID = new SelectList(db.Employers, "ID", "FirstName", job.EmployerID);
            return View(job);
        }

        // GET: Job/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployerID = new SelectList(db.Employers, "ID", "FirstName", job.EmployerID);
            return View(job);
        }

        // POST: Job/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var jobToUpdate = db.Jobs.Find(id);

            if (TryUpdateModel(jobToUpdate, "",
                new string[] {"EmployerID","Name","Title","Position","Location","Salary","Description","AgeRange","ContactNumber","GenderType","EmployeementType","Qualification","NumberOfEmp","District","JobRole","Education","Requirement","Status" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(jobToUpdate);


        }

        /*
               [HttpPost]
               [ValidateAntiForgeryToken]
               public ActionResult Edit([Bind(Include = "ID,EmployerID,Name,Title,Position,Location,Salary,Description,AgeRange,ContactNumber,GenderType,EmployeementType,Qualification,NumberOfEmp,District,JobRole,Education,Requirement,Status")] Job job)
               {
                   if (ModelState.IsValid)
                   {
                       db.Entry(job).State = EntityState.Modified;
                       db.SaveChanges();
                       return RedirectToAction("Index");
                   }
                   ViewBag.EmployerID = new SelectList(db.Employers, "ID", "FirstName", job.EmployerID);
                   return View(job);
               }
         */

        // GET: Job/Delete/5
        public ActionResult Delete(int? id ,bool? saveChangesError= false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Job jobToDelete = new Job() { ID = id };
                db.Entry(jobToDelete).State = EntityState.Deleted;
                //Job job = db.Jobs.Find(id);
                //db.Jobs.Remove(job);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        /*
        // POST: Job/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */

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
