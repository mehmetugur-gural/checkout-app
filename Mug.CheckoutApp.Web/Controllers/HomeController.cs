using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mug.CheckoutApp.Data;
using Mug.CheckoutApp.Service;
using Mug.CheckoutApp.Web.Models;

namespace Mug.CheckoutApp.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ProductService product = new ProductService();
            return View(product.PopulateProductCartItems());
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [HttpPost]
        public IActionResult CalculateCart()
        {
            Dictionary<string, string> cartList = new Dictionary<string, string>();
            DiscountCalculationService calculationService = new DiscountCalculationService();
            ProductService product = new ProductService();
            var productList = product.PopulateProductCartItems();

            //TODO : Lame implementation, product cart discount calculation must be real-time when cart item changes.
            for (int i = 0; i < 3; i++)
            {
                cartList.Add(Request.Form["ProductId"].ToString().Split(',')[i], Request.Form["CartCount"].ToString().Split(',')[i]);
            }

            foreach (var productItem in productList)
            {
                productItem.CartCount = int.Parse(cartList.FirstOrDefault(x => x.Key == productItem.Id.ToString()).Value);
                
            }

            var calculatedCartItems = calculationService.CalculateDiscountsForProducts(productList);
            
            return View("Index", calculatedCartItems);
        }
    }
}