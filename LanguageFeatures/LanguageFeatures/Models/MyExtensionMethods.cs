using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (var prod in products)
            {
                total += prod?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> FiterByPrice(this IEnumerable<Product> productEnum, decimal minPrice)
        {
            foreach (var prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minPrice)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Fiter(this IEnumerable<Product> productEnum, Func<Product, bool> selector)
        {
            foreach (var prod in productEnum)
            {
                if (selector(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}
