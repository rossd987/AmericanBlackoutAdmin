using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain;
using AmericanBlackout.Domain.Redis;
using ServiceStack.Redis;
using AmericanBlackoutAdmin.Models;

namespace AmericanBlackoutAdmin.Controllers
{
    public class ShowsController : RedisCRUDController<Show>
    {
        public ShowsController(IABRedisClient client)
            : base(client)
        {
        }

        public override ActionResult Index()
        {
            IList<Show> shows;
            IList<ShowModel> model = new List<ShowModel>();
            using (var redis = _client.Create())
            {
                shows = redis.As<Show>().GetAll();

                foreach (var s in shows)
                {
                    var m = new ShowModel();
                    m.Show = s;
                    m.Venue = redis.As<Venue>().GetById(s.VenueId);
                    m.Bands = new List<Band>();
                    foreach (var b in s.BandIds)
                    {
                        m.Bands.Add(redis.As<Band>().GetById(b));
                    }
                    model.Add(m);
                }
            }

            return View(model);
        }

        public override ActionResult Edit(int id)
        {
            var showmodel = new ShowModel();
            showmodel.Show = _client.Get<Show>(id);
            showmodel.Venue = _client.Get<Venue>(showmodel.Show.VenueId);
            showmodel.Bands = new List<Band>();
            foreach (var b in showmodel.Show.BandIds)
            {
                showmodel.Bands.Add(_client.Get<Band>(b));
            }

            return View(showmodel);
        }

        [HttpPost]
        public override ActionResult Edit(int id, Show show)
        {
            try
            {
                _client.Store(show);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
