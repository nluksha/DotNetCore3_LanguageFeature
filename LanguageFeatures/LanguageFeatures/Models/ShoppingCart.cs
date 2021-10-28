using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class ShoppingCart: IProductSelection
    {
        private List<Product> products = new List<Product>();

        public IEnumerable<Product> Products { get => products; }

        public ShoppingCart(params Product[] prods)
        {
            products.AddRange(prods);
        }
    }
}
