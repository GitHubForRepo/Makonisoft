using FeatureObject;
using MakoniSoft.DataStore.Models;
using MakoniSoft.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MakoniSoft.Controllers
{
    public class UsersController : Controller
    {
        private IUserDetails _userDetails;
        public UsersController(IUserDetails userDetails)
        {
            _userDetails = userDetails;
        }
        // GET: UserController
        public IActionResult Details()
        {
            //var users = _userDetails.GetUsers();
            return View();
        }

        // GET: UserController/Create
        public IActionResult Create(UserViewModel newuser)
        {
            Users user = new Users
            {
                FirstName = newuser.FirstName,
                LastName = newuser.LastName
            };
            _userDetails.SaveUser(user);
            ViewData["message"] = true;
            return RedirectToAction("Details");
        }

       
    }
}
