﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MVC5Course.Models;
using X.PagedList;

namespace MVC5Course.Controllers
{
    public class ProductsController : BaseController
    {
        private FabricsEntities db = new FabricsEntities();

        // GET: Products
        public ActionResult Index(int pageNo = 1)
        {
            var data = db.Product
                .OrderByDescending(p => p.ProductId)
                .ToPagedList(pageNo, 10);

            return View(data);
        }

        public ActionResult Index2()
        {
            var data = db.Product
                .Where(x => x.Active == true)
                .OrderByDescending(p => p.ProductId)
                .Take(10)
                .Select(x => new ProductViewModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.Price,
                    Stock = x.Stock
                })
                .ToList();
            return View(data);
        }

        public ActionResult AddNewProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewProduct(ProductViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var product = new Product
            {
                ProductId = data.ProductId,
                Active = true,
                Price = data.Price,
                Stock = data.Stock,
                ProductName = data.ProductName
            };
            db.Product.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index2");
        }

        public ActionResult EditOne(int id)
        {
            var data = db.Product.Find(id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditOne(int id, ProductViewModel data)
        {
            if (!ModelState.IsValid)
            {
                return View(data);
            }

            var one = db.Product.Find(id);
            one.ProductName = data.ProductName;
            one.Stock = data.Stock;
            one.Price = data.Price;

            db.SaveChanges();

            return RedirectToAction("Index2");

        }

        public ActionResult DeleteOne(int id)
        {
            var one = db.Product.Find(id);
            
            if (one == null)
                return HttpNotFound();

            db.Product.Remove(one);
            db.SaveChanges();

            return RedirectToAction("Index2");
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,ProductName,Price,Active,Stock")] Product product)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
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
