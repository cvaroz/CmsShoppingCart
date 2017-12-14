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
    public class CashDeskClosingDTOesController : Controller
    {
        private Db db = new Db();

        // GET: Admin/CashDeskClosingDTOes
        public ActionResult Index()
        {
            var cashDesksClosing = db.CashDesksClosing.Include(c => c.Users);
            return View(cashDesksClosing.ToList());
        }

        // GET: Admin/CashDeskClosingDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashDeskClosingDTO cashDeskClosingDTO = db.CashDesksClosing.Find(id);
            if (cashDeskClosingDTO == null)
            {
                return HttpNotFound();
            }
            return View(cashDeskClosingDTO);
        }

        // GET: Admin/CashDeskClosingDTOes/Create
        //public ActionResult Create()
        //{


        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create()
        {
           //List<CashDeskClosingDetailsDTO> cdcDList = new List<CashDeskClosingDetailsDTO>();
            string username = User.Identity.Name;

            int cashDeskClosingId = 0;
         CashDeskClosingDTO cdc = new CashDeskClosingDTO();

            using (Db db = new Db())
            {
                // Init OrderDTO
                
                // Get user id
                var q = db.Users.FirstOrDefault(x => x.Username == username);

                int userId = q.Id;

                // Add to OrderDTO and save
                cdc.UserId = userId;
                cdc.Date = DateTime.Today;

                db.CashDesksClosing.Add(cdc);

                db.SaveChanges();

                // Get inserted id
                cashDeskClosingId = cdc.Id;

               //CashDeskClosingDetailsDTO cdcDetails = new CashDeskClosingDetailsDTO();
               // foreach (var item in cdcDList)
               // {
               // var c = db.OrderDetails.Where(x => x.Orders.CreatedAt == DateTime.Today).FirstOrDefault();
               // int OrderId = c.OrderId;
               // cdcDetails.OrderId = OrderId;
               // cdcDetails.CashDeskClosingId = cashDeskClosingId;
               // cdcDetails.UserId = userId;
               // cdcDetails.Total = c.Products.Price * c.Quantity;
               // db.CashDesksClosingDetails.Add(cdcDetails);
               // db.SaveChanges();
               
               // }
               RedirectToAction("Index");

            }


            return View(cdc);
        }
        //[HttpPost]
        //public ActionResult CreateCDCD(CashDeskClosingDTO cdc)
        //{
        //    List<CashDeskClosingDetailsDTO> cdcDList = new List<CashDeskClosingDetailsDTO>();
        //    using (Db db = new Db())
        //    {

        //        CashDeskClosingDetailsDTO cdcDetails = new CashDeskClosingDetailsDTO();
        //        foreach (var item in cdcDList)
        //        {
        //            var c = db.OrderDetails.Where(x => x.Orders.CreatedAt == DateTime.Today).FirstOrDefault();
        //            int OrderId = c.OrderId;
        //            cdcDetails.OrderId = OrderId;
        //            cdcDetails.CashDeskClosingId = cdc.Id;
        //            cdcDetails.UserId = cdc.UserId;
        //            cdcDetails.Total = c.Products.Price * c.Quantity;
        //            db.CashDesksClosingDetails.Add(cdcDetails);
        //            db.SaveChanges();

        //        }




        //    }
        //        return View();
        //}


        // GET: Admin/CashDeskClosingDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashDeskClosingDTO cashDeskClosingDTO = db.CashDesksClosing.Find(id);
            if (cashDeskClosingDTO == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", cashDeskClosingDTO.UserId);
            return View(cashDeskClosingDTO);
        }

        // POST: Admin/CashDeskClosingDTOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,Date")] CashDeskClosingDTO cashDeskClosingDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cashDeskClosingDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", cashDeskClosingDTO.UserId);
            return View(cashDeskClosingDTO);
        }

        // GET: Admin/CashDeskClosingDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CashDeskClosingDTO cashDeskClosingDTO = db.CashDesksClosing.Find(id);
            if (cashDeskClosingDTO == null)
            {
                return HttpNotFound();
            }
            return View(cashDeskClosingDTO);
        }

        // POST: Admin/CashDeskClosingDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CashDeskClosingDTO cashDeskClosingDTO = db.CashDesksClosing.Find(id);
            db.CashDesksClosing.Remove(cashDeskClosingDTO);
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
