﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class GerenteController : Controller
    {
        private readonly ILogger<GerenteController> _logger;

        public GerenteController(ILogger<GerenteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
