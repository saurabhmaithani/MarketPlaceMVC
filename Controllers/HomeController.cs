using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data;
using System.Data.Entity;

using System.Net;

using MarketPlaceMVC.Models;

namespace MarketPlaceMVC.Controllers
{
    public class HomeController : Controller
    {
        



     
        public ActionResult Index()
        {
            return View();
        }
        
        

        public ActionResult Verify(tblUser tbl)
        {
            if (ModelState.IsValid)
            {
                MarketPlaceDatabaseEntities1 db = new MarketPlaceDatabaseEntities1();
                var query = (from p in db.tblUsers
                             where p.username == tbl.username && p.Password == tbl.Password
                             select p).ToList();



                if (query.Count() > 0)
                {
                    return View("SearchPage");
                }
                else
                {
                    ViewBag.Message = "Incorrect username or password!";
                    return View("Index");

                }
            }
            else
            {
                return View("Index");
            }


        }


     
        public ActionResult CreateModal()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                MarketPlaceDatabaseEntities1 db = new MarketPlaceDatabaseEntities1();
         
               
                db.tblUsers.Add(tblUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }




        /*

        [HttpPost]
        public ActionResult Create([Bind(Include = "userID,username,firstname,lastname,email,Password,credential_ID")] tblUser tblUser)
        {
            if (ModelState.IsValid)
            {
                db.tblUsers.Add(tblUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }*/
    }
}