﻿using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}