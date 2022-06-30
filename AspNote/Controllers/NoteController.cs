using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNote.DataContext;
using AspNote.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNote.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY")==null)
            {
                return RedirectToAction("Login", "Account");
            }

            // var list = new List<Note>();
            using (var db = new AspNoteDbContext())
            {
                var list = db.Notes.ToList();
                return View(list); // in the index view page, the object (list) in View must be displayed to "Model"
            }
            
        }

        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY")==null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY")==null)
            {
                return RedirectToAction("Login", "Account");
            }

            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());
            
            if (ModelState.IsValid)
            {
                using (var db = new AspNoteDbContext())
                {
                    db.Notes.Add(model);
                    if (db.SaveChanges() > 0)
                    {
                        return Redirect("Index");
                    }
                }
                ModelState.AddModelError(string.Empty, "Impossible to post your article");
            }

            return View(model);
        }

        public IActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY")==null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        public IActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY")==null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}