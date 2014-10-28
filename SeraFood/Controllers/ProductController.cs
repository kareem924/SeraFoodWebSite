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
    public class ProductController : Controller
    {
        IUnitOfWork _uow;
        public ProductController()
        {
            _uow = new UnitOfWork();
        }
        public ProductController(IUnitOfWork uof) // Fake 
        {
            _uow = uof;
        }
        //
        // GET: /Product/
        public ActionResult Index(int? page)
        {
            var products = _uow.Products.List();
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = products.OrderBy(p => p.ProductName).ToPagedList(pageNumber, 14); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string productName, int? page)
        {
            var products = _uow.Products.List(p => p.ProductName.Contains(productName));
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfProducts = products.OrderBy(p => p.ProductName).ToPagedList(pageNumber, 14); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfProducts = onePageOfProducts;
            return View();
        }
        public ActionResult Create()
        {
            ViewBag.Categories = new SelectList(_uow.Categories.List(), "CategoryId", "CategoryName");
            return View();
        }

        //
        // POST: /Posts/Create
        [HttpPost]

        public ActionResult Create(Product productToCreate)
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
                        productToCreate.ProductImage = file.FileName;
                        file.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), productToCreate.ProductImage));
                    }
                    _uow.Products.Add(productToCreate);
                    _uow.Save();
                    //
                    return RedirectToAction("Index");
                }
                return View("Create", productToCreate);
            }
            catch
            {
                return View("error");
            }
        }

        public ActionResult Details(int id)
        {

            var model = _uow.Products.Find(id);
            ViewBag.Categories = new SelectList(_uow.Categories.List(), "CategoryId", "CategoryName");
            if (model != null)
                return View(model);
            return HttpNotFound();
        }
        public ActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_uow.Categories.List(), "CategoryId", "CategoryName");
            var model = _uow.Products.Find(id);
            if (model != null)
                return View(model);
            return HttpNotFound();
        }

        //
        // POST: /Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product productToUpdate)
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
                            if (productToUpdate.ProductImage != null)
                            {
                                FileInfo fileToDelete =
                                    new FileInfo(Path.Combine(Server.MapPath("~/Content/Images"),
                                        productToUpdate.ProductImage, "image"));
                                if (fileToDelete.Exists)
                                {
                                    fileToDelete.Delete();
                                }
                            }
                            productToUpdate.ProductImage = file.FileName;
                            file.SaveAs(Path.Combine(Server.MapPath("~/Content/Images"), productToUpdate.ProductImage));
                        }
                    }


                    _uow.Products.Edit(id, productToUpdate);
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
            _uow.Products.Delete(id);
            _uow.Save();
            return RedirectToAction("Index");

        }
        [AllowAnonymous]
        public FileResult Download(int ProductId)
        {
            var model = _uow.Products.Find(ProductId);
            if (model.ProductImage == null)
            {
                return null;
            }
            return File(Path.Combine(Server.MapPath("~/Content/Images"), Path.GetFileName(model.ProductImage)), "image");
        }
        [AllowAnonymous]
        public ActionResult Prodtucts(int id)
        {
            var model = _uow.Products.List(p => p.CategoryId == id);
           return View(model);
        }
    }
}