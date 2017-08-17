using Portfolio1.Infrastructure.Abstract;
using Portfolio1.Models;
using Portfolio1.Repositories;
using Portfolio1Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Portfolio1.Controllers
{
    public class MainController : Controller
    {
        IImageRepository repo;

        public MainController(IImageRepository imagesData)
        {
            repo = imagesData;
        }

        // GET: Main
        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult Slider()
        {
            return PartialView(repo.dataImages);
        }

        public PartialViewResult AddComment()
        {
                return PartialView();
        }

        [HttpPost]
        public ActionResult AddComment(Portfolio1Repository.Comments comment)
        {

            using (Portfolio1DB context = new Portfolio1DB())
            {
                string cookieName = FormsAuthentication.FormsCookieName; 
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];

                if (authCookie != null)
                {
                    FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); 
                    string UserName = ticket.Name;

                    Users user = context.Users.ToList().Where(u => u.LoginName.Equals(UserName)).FirstOrDefault();

                    comment.Users = user;
                    comment.UserID = user.UserID;
                    comment.CommentDateTime = DateTime.Now;

                    context.Comments.Add(comment);
                    context.SaveChanges();

                }

                return RedirectToAction("Index");
            }
        }

        public PartialViewResult Comments()
        {
            return PartialView();
        }
    }
}