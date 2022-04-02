using AutoMapper;
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
        private readonly IMapper _mapper;
        private IDownload _download;

        public UsersController(IUserDetails userDetails, IMapper mapper,IDownload download)
        {
            _userDetails = userDetails;
            _mapper = mapper;
            _download = download;
        }
        // GET: UserController
        public IActionResult Details()
        {
            //var users = _userDetails.GetUsers();
            //UserViewModel userViewModel = _mapper.Map<UserViewModel>(users);
            return View();
        }

        // GET: UserController/Create
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel newuser)
        {
            if(ModelState.IsValid)
            {
                Users user = new Users
                {
                    FirstName = newuser.FirstName,
                    LastName = newuser.LastName
                };
                _userDetails.SaveUser(user);
                ViewData["Message"] = "Success";
            }
            return RedirectToAction("Details");
        }

        public ActionResult Download()
        {
             return Content(_download.Get());
        }


    }
}
