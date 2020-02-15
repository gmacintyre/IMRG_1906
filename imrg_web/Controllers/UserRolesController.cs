using imrg_web.BLL.Roles;
using imrg_web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace imrg_web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserRolesController : Controller
    {

        private imrgEntities db = new imrgEntities();
        // GET: UserRoles
        public ActionResult Index()
        {
            var users = db.AspNetUsers.ToList();
            var roles = db.AspNetRoles.ToList();
            return View(users);
        }

        public ActionResult AssignUserRoles(string id)
        {
            var user = db.AspNetUsers.Find(id);
            if(user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            db.Entry(user).Collection(x => x.AspNetRoles).Load();
            var assignedRoles = user.AspNetRoles.Select(x => x.Id);
            var roles = db.AspNetRoles.Where(x => !assignedRoles.Contains(x.Id)).ToList();

            var assignUserRolesModel = AssignUserRolesViewModel.Create(user, roles);

            return View(assignUserRolesModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignUserRoles([Bind(Include= "UserId, RoleId")]AssignUserRolesViewModel model)
        {
            var role = db.AspNetRoles.Find(model.RoleId);
            if(role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.AspNetUsers.Find(model.UserId);
            if(user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if(user.AspNetRoles.FirstOrDefault(x=> x.Id == role.Id) == null)
            {
                user.AspNetRoles.Add(role);
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("AssignUserRoles", new { id = user.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUserRoles([Bind(Include = "UserId, RoleId")]AssignUserRolesViewModel model)
        {
            var role = db.AspNetRoles.Find(model.RoleId);
            if (role == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var user = db.AspNetUsers.Find(model.UserId);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (user.AspNetRoles.FirstOrDefault(x => x.Id == role.Id) != null)
            {
                user.AspNetRoles.Remove(role);
                db.Entry(role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("AssignUserRoles", new { id = user.Id });
        }



    }
}