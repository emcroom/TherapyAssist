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
    public class PatientExercisesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientExercises
        public async Task<ActionResult> Index()
        {
            var patientExercise = db.PatientExercise.Include(p => p.ExerciseInterval);
            return View(await patientExercise.ToListAsync());
        }

        // GET: PatientExercises/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientExercise patientExercise = await db.PatientExercise.FindAsync(id);
            if (patientExercise == null)
            {
                return HttpNotFound();
            }
            return View(patientExercise);
        }

        // GET: PatientExercises/Create
        public ActionResult Create()
        {
            ViewBag.ExerciseInterval_ID = new SelectList(db.ExerciseIntervals, "ExerciseInterval_ID", "CreatedBy");
            return View();
        }

        // POST: PatientExercises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "PatientExercise_ID,ExerciseInterval_ID,Patient_ID,isComplete,CompletedDateTime,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] PatientExercise patientExercise)
        {
            if (ModelState.IsValid)
            {
                db.PatientExercise.Add(patientExercise);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ExerciseInterval_ID = new SelectList(db.ExerciseIntervals, "ExerciseInterval_ID", "CreatedBy", patientExercise.ExerciseInterval_ID);
            return View(patientExercise);
        }

        // GET: PatientExercises/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientExercise patientExercise = await db.PatientExercise.FindAsync(id);
            if (patientExercise == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExerciseInterval_ID = new SelectList(db.ExerciseIntervals, "ExerciseInterval_ID", "CreatedBy", patientExercise.ExerciseInterval_ID);
            return View(patientExercise);
        }

        // POST: PatientExercises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "PatientExercise_ID,ExerciseInterval_ID,Patient_ID,isComplete,CompletedDateTime,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy")] PatientExercise patientExercise)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientExercise).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ExerciseInterval_ID = new SelectList(db.ExerciseIntervals, "ExerciseInterval_ID", "CreatedBy", patientExercise.ExerciseInterval_ID);
            return View(patientExercise);
        }

        // GET: PatientExercises/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientExercise patientExercise = await db.PatientExercise.FindAsync(id);
            if (patientExercise == null)
            {
                return HttpNotFound();
            }
            return View(patientExercise);
        }

        // POST: PatientExercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PatientExercise patientExercise = await db.PatientExercise.FindAsync(id);
            db.PatientExercise.Remove(patientExercise);
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
