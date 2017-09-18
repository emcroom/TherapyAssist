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

namespace TherapyAssist.Controllers
{
    public class ExerciseTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.ExerciseTypes.ToListAsync());
        }

        // GET: ExerciseTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = await db.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ExerciseType_ID,Name,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseTypes.Add(exerciseType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(exerciseType);
        }

        // GET: ExerciseTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = await db.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ExerciseType_ID,Name,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] ExerciseType exerciseType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exerciseType);
        }

        // GET: ExerciseTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseType exerciseType = await db.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return HttpNotFound();
            }
            return View(exerciseType);
        }

        // POST: ExerciseTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExerciseType exerciseType = await db.ExerciseTypes.FindAsync(id);
            db.ExerciseTypes.Remove(exerciseType);
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
