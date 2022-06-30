using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AspNote.DataContext;
using AspNote.Models;
using AspNote.ViewModels;
using Microsoft.AspNetCore.Http;
// using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using MySqlConnector;

namespace AspNote.Controllers
{
    public class AccountController : Controller
    {
        private readonly AspNoteDbContext _aspNoteDbContext;
        
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspNoteDbContext())
                {
                    // reduce memory use
                    // var user = db.Users.FirstOrDefault(
                    //     u=>u.UserId == model.UserId && u.UserPassword == model.UserPassword);
                    var user = db.Users.FirstOrDefault(
                        u => u.UserId.Equals(model.UserId) && u.UserPassword.Equals(model.UserPassword));

                    if (user != null)
                    {
                        // contain session 
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                }

                ModelState.AddModelError(string.Empty, "Either of UserId or Password is not found");
            } 

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            // HttpContext.Session.Clear(); >> all session can be cleared 
            return RedirectToAction("index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        ///Post method for the registration 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid) // check if all data required(Not null) are inserted 
            {

                using (var db = new AspNoteDbContext())
                {
                    db.Users.Add(model); //uploading model into memeory
                    db.SaveChanges(); // updating database
                }

                // var db = new AspNoteDbContext();
                // var newUser = new User
                // {
                //     UserId = model.UserId,
                //     UserName = model.UserName,
                //     UserPassword = model.UserPassword,
                //     UserNo = 1
                // };
                // db.Users.Add(newUser);
                // db.SaveChanges();
                // using (var db = new AspNoteDbContext())
                //     string connectionString = "Server=127.0.0.0;Database=myNoteDb;Uid=root;Pwd=dookie91Sql!;";
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