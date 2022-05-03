using E_Cart.Models;
using E_Cart.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Cart.Controllers
{
    /// <summary>
    /// This class is a controller and its default controller, contains all methos related to default app page
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;
        private readonly String connectionString;
        public HomeController(ILogger<HomeController> logger, IConfiguration iConfig)
        {
            _logger = logger;
            configuration = iConfig;
            this.connectionString = configuration.GetSection("ConnectionStrings").GetSection("MyConn").Value;
        }


        /// <summary>
        /// This is default action method which returns the default index view with products data and menu data
        /// </summary>
        /// <param name="sortId">Sort id to sort the products data</param>
        /// <returns>Actionresult</returns>
        public IActionResult Index(int sortId)
        {
            
            DBLayer.MenuDB dblayer = new DBLayer.MenuDB(this.connectionString);
            List<MenuModel> menuModels = dblayer.getMenu();
            //Session.category = menuModels;
            HttpContext.Session.SetObjectAsJson("Category", menuModels);
            DBLayer.ProductDB productDB = new DBLayer.ProductDB(connectionString);
            List<ProductModel> products = productDB.getProducts();
            if (sortId == 1 || sortId == 0)
            {
                products = products.OrderBy(x => x.Popularity).ToList();
            }
            else if (sortId == 2)
            {
                products = products.OrderBy(x => x.Price).ToList();
            }
            else if (sortId == 3)
            {
                products = products.OrderByDescending(x => x.Price).ToList();
            }
            else if (sortId == 4)
            {
                products = products.OrderBy(x => x.CompanyName).ToList();
            }

            return View(products);
        }



      /// <summary>
      /// This method returns the product details view and changes the iamge based on color selected.
      /// </summary>
      /// <param name="productId">Product Id</param>
      /// <param name="color">Color</param>
      /// <returns>ActionResult</returns>
        public IActionResult ProductDetail(int  productId, string color)
        {
            String connectionString = configuration.GetSection("ConnectionStrings").GetSection("MyConn").Value; ;
            DBLayer.ProductDB productDB = new DBLayer.ProductDB(connectionString);
            List<ProductModel> products = productDB.getProducts();
            ProductModel product = products.First(x => x.ProductId == productId);
            if( !String.IsNullOrEmpty(color))
                product.Url = Path.GetFileNameWithoutExtension(product.Url) + "-" + color + Path.GetExtension(product.Url);
            return View(product);
        }



        /// <summary>
        /// This method returns the privacy view
        /// </summary>
        /// <returns>Actionresult</returns>
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
