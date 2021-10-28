using LanguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ViewResult> Index()
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

            IProductSelection cart = new ShoppingCart(
                new Product { Name = "Kayak", Price = 275M },
                new Product { Name = "Lifejacket", Price = 48.95M },
                new Product { Name = "Soccer ball", Price = 19M },
                new Product { Name = "Corner flag", Price = 34M }
                );

            long? length = await MyAsyncMethods.GetPageLength();

            /*
            var output = new List<string>();
            await foreach (var len in MyAsyncMethods.GetPageLengths(output, "apress.com", "microsoft.com", "amazon.com"))
            {
                output.Add($"Page length: {len}");
            }
            */

            return View(new[] { $"{nameof(length)}: {length}"});
        }
    }
}
