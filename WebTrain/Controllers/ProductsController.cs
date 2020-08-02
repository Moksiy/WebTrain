using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTrain.DAL;
using WebTrain.Models;

namespace WebTrain.Controllers
{
    public class ProductsController : Controller
    {
        private WebContext db = new WebContext();

        // GET: Products
        public ViewResult Index(string sortProducts, string searchString)
        {
            ViewBag.CodeSortParm = String.IsNullOrEmpty(sortProducts) ? "Code desc" : "";
            ViewBag.NameSortParm = sortProducts == "Name" ? "Name desc" : "Name";
            ViewBag.PriceSortParm = sortProducts == "Price" ? "Price desc" : "Price";
            ViewBag.CategorySortParm = sortProducts == "Category" ? "Category desc" : "Category";

            //Получаем товары из бд
            var products = from s in db.Products select s;

            //Условие поиска
            if(!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(
                    s => s.Name.ToUpper().Contains(searchString.ToUpper()) || 
                    s.Code.ToUpper().Contains(searchString.ToUpper()) || 
                    s.Category.ToUpper().Contains(searchString.ToUpper()));
            }

            switch(sortProducts)
            {
                case "Code desc":
                    products = products.OrderByDescending(s => s.Code);
                    break;

                case "Name":
                    products = products.OrderBy(s => s.Name);
                    break;

                case "Name desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;

                case "Price":
                    products = products.OrderBy(s => s.Price);
                    break;

                case "Price desc":
                    products = products.OrderByDescending(s => s.Price);
                    break;

                case "Category":
                    products = products.OrderBy(s => s.Category);
                    break;

                case "Category desc":
                    products = products.OrderByDescending(s => s.Category);
                    break;

                default:
                    products = products.OrderBy(s => s.Code);
                    break;
            };
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Code,Name,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.ID = Guid.NewGuid();
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Code,Name,Price,Category")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
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
