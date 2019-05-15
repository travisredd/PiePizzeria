using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PiePizzeria.Models;
using PiePizzeria.ViewModels;

namespace PiePizzeria.Controllers
{
    public class HomeController : Controller
    {

        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var pies = _pieRepository.GetAllPies().OrderBy(p => p.Name);

            var homeViewModel = new HomeViewModel()
            {
                Pies = pies.ToList(),
            Title = "Welcome to the Pie Pizzeria!"
        };
            return View(homeViewModel);
        }
    }
}