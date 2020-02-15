using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using imrg_web.BLL.Calendar;
using imrg_web.Models;
using Microsoft.AspNet.Identity;

namespace imrg_web.Controllers
{
    [Authorize(Roles="Admin,Marketer")]
    public class EventsController : Controller
    {
        private imrgEntities db = new imrgEntities();

        // GET: Events
        [AllowAnonymous]
        public ActionResult Index()
        {
            var @evenets = db.Events.ToList();
            return View(@evenets);
        }
        
        [AllowAnonymous]
        public JsonResult Calendar(string start, string end)
        {
            var @events = new List<Event>();
            if (DateTime.TryParse(start, out DateTime startDate) && DateTime.TryParse(end, out DateTime endDate))
            {
                
                @events = db.Events.Where(x => x.StartDateTime >= startDate && x.EndDateTime <= endDate).ToList();
            }
            else
            {
                @events = db.Events.ToList();
            }

            var jsonModel = JsonEventModel.CreateList(@events);
            return Json(jsonModel, JsonRequestBehavior.AllowGet);
        }

        // GET: Events/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }


        // GET: Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventName,StartDateTime,EndDateTime,Description,Location")] Event @event)
        {

            if(Guid.TryParse(User.Identity.GetUserId(), out Guid userId))
            {
                @event.Inserted_By = userId;
                @event.Inserted_Date = DateTime.Now;
            }
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,EventName,Inserted_By,Inserted_Date,StartDateTime,EndDateTime,Description,Location")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
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
