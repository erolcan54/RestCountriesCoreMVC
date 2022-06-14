using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using UICoreMVC.APIService.Abstract;
using UICoreMVC.Models;

namespace UICoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private IRootService _rootService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRootService rootService)
        {
            _logger = logger;
            _rootService = rootService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _rootService.Listele();
            ViewData["List"] = result;

            return View();
        }

        public async Task<IActionResult> CapitalSearch(string capital)
        {
            var result = await _rootService.Listele();
            //var resultisNull = result.Where(a =>!string.IsNullOrEmpty(a.capital)).ToList();
            //var filter = resultisNull.Where(a => a.capital.Contains(capital)).ToList();
            var filter = (from item in result.ToList()
                          where !string.IsNullOrEmpty(item.capital) && item.capital.Contains(capital)
                          select item).ToList();


            ViewData["List"] = filter;
            return View();
        }

        public async Task<IActionResult> GlobalSearch(string key)
        {
            var result = await _rootService.Listele();
            var filter = (from item in result.ToList()
                where (!string.IsNullOrEmpty(item.capital) && item.capital.Contains(key)) ||
                      (!string.IsNullOrEmpty(item.name) && item.name.Contains(key)) ||
                      (!string.IsNullOrEmpty(item.region) && item.region.Contains(key))
                select item).ToList();

            ViewData["List"] = filter;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
