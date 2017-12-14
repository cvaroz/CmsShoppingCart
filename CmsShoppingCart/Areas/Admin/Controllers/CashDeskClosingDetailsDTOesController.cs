using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CmsShoppingCart.Areas.Admin.Models;
using CmsShoppingCart.Models.Data;

namespace CmsShoppingCart.Areas.Admin.Controllers
{
    public class CashDeskClosingDetailsDTOesController : Controller
    {
        private Db db = new Db();

        // GET: Admin/CashDeskClosingDetailsDTOes
        public ActionResult Index()
        {
            var cashDesksClosingDetails = db.CashDesksClosingDetails.Include(c => c.CashDesksClosing).Include(c => c.Orders).Include(c => c.Users).ToList();
            decimal total = 0m;

            foreach (var item in cashDesksClosingDetails)
            {
                total += (item.Orders.Quantity*item.Orders.Products.Price);
            }

            ViewBag.GrandTotal = total;
            return View(cashDesksClosingDetails.ToList());
        }

        // GET: Admin/CashDeskClosingDetailsDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashDeskClosingDetailsDTO cashDeskClosingDetailsDTO = db.CashDesksClosingDetails.Find(id);
            if (cashDeskClosingDetailsDTO == null)
            {
                return HttpNotFound();
            }
            return View(cashDeskClosingDetailsDTO);
        }

        // GET: Admin/CashDeskClosingDetailsDTOes/Create
        public ActionResult Create()
        {
            string username = User.Identity.Name;
            ViewBag.CashDeskClosingId = new SelectList(db.CashDesksClosing.Where(x => x.Date == DateTime.Today), "Id", "Id");
            ViewBag.OrderId = new SelectList(db.OrderDetails, "Id", "Id");
           
            ViewBag.Total=
            ViewBag.UserId = new SelectList(db.Users.Where(x => x.Username == username), "Id", "FirstName");
            return View();
        }

  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CashDeskClosingDetailsDTO cashDeskClosingDetailsDTO)
        {
            string username = User.Identity.Name;
            
            
            if (ModelState.IsValid)
            {
                
                db.CashDesksClosingDetails.Add(cashDeskClosingDetailsDTO);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CashDeskClosingId = new SelectList(db.CashDesksClosing.Where(x => x.Date == DateTime.Today), "Id", "Id", cashDeskClosingDetailsDTO.CashDeskClosingId);
            ViewBag.OrderId = new SelectList(db.OrderDetails, "Id", "Id", cashDeskClosingDetailsDTO.OrderId);
            ViewBag.UserId = new SelectList(db.Users.Where(x => x.Username == username), "Id", "FirstName", cashDeskClosingDetailsDTO.UserId);
           
            //cashDeskClosingDetailsDTO.Total = cashDeskClosingDetailsDTO.Orders.Products.Price * cashDeskClosingDetailsDTO.Orders.Quantity;
            return View(cashDeskClosingDetailsDTO);
        }

        // GET: Admin/CashDeskClosingDetailsDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashDeskClosingDetailsDTO cashDeskClosingDetailsDTO = db.CashDesksClosingDetails.Find(id);
            if (cashDeskClosingDetailsDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CashDeskClosingId = new SelectList(db.CashDesksClosing, "Id", "Id", cashDeskClosingDetailsDTO.CashDeskClosingId);
            ViewBag.OrderId = new SelectList(db.OrderDetails, "Id", "Id", cashDeskClosingDetailsDTO.OrderId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", cashDeskClosingDetailsDTO.UserId);
            
            return View(cashDeskClosingDetailsDTO);
        }

        // POST: Admin/CashDeskClosingDetailsDTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderId,UserId,CashDeskClosingId,Total")] CashDeskClosingDetailsDTO cashDeskClosingDetailsDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cashDeskClosingDetailsDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CashDeskClosingId = new SelectList(db.CashDesksClosing, "Id", "Id", cashDeskClosingDetailsDTO.CashDeskClosingId);
            ViewBag.OrderId = new SelectList(db.OrderDetails, "Id", "Id", cashDeskClosingDetailsDTO.OrderId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", cashDeskClosingDetailsDTO.UserId);
            return View(cashDeskClosingDetailsDTO);
        }

        // GET: Admin/CashDeskClosingDetailsDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashDeskClosingDetailsDTO cashDeskClosingDetailsDTO = db.CashDesksClosingDetails.Find(id);
            if (cashDeskClosingDetailsDTO == null)
            {
                return HttpNotFound();
            }
            return View(cashDeskClosingDetailsDTO);
        }

        // POST: Admin/CashDeskClosingDetailsDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CashDeskClosingDetailsDTO cashDeskClosingDetailsDTO = db.CashDesksClosingDetails.Find(id);
            db.CashDesksClosingDetails.Remove(cashDeskClosingDetailsDTO);
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
