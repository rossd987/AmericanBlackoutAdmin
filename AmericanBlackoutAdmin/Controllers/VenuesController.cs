using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain;
using AmericanBlackout.Domain.Redis;
using ServiceStack.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class VenuesController : Controller
    {
        public VenuesController(IABRedisClient client)
        {
            _client = client;
        }
        readonly IABRedisClient _client;

        public ActionResult Index()
        {
            using (var redis = _client.Create())
            {
                return View(redis.As<Venue>().GetAll());
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Venue/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Venue/Create
        [HttpPost]
        public ActionResult Create(Venue collection)
        {
            try
            {
                using (var redis = new RedisClient("nyu"))
                {
                    var venueclient = redis.As<Venue>();

                    collection.Id = venueclient.GetNextSequence();

                    venueclient.Store(collection);

                    return RedirectToAction("Index");
                }

                
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Venue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Venue/Edit/5
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
        // GET: /Venue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Venue/Delete/5
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

        public ActionResult SearchVenues(string q)
        {
            try
            {
                using (var redis = new RedisClient("nyu"))
                {
                    var venueclient = redis.As<Venue>();

                    var v = venueclient.GetAll();

                    var vs = v
                            .Where(x => x.Name.IndexOf(q, StringComparison.CurrentCultureIgnoreCase) > -1)
                            .Select(x => new { id = x.Id, name = x.Name });
                    return Json(vs, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
