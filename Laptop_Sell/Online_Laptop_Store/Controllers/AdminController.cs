using DataAccessLayer_DAL.Models;
using Business_Logic_Layer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Online_Laptop_Store.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Laptop_Store.Controllers
{
    public class AdminController : Controller
    {
        private IRepository<Laptop> _laptopRepo;
        private readonly ILogger<AdminController> _logger;
        UserManager<ApplicationUser> _userManager;


        public AdminController(ILogger<AdminController> logger, IRepository<Laptop> laptop, UserManager<ApplicationUser> UserManager)
        {
            _logger = logger;
            _laptopRepo = laptop;
            _userManager = UserManager;
        }
        [Authorize]
        
        public IActionResult ManageProducts()
        {
            //password:Admin!2345
            if(_userManager.GetUserName(User) == "admin@gmail.com")
            {
                return View(_laptopRepo.GetAll());
            }
            else
            {
               return RedirectToAction("Error");
            }
            
            
        }
        [Authorize]
        public IActionResult DeleteProduct(int id)
        {
            if (_userManager.GetUserName(User) == "admin@gmail.com")
            {
                Laptop lap = _laptopRepo.Get(id);
                if (lap == null)
                {
                    return RedirectToAction("Error");
                }
                _laptopRepo.Delete(lap);
                return RedirectToAction("ManageProducts");
            }
            else
            {
                return RedirectToAction("Error");
            }
            
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddProduct()
        {
            if (_userManager.GetUserName(User) == "admin@gmail.com")
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
                
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                Laptop item = new Laptop()
                {
                    // Id = _bookRepo.GetAll().Max(m => m.Id) + 1,
                    ItemTitle = laptop.ItemTitle,
                    Price=laptop.Price,
                    Image=laptop.Image,
                    Brand=laptop.Brand,
                    Series=laptop.Series,
                    ScreenSize=laptop.ScreenSize,
                    Color=laptop.Color,
                    Ram=laptop.Ram,
                    CPUSpeed=laptop.CPUSpeed,
                    HardDisk=laptop.HardDisk
                    
                };
                

                _laptopRepo.Add(item);
                return RedirectToAction("ManageProducts");
            }
            else
            {

                return View();
            }


        }
        [Authorize]
        [HttpGet]
        public IActionResult EditProduct(int id)
        {
            if (_userManager.GetUserName(User) == "admin@gmail.com")
            {
                if (_laptopRepo.Get(id) == null)
                {
                    return RedirectToAction("Error");
                }
                return View(_laptopRepo.Get(id));
            }
            return RedirectToAction("Error");
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditProduct(int id,Laptop laptop)
        {
            if (ModelState.IsValid)
            {
                Laptop item = new Laptop()
                {
                     Id = id,
                    ItemTitle = laptop.ItemTitle,
                    Price = laptop.Price,
                    Image = laptop.Image,
                    Brand = laptop.Brand,
                    Series = laptop.Series,
                    ScreenSize = laptop.ScreenSize,
                    Color = laptop.Color,
                    Ram = laptop.Ram,
                    CPUSpeed = laptop.CPUSpeed,
                    HardDisk = laptop.HardDisk

                };


                _laptopRepo.Edit(item);
                return RedirectToAction("ManageProducts");
            }
            else
            {

                return View();
            }


        }
    }
}
