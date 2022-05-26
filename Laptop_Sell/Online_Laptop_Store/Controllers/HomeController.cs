using DataAccessLayer_DAL.Models;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Online_Laptop_Store.Models;

using Online_Laptop_Store.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Laptop_Store.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Laptop> _laptopRepo;
        IRepository<Customer> _customerRepo;
        IRepository<Orders> _orderRepo;
        UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IRepository<Laptop> laptop,IRepository<Customer> customer,IRepository<Orders> order, UserManager<ApplicationUser> UserManager)
        {
            _logger = logger;
            _laptopRepo = laptop;
            _customerRepo = customer;
            _orderRepo = order;
            _userManager = UserManager;

        }

        public IActionResult Index()
        {
            return View(_laptopRepo.GetAll());
           
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            Laptop laptop = _laptopRepo.Get(id);
            return View(laptop);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Order(int? id)
        {
            if (id != null && id >= 0)
            {
                OrderViewModel model = new OrderViewModel()
                {
                    LaptopToOrder = _laptopRepo.Get((int)id),
                    CustomerDetails = new Customer()
                    {
                        CustId = _userManager.GetUserId(User)
                    }
                };
                return View(model);
            }

            return View();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Order(int id, Customer customerDetails)
        {
            if (ModelState.IsValid)
            {
                if (_laptopRepo.GetAll().Count(x => x.Id == id) >= 1)
                {
                    customerDetails.CustId = _userManager.GetUserId(User);
                    _customerRepo.Add(customerDetails);
                    Orders newOrder = new Orders
                    {
                        CustomerId = _userManager.GetUserId(User),
                        LaptopId = id,
                        OrderDate = DateTime.Now
                    };
                    _orderRepo.Add(newOrder);
                    return RedirectToAction("ThankYou");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View(new OrderViewModel()
                {
                    CustomerDetails = customerDetails,
                    LaptopToOrder = _laptopRepo.Get((int)id)
                }
                   );
            }
        }
        [Authorize]
        public IActionResult ThankYou()
        {
            return View();
        }
        [Authorize]
        public IActionResult MyOrdersList()
        {
            /*if (_orderRepo.GetByCustId(_userManager.GetUserId(User)) == null)
            {
                ViewBag.cnt = 0;
            }
            else
            {
                ViewBag.cnt = 1;
            }
            return View(_orderRepo.GetByCustId(_userManager.GetUserId(User)));*/
           

            
            List<Orders> orders = _orderRepo.GetByCustId(_userManager.GetUserId(User));
            if (orders == null)
            {
                ViewBag.cnt = 0;
            }
            else
            {
                ViewBag.cnt = orders.Count;
            }

            List<Laptop> laptops = new List<Laptop>();
            if (orders == null)
            {
                return View(laptops);
            }
            foreach (var item in orders)
            {
                int lid = item.LaptopId;
                Laptop lap = _laptopRepo.Get(lid);
                laptops.Add(lap);
            }


            return View(laptops);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
