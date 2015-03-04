using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain.SchemaOrg;
using AmericanBlackout.Domain.Redis;
using AmericanBlackoutAdmin.Models;
using AmericanBlackoutAdmin.Tools;

namespace AmericanBlackoutAdmin.Controllers
{
    public class MusicEventController //: RedisCRUDController<MusicEvent>
        : Controller
    {
        public MusicEventController(IABRedisClient client)
        //: base(client)
        {
            this.client = client;
        }

        readonly IABRedisClient client;

        public ActionResult Index()
        {
            IList<MusicEvent> l;
            List<MusicEventModel> m = new List<MusicEventModel>();
            using (var redis = client.Create())
            {
                l = redis.As<MusicEvent>().GetAll();
            }

            foreach (var i in l)
            {
                var d = new MusicEventModel() { MusicEvent = i };

                if (i.OfferIds != null)
                {
                    d.Offers = string.Join(",", i.OfferIds);
                }

                if (i.PerformerIds != null)
                {
                    d.Performers = string.Join(",", i.PerformerIds);
                }

                m.Add(d);
            }

            return View(m);
        }

        ////
        //// GET: /MusicEvent/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(MusicEventModel item)
        {
            try
            {
                item.MusicEvent.OfferIds = Helpers.StringToList(item.Offers);
                item.MusicEvent.PerformerIds = Helpers.StringToList(item.Performers);

                client.Create(item.MusicEvent);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MusicEvent/Edit/5
        public ActionResult Edit(int id)
        {
            MusicEventModel m = new MusicEventModel();
            MusicEvent e;
            using (var redis = client.Create())
            {
                m.MusicEvent = redis.As<MusicEvent>().GetById(id);
            }

            if (m.MusicEvent.OfferIds != null)
            {
                m.Offers = string.Join(",", m.MusicEvent.OfferIds);
            }

            if (m.MusicEvent.PerformerIds != null)
            {
                m.Performers = string.Join(",", m.MusicEvent.PerformerIds);
            }

            return View(m);
        }

        [HttpPost]
        public ActionResult Edit(int id, MusicEventModel model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Offers))
                    model.MusicEvent.OfferIds = model.Offers.Split(',').Select(x => Convert.ToInt64(x.Trim())).ToList();

                if (!string.IsNullOrEmpty(model.Performers))
                    model.MusicEvent.PerformerIds = model.Performers.Split(',').Select(x => Convert.ToInt64(x.Trim())).ToList();

                model.MusicEvent.Id = id;

                //base.Edit(id, model.MusicEvent);
                client.Store(model.MusicEvent);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /MusicEvent/Delete/5
        public ActionResult Delete(int id)
        {
            MusicEvent e;
            using (var redis = client.Create())
            {
                e = redis.As<MusicEvent>().GetById(id);
            }
            return View(e);
        }

        [HttpPost]
        public ActionResult Delete(int id, MusicEvent model)
        {
            try
            {
                client.Delete(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
