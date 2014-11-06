using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using SeraFood.Models;
using SeraFood.Models.UnitOfWork;

namespace SeraFood.Controllers
{
    public class JobsController : Controller
    {
         IUnitOfWork _uow;
        public JobsController()
        {
            _uow = new UnitOfWork();
        }
        public JobsController(IUnitOfWork uof) // Fake 
        {
            _uow = uof;
        }

        public ActionResult Home()

        {
            return View();
        }

        public ActionResult Job(int jobTitle)
        {
            ViewBag.Id = jobTitle;
            if (jobTitle ==1)
            {
                var model = _uow.Jobs.List(p => p.Available == true);

                return View(model);
            }
            else if (jobTitle == 2)
            {
                var model = _uow.Jobs.List(p => p.Available == false);
                return View(model);
            }
            return View();
        }
        //
        // GET: /Product/
        public ActionResult Index(int? page)
        {
            var Jobs = _uow.Jobs.List();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfJobs = Jobs.OrderBy(p => p.JobeName).ToPagedList(pageNumber, 14); // will only contain 25 products max because of the pageSize

            ViewBag.onePageOfJobs = onePageOfJobs;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string JobeName, int? page)
        {
            var Categories = _uow.Jobs.List(p => p.JobeName.Contains(JobeName));
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfJobs = Categories.OrderBy(p => p.JobeName).ToPagedList(pageNumber, 14); // will only contain 25 products max because of the pageSize

            ViewBag.onePageOfJobs = onePageOfJobs;
            return View();
        }
        public ActionResult Create()
        {
         
            return View();
        }

        //
        // POST: /Posts/Create
        [HttpPost]

        public ActionResult Create(Job jobToCreate)
        {

            try
            {

                //"MVC,Razor,ASP.NET"
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    _uow.Jobs.Add(jobToCreate);
                    _uow.Save();
                    //
                    return RedirectToAction("Index");
                }
                return View("Create", jobToCreate);
            }
            catch
            {
                return View("error");
            }
        }


        public ActionResult Edit(int id)
        {
           
            var model = _uow.Jobs.Find(id);
            if (model != null)
                return View(model);
            return HttpNotFound();
        }

        //
        // POST: /Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Job jobToUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here

                    _uow.Jobs.Edit(id, jobToUpdate);
                    _uow.Save();
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Delete(int id)
        {
            _uow.Jobs.Delete(id);
            _uow.Save();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult CreateApplyJob(int jobId)
        {
            
            ViewBag.JobId = jobId;
            ViewBag.JobsDetails = _uow.Jobs.Find(jobId);

            return View();

        }
       
        [HttpPost]
        public ActionResult CreateApplyJob(ApplyJob applyJobToCreate)
        {

            try
            {
                ViewBag.JobId = applyJobToCreate.JobId;

                if (ModelState.IsValid)
                {
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        applyJobToCreate.EmployeeCv = file.FileName;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Content/CV"), applyJobToCreate.EmployeeCv));

                        //candidate.JobTitle 
                        //candidate.Mail 

                        // Database  / Mail 
                        _uow.ApplyJobs.Add(applyJobToCreate);
                        _uow.Save();
                        ViewBag.Message = "Your Application has been sent Successfully!";
                        ViewBag.Status = "success";
                        return View("CreateApplyJob");
                    }
                    else
                    {
                        ViewBag.Message = "Please select your CV!";
                        ViewBag.Status = "danger";
                        return View("CreateApplyJob", applyJobToCreate);
                    }
                }
                else
                {
                    ViewBag.Message = "Please, correct your info , and try again !";
                    ViewBag.Status = "danger";
                    return View("CreateApplyJob", applyJobToCreate);
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "We cann't send your message , please try again";
                ViewBag.Status = "danger";
                return View("CreateApplyJob", applyJobToCreate);
            }

        }
	}
}