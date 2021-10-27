﻿using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var results = new List<string>();

            foreach (var p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";

                results.Add(string.Format($"Name: {name}, Price: {price}, Related: {relatedName}"));
            }

            var products = new Dictionary<string, Product>
            {
                ["Kayak"] = new Product { Name = "Kayak" },
                ["Lifejacket"] = new Product { Name = "Lifejacket" }
            };

            return View(products.Keys);
        }
    }
}