using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TherapyAssist.Models;
using Microsoft.AspNet.Identity;

namespace TherapyAssist.Controllers
{
    public class DailyLogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DailyLogs
        public async Task<ActionResult> Index()
        {
            var patient = db.Patient.Where(x => x.UserId == User.Identity.GetUserId()).First();
            //patient.
            var dailyLog = db.DailyLog.Include(d => d.UserDetail);
            return View(await dailyLog.ToListAsync());
        }

        // GET: DailyLogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyLog dailyLog = await db.DailyLog.FindAsync(id);
            if (dailyLog == null)
            {
                return HttpNotFound();
            }
            return View(dailyLog);
        }

        // GET: DailyLogs/Create
        public ActionResult Create()
        {
            ViewBag.User_ID = new SelectList(db.UserDetail, "User_ID", "FirstName");
            return View();
        }

        // POST: DailyLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "DailyLog_ID,User_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] DailyLog dailyLog)
        {
            if (ModelState.IsValid)
            {
                db.DailyLog.Add(dailyLog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.User_ID = new SelectList(db.UserDetail, "User_ID", "FirstName", dailyLog.User_ID);
            return View(dailyLog);
        }

        // GET: DailyLogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyLog dailyLog = await db.DailyLog.FindAsync(id);
            if (dailyLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.User_ID = new SelectList(db.UserDetail, "User_ID", "FirstName", dailyLog.User_ID);
            return View(dailyLog);
        }

        // POST: DailyLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "DailyLog_ID,User_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] DailyLog dailyLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyLog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.User_ID = new SelectList(db.UserDetail, "User_ID", "FirstName", dailyLog.User_ID);
            return View(dailyLog);
        }

        // GET: DailyLogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyLog dailyLog = await db.DailyLog.FindAsync(id);
            if (dailyLog == null)
            {
                return HttpNotFound();
            }
            return View(dailyLog);
        }

        // POST: DailyLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DailyLog dailyLog = await db.DailyLog.FindAsync(id);
            db.DailyLog.Remove(dailyLog);
            await db.SaveChangesAsync();
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
