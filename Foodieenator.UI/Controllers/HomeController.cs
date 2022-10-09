using Foodieenator.Entities.Entities;
using Foodieenator.Service.Concrete;
using Foodieenator.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodieenator.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Food> foods = new FoodService().GetAll();
            List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();
            return View(Tuple.Create<List<Food>, List<FoodCategory>>(foods, foodCategories));
        }
        public ActionResult RenderLoginPage()
        {
            return View();
        }

        public ActionResult Login(string userName, string password)
        {
            int control = new UserService().Login(userName, password);
            if (control==0)
            {
                ViewBag.ErrorMessage = "Kullanıcı Adı veya Şifre Hatalıdır.";
                return View("RenderLoginPage");
            }
             
            else if(control==2)
            {
                LoginUser.UserName = userName;
                LoginUser.Password = password;
                LoginUser.Role = "Admin";
                return View("../DashBoard/Index");
            }
            else if (control == 1)
            {
                LoginUser.UserName = userName;
                LoginUser.Password = password;
                LoginUser.Role = "User";
                return View("../DashBoard/Index");
            }
            else
            {
                return View("Index");
            }

        }
        public ActionResult LogOut()
        {
                LoginUser.UserName = null;
                LoginUser.Password = null;
                LoginUser.Role = null;
                return View("RenderLoginPage");
        }
        public ActionResult RenderReservationPage()
        {

            return View();
        }
        public ActionResult AddReservation(Reservation reservation)
        {
            try
            {
                new ReservationService().AddOrUpdate(reservation);
                ViewBag.Message = "Rezervasyonunuz başarıyla oluşturulmıştur";
            }
            catch (Exception)
            {

                ViewBag.Message = "Rezervasyon alınırken bir hata oluştu.";
            }

            return View("RenderReservationPage");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}