
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.ViewModel;
using AspnetNote.MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbcontext())
                {
                    // Lingq - 메서드 체이닝
                    // => : A Go to B
                    //var user = db.Users
                    // ./FirstOfDefault(u => u.UserId == Model.UserId && u.UserPassword == model.UserPassword);
                    //var user = db.Users
                    //    .FirstOrDefault(u => u.UserID.Equals(model.UserID) &&
                    //                    u.UserPassword.Equals(model.UserPassword));

                    var user = db.Users
                       .FirstOrDefault(u => u.UserID.Equals(model.UserID) && u.UserPassword.Equals(model.UserPassword));

                    if (user != null)
                    {
                        //HttpContext.Session.SetInt32();

                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);

                        // 로그인에 실패했을 때 
                        //ModelState.AddModelError(string.Empty,"사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
                        //// 사용자 ID 자첵가 회원가입 X 경우 
                        //// ModelState.AddModelError(string.Empty, "사용자 ID 가 존해 하지 않습니다");
                        return RedirectToAction("LoginSucess", "Home");
                    }
                }
                // 로그인에 실패했을 때 
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }    
            return View();
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbcontext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}