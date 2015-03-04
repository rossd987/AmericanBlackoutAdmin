using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class MusicGroupController : Controller
    {
        public MusicGroupController(IABRedisClient client)
        {
            this.client = client;
        }
        readonly IABRedisClient client;
        //
        // GET: /MusicGroup/
        public ActionResult Index()
        {

            return View();
        }

        //
        // GET: /MusicGroup/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /MusicGroup/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /MusicGroup/Create
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
        // GET: /MusicGroup/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /MusicGroup/Edit/5
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
        // GET: /MusicGroup/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /MusicGroup/Delete/5
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
