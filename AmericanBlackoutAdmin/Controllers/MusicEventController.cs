using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain.SchemaOrg;
using AmericanBlackout.Domain.Redis;
using AmericanBlackoutAdmin.Models;


namespace AmericanBlackoutAdmin.Controllers
{
    public class MusicEventController : RedisCRUDController<MusicEvent>
    {
        public MusicEventController(IABRedisClient client)
            : base(client)
        {
            this.client = client;
        }

        readonly IABRedisClient client;

        public override ActionResult Index()
        {
            IList<MusicEvent> l;
            List<MusicEventModel> m = new List<MusicEventModel>();
            using (var redis = _client.Create())
            {
                l = redis.As<MusicEvent>().GetAll();
            }

            foreach (var i in l)
            {
                m.Add(new MusicEventModel() { MusicEvent = i });
            }
            return View(m);
        }

        ////
        //// GET: /MusicEvent/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        ////
        //// GET: /MusicEvent/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        ////
        //// POST: /MusicEvent/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /MusicEvent/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /MusicEvent/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        ////
        //// GET: /MusicEvent/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        ////
        //// POST: /MusicEvent/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
