using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management.Controllers
{
    public class LoginController : Controller
    {
        StudentManagementEntities db = new StudentManagementEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User obj)
        {
            using(StudentManagementEntities db=new StudentManagementEntities())
            {
                var userdetails = db.Users.Where(x => x.UseName == obj.UseName && x.Password == obj.Password).FirstOrDefault();

                if (userdetails != null)
                {
                    Session["UserID"] = userdetails.ID.ToString();
                    Session["UserName"] = userdetails.UseName.ToString();

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    ModelState.AddModelError("", "Username or Password Incorrect");
                }
            }

            
            return View(obj);
            
        }

        public ActionResult logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}