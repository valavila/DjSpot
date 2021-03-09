using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DjSpot.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using DjSpot.Data;

namespace DjSpot.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext DBcontext;

        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationUser> userManager, ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _logger = logger;
            DBcontext = context;
            webHostEnvironment = hostEnvironment;
        }
        public async Task<IActionResult> IndexAsync()
        {
            //Gets current user
            ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            
            if (currentUser != null) 
            {
                await SetAsDjOrCustomer(currentUser);
            }
            return View();
        }

        /// <summary>
        /// Sets up current user field for isDj or isCustomer, depending on what option they chose when registering
        /// </summary>
        /// <param name="currentUser">Current logged in user</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SetAsDjOrCustomer(ApplicationUser currentUser)
        {
            //ApplicationUser currentUser = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                if (currentUser.UserType == userType.customer)
                {
                    currentUser.isCustomer = true;
                    currentUser.isDj = false;
                    await _userManager.AddToRoleAsync(currentUser, "Customer");

                }
                else if (currentUser.UserType == userType.dj)
                {
                    currentUser.isCustomer = false;
                    currentUser.isDj = true;
                    await _userManager.AddToRoleAsync(currentUser, "Dj");
                }
                
                

                DBcontext.Update(currentUser);
                await DBcontext.SaveChangesAsync();
            }
           
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Profile()
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
