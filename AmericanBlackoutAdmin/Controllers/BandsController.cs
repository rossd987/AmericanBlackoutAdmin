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

                var bands = bandclient.GetAll();// .Lists["bands"];
                return View(bands);
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
        public ActionResult Create(Band collection)
        {
            try
            {
                using (var redis = new RedisClient("nyu"))
                {
                    var bandclient = redis.As<Band>();

                    collection.Id = bandclient.GetNextSequence();

                    bandclient.Store(collection);// .Lists[""]..Store(band);


                    return RedirectToAction("Index");
                }
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
            using (var redis = new RedisClient("nyu"))
            {
                var bandclient = redis.As<Band>();


                var band = bandclient.GetById(id); //bandclient.Lists["bands"].FirstOrDefault(x => x.Id == id);
                return View(band);
            }
        }

        //
        // POST: /Bands/Edit/5
        [HttpPost]
        public ActionResult Edit(Band collection)
        {
            try
            {
                using (var redis = new RedisClient("nyu"))
                {
                    var bandclient = redis.As<Band>();
                    var band = bandclient.Lists["bands"].FirstOrDefault(x => x.Id == collection.Id);
                    band.Name = collection.Name;
                    band.Facebook = collection.Facebook;
                    band.Website = collection.Website;

                    bandclient.Store(band);// .Lists[""]..Store(band);
                }

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
            using (var redis = new RedisClient("nyu"))
            {
                var bandclient = redis.As<Band>();


                var band = bandclient.GetById(id); //bandclient.Lists["bands"].FirstOrDefault(x => x.Id == id);
                return View(band);
            }
        }

        //
        // POST: /Bands/Delete/5
        [HttpPost]
        public ActionResult Delete(Band collection)
        {
            try
            {
                using (var redis = new RedisClient("nyu"))
                {
                    var bandclient = redis.As<Band>();

                    bandclient.Delete(collection);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
