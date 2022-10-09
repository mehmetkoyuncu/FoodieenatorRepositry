using Foodieenator.Entities.Entities;
using Foodieenator.Service.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foodieenator.UI.Controllers
{
	public class DashBoardController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult RenderFoodCategory()
		{
			List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();
			return View(foodCategories);
		}
		[HttpPost]
		public ActionResult AddFoodCategory(FoodCategory category)
		{
			new FoodCategoryService().AddOrUpdate(category);
			List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();

			return View("RenderFoodCategory", foodCategories);
		}
		public ActionResult RemoveFoodCategory(FoodCategory category)
		{
			new FoodCategoryService().HardDelete(category);
			List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();

			return View("RenderFoodCategory", foodCategories);
		}
		public ActionResult RenderFood()
		{
			List<Food> foods = new FoodService().GetAll();
			List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();
			return View(Tuple.Create<List<Food>, List<FoodCategory>>(foods, foodCategories));
		}
		[HttpPost]
		public ActionResult AddFood(Food food, string IsPublish, HttpPostedFileBase file)
		{

			if (IsPublish == "on")
				food.IsPublish = true;
			else
				food.IsPublish = false;

			string image = SaveFile(file);
			if (string.IsNullOrEmpty(image) == false)
			{
				food.Image = image;
			}

			new FoodService().AddOrUpdate(food);
			List<Food> foods = new FoodService().GetAll();
			List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();

			var tuple = Tuple.Create<List<Food>, List<FoodCategory>>(foods, foodCategories);

			return View("RenderFood", tuple);
		}
		private string SaveFile(HttpPostedFileBase file)
		{
			string imagePath = null;

			if (file != null)
			{

				string path = Path.Combine(Server.MapPath("~/images/fileImages"),
													 Path.GetFileName(file.FileName));
				file.SaveAs(path);

				imagePath = "/images/fileImages/" + Path.GetFileName(file.FileName);
			}

			return imagePath;

		}
		public ActionResult RemoveFood(Food food)
		{
			new FoodService().HardDelete(food);
			List<Food> foods = new FoodService().GetAll();
			List<FoodCategory> foodCategories = new FoodCategoryService().GetAll();

			var tuple = Tuple.Create<List<Food>, List<FoodCategory>>(foods, foodCategories);
			return View("RenderFood", tuple);

		}
		public ActionResult RenderUser()
		{
			List<User> users = new UserService().GetAll();
			return View(users);
		}
		[HttpPost]
		public ActionResult AddUser(User user)
		{
			new UserService().AddOrUpdate(user);
			List<User> users = new UserService().GetAll();
			return View("RenderUser", users);
		}
		public ActionResult RemoveUser(User user)
		{
			new UserService().HardDelete(user);
			List<User> users = new UserService().GetAll();
			return View("RenderUser", users);

		}
		public ActionResult RenderReservation()
		{
			List<Reservation> users = new ReservationService().GetAll();
			return View(users);
		}
		[HttpPost]
		public ActionResult AddReservation(Reservation reservation)
		{
			new ReservationService().AddOrUpdate(reservation);
			List<Reservation> reservations = new ReservationService().GetAll();
			return View("RenderReservation", reservations);
		}
		public ActionResult RemoveReservation(Reservation reservation)
		{
			new ReservationService().HardDelete(reservation);
			List<Reservation> reservations = new ReservationService().GetAll();
			return View("RenderReservation", reservations);

		}


	}
}