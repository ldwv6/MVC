using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspnetNote.MVC6.Controllers
{
    public class NoteController : Controller
    {
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            using(var db = new AspnetNoteDbcontext())
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }

        public IActionResult Add()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            if (ModelState.IsValid)
            {
                using(var db = new AspnetNoteDbcontext())
                {
                    db.Notes.Add(model);

                    //var result = db.SaveChanges();

                    if(db.SaveChanges() > 0)
                    {
                        return Redirect("Index");
                    }
                 
                    //return RedirectToAction("Index", "Home");               
                }

                ModelState.AddModelError(string.Empty, "게시물을 저장할 수 없습니다.");
            }
            return View(model);
        }


        public IActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        public IActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}