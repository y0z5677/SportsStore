﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStoreApp.Models;
using SportsStoreApp.Models.Pages;

namespace SportsStoreApp.Controllers
{
    public class StoreController : Controller
    {
        private IRepository productRepository;
        private ICategoryRepository categoryRepository;

        public StoreController(IRepository prepo, ICategoryRepository catRepo)
        {
            productRepository = prepo;
            categoryRepository = catRepo;
        }
        public IActionResult Index([FromQuery(Name = "options")]
                        QueryOptions productOptions,
                        QueryOptions catOptions,
                        long category)
        {
            ViewBag.Categories = categoryRepository.GetCategories(catOptions);
            ViewBag.SelectedCategory = category;
            return View(productRepository.GetProducts(productOptions, category));
        }
    }
}
