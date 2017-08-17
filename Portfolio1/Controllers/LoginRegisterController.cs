using Portfolio1.Infrastructure.Abstract;
using Portfolio1.Models;
using Portfolio1.PasswordHash;
using Portfolio1Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Portfolio1.Controllers
{
    public class LoginRegisterController : Controller
    {
        IAuthProvider authProvider;
        public LoginRegisterController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ActionResult NoAuthenticated(string returnUrl = null)
        {
            return View();
        }

        public ActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel loginData = null, string returnUrl = null)
        {
            Portfolio1DB model = new Portfolio1DB();
            Users user = model.Users.ToList().Where(u => u.LoginName.Equals(loginData.Login)).FirstOrDefault();

            if(user == null)
            {
                ModelState.AddModelError("Login", "Nie znaleziono użytkownika o takim loginie.");
            }
            else
            {
                bool flag = Helper.VerifyHash(loginData.Password, "SHA512", user.PasswordHash);
                if (flag == false)
                {
                    ModelState.AddModelError("Password", "Hasło jest niepoprawne.");
                }
                else
                {
                    if (authProvider.Authenticate(loginData.Login, loginData.Password))
                    {
                        if (string.IsNullOrEmpty(returnUrl))
                        {
                            return View("Index", "Main");
                        }
                        else
                        {
                            return Redirect(returnUrl);
                        }
                    }
                }
            }

            return View(loginData);
        }

        public ActionResult Register(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerData = null,string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            bool result = false;

            if (ModelState.IsValid)
            {
                if (!registerData.Password.Equals(registerData.Password2))
                {
                    ModelState.AddModelError("Password2", "Hasła muszą być takie same");
                }
                else
                {
                    using (Portfolio1DB model = new Portfolio1DB())
                    {
                        if (model.Users.Select(u => u.LoginName).ToList().Contains(registerData.Login))
                        {
                            ModelState.AddModelError("Login", "Użytkownik o takim loginie już istnieje.");
                        }
                        else
                        {
                            Users user = new Users()
                            {
                                LoginName = registerData.Login,
                                PasswordHash = Helper.ComputeHash(registerData.Password, "SHA512", null),
                            };
                            model.Users.Add(user);

                            model.SaveChanges();

                            result = true;
                        }
                    }
                }
            }

            if (result)
            {
                authProvider.Authenticate(registerData.Login, registerData.Password);

                if (string.IsNullOrEmpty(returnUrl))
                {
                    return View("Index", "Main");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            return View(registerData);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Main");
        }
    }
}