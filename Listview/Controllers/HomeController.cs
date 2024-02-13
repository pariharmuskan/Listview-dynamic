using Listview.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Listview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ADbContext _context;

      
        public HomeController(ADbContext context)


        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetData()
        {
            var animals = _context.Animals.ToList();
            return Json(animals);

        }

            public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Privacy(Animal Ani, List<IFormFile> AniImage)
        {
            foreach (var item in AniImage)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);

                        Ani.AniImage = stream.ToArray();

                    }
                }
            }

            _context.Animals.Add(Ani);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
