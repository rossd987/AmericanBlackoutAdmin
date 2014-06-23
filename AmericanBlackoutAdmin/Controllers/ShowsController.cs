using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain;
using ServiceStack.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class ShowsController : Controller
    {
        //
        // GET: /Shows/
        public ActionResult Index()
        {
            using (var redis = new RedisClient("nyu"))
            {

                var showsclient = redis.As<Show>();

                //var band = new Band
                //{
                //    Id = bandclient.GetNextSequence(),
                //    Name = "American Blackout",
                //    Facebook = "AmericanBlackoutBand",
                //    Website = "http://www.americanblackoutband.com"
                //};

                var shows = showsclient.GetAll();// .Lists["bands"];
                return View(shows);
            }
        }

        //
        // GET: /Shows/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Shows/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Shows/Create
        [HttpPost]
        public ActionResult Create(Show show)
        {
            try
            {
                // TODO: Add insert logic here

                //return RedirectToAction("Index");

                using (var redis = new RedisClient("nyu"))
                {

                    var showsclient = redis.As<Show>();

                    showsclient.Store(show);
                }

                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Shows/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Shows/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Shows/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Shows/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
