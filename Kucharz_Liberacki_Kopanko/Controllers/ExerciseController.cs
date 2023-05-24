using Kucharz_Liberacki_Kopanko.Models;
using Kucharz_Liberacki_Kopanko.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kucharz_Liberacki_Kopanko.Controllers
{
    public class ExerciseController : Controller
    {
        // GET: Exercise
        
        [HttpGet]
        public ActionResult Create() 
        {       
            return View(new Exercise());
        }
        
        
        [HttpPost]
        public ActionResult Create(Exercise exercise, ExDetails details)
        {
            if(ModelState.IsValid) 
            { 
                using(DatabaseContext db = new DatabaseContext()) 
                { 
                    db.Exercise.Add(exercise);
                    db.ExDetails.Add(details);
                    db.SaveChanges();
                }
                return RedirectToAction("ViewAll");
            }

            return View(new Exercise());
        }

        [HttpGet]
        public ActionResult ViewAll() 
        { 
            List<Exercise> list;
            using (DatabaseContext db = new DatabaseContext()) 
            { 
                list = db.Exercise.ToList();
            }
            return View(list);
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            Exercise obj;
            using (DatabaseContext db = new DatabaseContext())
            {
                obj = db.Exercise.FirstOrDefault(o => o.ExerciseId == id);
            }

            return View(obj);
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            Exercise obj;
            using (DatabaseContext db = new DatabaseContext())
            {
                obj = db.Exercise.FirstOrDefault(o => o.ExerciseId == id);
            }
            return View(obj);
        }

        [HttpPost]
        public ActionResult Edit(Exercise ex)
        {

            if (ModelState.IsValid) 
            {
                return View(ex);
            }
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Entry(ex).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }

        [HttpGet]
        public ActionResult Delete(int id) 
        {
            Exercise obj;

            using (DatabaseContext db = new DatabaseContext())
            {
                obj = db.Exercise.FirstOrDefault(o => o.ExerciseId == id);

            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int? id)
        {
            Exercise obj;
            ExDetails exDetails;
            using (DatabaseContext db = new DatabaseContext())
            {
                obj = db.Exercise.FirstOrDefault(o => o.ExerciseId == id);
                exDetails = db.ExDetails.FirstOrDefault(o => o.ExDetailsId == id);
                db.Exercise.Remove(obj);
                db.ExDetails.Remove(exDetails);
                db.SaveChanges();
            }
            return RedirectToAction("ViewAll");
        }




    }
}


