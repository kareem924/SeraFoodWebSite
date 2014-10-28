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
    [Authorize]
    public class CategoriesController : Controller
    {
        IUnitOfWork _uow;
        public CategoriesController()
        {
            _uow = new UnitOfWork();
        }
        public CategoriesController(IUnitOfWork uof) // Fake 
        {
            _uow = uof;
        }
        //
        // GET: /Product/
        public ActionResult Index(int? page)
        {
            var Categories = _uow.Categories.List();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfCategories = Categories.OrderBy(p => p.CategoryName).ToPagedList(pageNumber, 14); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfCategories = onePageOfCategories;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string CategoryName, int? page)
        {
            var Categories = _uow.Categories.List(p => p.CategoryName.Contains(CategoryName));
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfCategories = Categories.OrderBy(p => p.CategoryName).ToPagedList(pageNumber, 14); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfCategories = onePageOfCategories;
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Brands = new SelectList(_uow.Brand.List(), "BrandId", "BrandName");
            return View();
        }

        //
        // POST: /Posts/Create
        [HttpPost]

        public ActionResult Create(Category categoryToCreate)
        {

            try
            {

                //"MVC,Razor,ASP.NET"
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        categoryToCreate.CategoryImageName = file.FileName;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), categoryToCreate.CategoryImageName));
                    }
                    _uow.Categories.Add(categoryToCreate);
                    _uow.Save();
                    //
                    return RedirectToAction("Index");
                }
                return View("Create", categoryToCreate);
            }
            catch
            {
                return View("error");
            }
        }


        public ActionResult Edit(int id)
        {
            ViewBag.Brands = new SelectList(_uow.Brand.List(), "BrandId", "BrandName");
            var model = _uow.Categories.Find(id);
            if (model != null)
                return View(model);
            return HttpNotFound();
        }

        //
        // POST: /Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category categoryToUpdate)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // TODO: Add insert logic here
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        if (file.ContentType.Contains("image"))
                        {
                            if (categoryToUpdate.CategoryImageName != null)
                            {
                                FileInfo fileToDelete =
                                    new FileInfo(Path.Combine(Server.MapPath("~/Content/Images"),
                                        categoryToUpdate.CategoryImageName, "image"));
                                if (fileToDelete.Exists)
                                {
                                    fileToDelete.Delete();
                                }
                            }
                            categoryToUpdate.CategoryImageName = file.FileName;
                            file.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), categoryToUpdate.CategoryImageName));
                        }
                    }


                    _uow.Categories.Edit(id, categoryToUpdate);
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
            _uow.Categories.Delete(id);
            _uow.Save();
            return RedirectToAction("Index");

        }
        [AllowAnonymous]
        public FileResult Download(int id)
        {
            var model = _uow.Categories.Find(id);
            if (model.CategoryImageName == null)
            {
                return null;
            }
            return File(Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(model.CategoryImageName)), "image");
        }
        [AllowAnonymous]
        public ActionResult Category(int id)
        {
            var model = _uow.Categories.List(p => p.BrandId == id);
            return View(model);
        }
    }
}