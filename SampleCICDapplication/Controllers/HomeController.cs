using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleCICDapplication.IRepository;
using SampleCICDapplication.Models;
using SampleCICDapplication.Repository;
using System.Collections.Generic;

namespace SampleCICDApplication.Controllers
{
    public class HomeController : Controller
    {
        public readonly IUserRepository _userServices;

        public HomeController(IUserRepository userServices)
        {
            _userServices = userServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult UserList()
        {
            var resilt  = _userServices.GetUserList();
            return Ok(resilt);
        }
    }
}
