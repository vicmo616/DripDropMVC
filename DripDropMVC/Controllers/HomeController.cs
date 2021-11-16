using DripDropMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DripDropMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DDPage()
        {
            DripDrop model = new();

            model.DripValue = 3;
            model.DropValue = 5;

            

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DDPage(DripDrop dripdrop)
        {
            List<string> ddItems = new();

            bool drip;
            bool drop;

            for(int i = 1; i <= 100; i++)
            {
                drip = (i % dripdrop.DripValue == 0);
                drop = (i % dripdrop.DropValue == 0);

                if(drip == true && drop == true)
                {
                    ddItems.Add("DRIPDROP");
                }
                else if(drip == true)
                {
                    ddItems.Add("DRIP");
                }
                else if(drop == true)
                {
                    ddItems.Add("DROP");
                }
                else
                {
                    ddItems.Add(i.ToString());
                }
            }

            dripdrop.Result = ddItems;

            return View(dripdrop);
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
