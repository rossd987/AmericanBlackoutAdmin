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
    public class VenuesController : RedisCRUDController<Venue>
    {
        public VenuesController(IABRedisClient client)
            : base(client)
        {
        }

        public ActionResult SearchVenues(string q)
        {
            try
            {
                var vs = _client.GetAll<Venue>()
                            .Where(x => x.Name.IndexOf(q, StringComparison.CurrentCultureIgnoreCase) > -1)
                            .Select(x => new { id = x.Id, name = x.Name });

                return Json(vs, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
