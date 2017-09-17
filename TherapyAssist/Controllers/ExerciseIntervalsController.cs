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
    public class ExerciseIntervalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ExerciseIntervals
        public async Task<ActionResult> Index()
        {
            var exerciseIntervals = db.ExerciseIntervals.Include(e => e.exercise);
            return View(await exerciseIntervals.ToListAsync());
        }

        // GET: ExerciseIntervals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInterval exerciseInterval = await db.ExerciseIntervals.FindAsync(id);
            if (exerciseInterval == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInterval);
        }

        // GET: ExerciseIntervals/Create
        public ActionResult Create()
        {
            ViewBag.Exercise_ID = new SelectList(db.Exercises, "Exercise_ID", "Name");
            return View();
        }

        // POST: ExerciseIntervals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ExerciseInterval_ID,PatientExercise_ID,Repetitions,TimesPerDay,Exercise_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] ExerciseInterval exerciseInterval)
        {
            if (ModelState.IsValid)
            {
                db.ExerciseIntervals.Add(exerciseInterval);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Exercise_ID = new SelectList(db.Exercises, "Exercise_ID", "Name", exerciseInterval.Exercise_ID);
            return View(exerciseInterval);
        }

        // GET: ExerciseIntervals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInterval exerciseInterval = await db.ExerciseIntervals.FindAsync(id);
            if (exerciseInterval == null)
            {
                return HttpNotFound();
            }
            ViewBag.Exercise_ID = new SelectList(db.Exercises, "Exercise_ID", "Name", exerciseInterval.Exercise_ID);
            return View(exerciseInterval);
        }

        // POST: ExerciseIntervals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ExerciseInterval_ID,PatientExercise_ID,Repetitions,TimesPerDay,Exercise_ID,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] ExerciseInterval exerciseInterval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exerciseInterval).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Exercise_ID = new SelectList(db.Exercises, "Exercise_ID", "Name", exerciseInterval.Exercise_ID);
            return View(exerciseInterval);
        }

        // GET: ExerciseIntervals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExerciseInterval exerciseInterval = await db.ExerciseIntervals.FindAsync(id);
            if (exerciseInterval == null)
            {
                return HttpNotFound();
            }
            return View(exerciseInterval);
        }

        // POST: ExerciseIntervals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ExerciseInterval exerciseInterval = await db.ExerciseIntervals.FindAsync(id);
            db.ExerciseIntervals.Remove(exerciseInterval);
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
