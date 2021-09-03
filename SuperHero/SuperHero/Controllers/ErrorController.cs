using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        [HttpGet]
        public ViewResult Index(Int32? id)
        {
            var statusCode = id.HasValue ? id.Value : 500;
            var error = new HandleErrorInfo(new Exception("An exception with error " + statusCode + " occurred!"), "Error", "Index");
            return View("Error", error);
        }
    }
}