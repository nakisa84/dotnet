
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PieStore.Models;
using PieStore.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PieStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies().OrderBy(x => x.Name);
            var homeViewModel = new HomeViewModel
            {
                Title = "Pie Overview",
                Pies = pies.ToList()
            };
           
            return View(homeViewModel);
        }
        public IActionResult Details(int id){
            var pie = _pieRepository.GetPieById(id);
            if(pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
