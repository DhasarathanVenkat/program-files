using CRUD_TASK.Data;
using CRUD_TASK.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace CRUD_TASK.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDbContext _context;
		public HomeController(ILogger<HomeController> logger,  ApplicationDbContext context)
		{
			_logger = logger;
			_context= context;
			
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		public IActionResult Create() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Home home)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			try
			{
                // Check if the email already exists in the database
                bool existingHome = _context.table.Any(x => x.Email == home.Email);
                if (existingHome)
                {
                    TempData["Msg"] = "Email already exists. Please use a different email.";
                    return View(); // Return the same view with the entered data
                }


                _context.table.Add(home);
				_context.SaveChanges();
				TempData["Msg"] = "Added Successully";
				return RedirectToAction("Create");
			}
			catch (Exception ex)
			{
				TempData["Msg"] = "Couldnt Added";
				return View();
			}
		}
		public IActionResult Read()
		{
            var home = _context.table.ToList();
            return View(home);
        }

		public IActionResult Details(int id)
		{
			var home = _context.table.Find(id);
			return View(home);
		}
		public IActionResult Edit(int id) 
		{
			var home = _context.table.Find(id);
			return View(home);
		}
		[HttpPost]
		public IActionResult Edit(Home home) 
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			try
			{
				_context.table.Update(home);
				_context.SaveChanges();
				return RedirectToAction("Read");
			}
			catch (Exception ex)
			{
				return View();
			}
		}
		public IActionResult Delete(int id)
		{
			var home = _context.table.Find(id);
			return View(home);
		}
		[HttpPost]
		public IActionResult Delete(Home home)
		{
			if (!ModelState.IsValid)
			{
				return View();
			}
			try
			{
				_context.table.Remove(home);
				_context.SaveChanges();
				return RedirectToAction("Read");
			}
			catch (Exception ex)
			{
				return View();
			}
		}





		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
