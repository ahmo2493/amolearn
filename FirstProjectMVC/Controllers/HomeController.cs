using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstProjectMVC.Models;
using FirstProjectMVC.SQLinfo;

namespace FirstProjectMVC.Controllers
{
    public class HomeController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Javascript(string searchBar, string id = "Basics")
        {
            ViewData["Js"] = id;

            using (var db = new BasicJSDBContext())
            {

                if (!String.IsNullOrEmpty(searchBar))
                {
                    var stringInfo = db.BasicJs.Where(x => x.Category.Contains(searchBar)).ToList();


                    if (stringInfo.Count != 0)
                    {
                        ViewData["Js"] = stringInfo[0].Category;
                    }
                    else
                    {
                        ViewData["Js"] = "Not found";
                    }
                }

                return View();
            }

        }

        public IActionResult CSharp(string searchBar, string id = "Terminology")
        {
            ViewData["Id"] = id;

            using (var db = new BasicJSDBContext())
            {

                var thePage = db.BasicCSharp.Where(x => x.PartialName == ViewData["Id"].ToString());
                foreach (var item in thePage)
                {
                    ViewData["Id"] = item.PartialPage;
                }

                if (!String.IsNullOrEmpty(searchBar))
                {
                    var stringInfo = db.BasicCSharp.Where(x => x.PartialInfo.Contains(searchBar)).ToList();

                    if (stringInfo.Count != 0)
                    {
                        ViewData["Id"] = stringInfo[0].PartialName;
                        foreach (var item in stringInfo)
                        {
                            ViewData["Id"] = item.PartialPage;
                        }
                    }
                    else
                    {
                        ViewData["Id"] = "_PageNotFoundPartial.cshtml";
                    }
                }
                return View();
            }


        }

        public IActionResult MVC(string searchBar, string id = "Routing")
        {
            ViewData["Id"] = id;
            using (var db = new BasicJSDBContext())
            {
                if (!String.IsNullOrEmpty(searchBar))
                {
                    var stringInfo = db.BasicMVC.Where(x => x.Category.Contains(searchBar)).ToList();

                    if (stringInfo.Count != 0)
                    {
                        ViewData["Id"] = stringInfo[0].Category;
                    }
                    else
                    {
                        ViewData["Id"] = "Not Found";
                    }
                }

            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
