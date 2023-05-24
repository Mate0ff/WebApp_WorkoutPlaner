using Kucharz_Liberacki_Kopanko.Models;
using Kucharz_Liberacki_Kopanko.Models.DbModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

public class UserController : Controller
{
    private readonly DatabaseContext _db;

    public UserController()
    {
        _db = new DatabaseContext();
    }

    [HttpGet]
    public ActionResult Create()
    {
        return View(new User());
    }

    [HttpPost]
    public ActionResult Create(User user)
    {
        if (ModelState.IsValid)
        {
            // Dodaj nowego użytkownika do bazy danych
            _db.User.Add(user);
            _db.SaveChanges();

            // Przekieruj do widoku sukcesu lub innej akcji
            return RedirectToAction("ViewAll");
        }

        // Jeśli walidacja modelu nie powiodła się, zwróć widok Create z błędami walidacji
        return View(user);
    }

    public ActionResult ViewAll()
    {
        List<User> users = _db.User.ToList();

        return View(users);
    }

    [HttpGet]
    public ActionResult Delete(int id)
    {
        User user = _db.User.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        User user = _db.User.Find(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        _db.User.Remove(user);
        _db.SaveChanges();
        return RedirectToAction("ViewAll");
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        User obj;
        using (DatabaseContext db = new DatabaseContext())
        {
            obj = db.User.FirstOrDefault(o => o.UserId == id);
        }
        return View(obj);
    }

    [HttpPost]
    public ActionResult Edit(User ex)
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



}
