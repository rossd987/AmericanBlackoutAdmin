using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ServiceStack.Redis;
using AmericanBlackout.Domain;

namespace AmericanBlackoutAdmin.Controllers
{
    public class BandsController : Controller
    {
        //
        // GET: /Bands/
        public ActionResult Index()
        {
            using (var redis = new RedisClient("nyu"))
            {

                var bandclient = redis.As<Band>();

                //var band = new Band
                //{
                //    Id = bandclient.GetNextSequence(),
                //    Name = "American Blackout",
                //    Facebook = "AmericanBlackoutBand",
                //    Website = "http://www.americanblackoutband.com"
                //};

                var bands = bandclient.Lists["bands"];
                return View(bands.ToList());
            }
        }

        //
        // GET: /Bands/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Bands/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Bands/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Bands/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Bands/Edit/5
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
        // GET: /Bands/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Bands/Delete/5
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
