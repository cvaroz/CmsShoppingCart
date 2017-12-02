using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CmsShoppingCart.Models.Data;

namespace CmsShoppingCart.Areas.Admin.Controllers
{
    public class UserDTOesController : Controller
    {
        private Db db = new Db();

        // GET: Admin/UserDTOes
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Admin/UserDTOes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = db.Users.Find(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            return View(userDTO);
        }

        // GET: Admin/UserDTOes/Create
        public ActionResult Create()
        {
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(userDTO);
                db.SaveChanges();

                int id = userDTO.Id;

                UserRoleDTO userRolesDTO = new UserRoleDTO()
                {
                    UserId = id,
                    RoleId = 3
                };

                db.UserRoles.Add(userRolesDTO);
                db.SaveChanges();
   
            return RedirectToAction("Index");
            }


            return View(userDTO);
        }

        // GET: Admin/UserDTOes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = db.Users.Find(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            return View(userDTO);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,Username,Password")] UserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDTO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDTO);
        }

        // GET: Admin/UserDTOes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO userDTO = db.Users.Find(id);
            if (userDTO == null)
            {
                return HttpNotFound();
            }
            return View(userDTO);
        }

        // POST: Admin/UserDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDTO userDTO = db.Users.Find(id);
            db.Users.Remove(userDTO);
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
