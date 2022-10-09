using Foodieenator.Entities.Entities;
using Foodieenator.Service.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodieenator.WebUI.Controllers
{
    public class DashBoardController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderFoodCategory()
        {
            return View();
        }
        public ActionResult GetFoodCategoryList()
        {
            List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();
            return PartialView(@"~/Views/Partials/_FoodCategoryPartial.cshtml", foodCategories);
        }
    }
}