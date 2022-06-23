using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AspNote.DataContext;
using AspNote.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace AspNote.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid) // check if all data required(Not null) are inserted 
            {
                using (var db = new AspNoteDbContext())
                {
                    db.Users.Add(model); // adding data into memory
                    db.SaveChanges(); // updating database

            }

            // string connectionString = "Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;";
                // using (var db = new AspNoteDbContext())
                // {
                //     User model1 = new User();
                //     model1.UserId = model.UserId;
                //     model1.UserName = model.UserName;
                //     model1.UserPassword = model.UserPassword;
                //     db.Add(model1);
                //     db.SaveChanges();
                // }


                return RedirectToAction("Index", "Home"); // move to index view in the home controller
            }

            return View(model);
        }
    }
} 