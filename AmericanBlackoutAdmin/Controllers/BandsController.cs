using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ServiceStack.Redis;
using AmericanBlackout.Domain;
using AmericanBlackout.Domain.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class BandsController : RedisCRUDController<Band>
    {
        public BandsController(IABRedisClient client)
            : base(client)
        {
        }

        public ActionResult SearchBands(string q)
        {
            try
            {
                using (var redis = new RedisClient("nyu"))
                {
                    var bandsclient = redis.As<Band>();
                    var v = bandsclient.GetAll();
                    var vs = v
                            .Where(x => x.Name.IndexOf(q, StringComparison.CurrentCultureIgnoreCase) > -1)
                            .Select(x => new { id = x.Id, name = x.Name });
                    return Json(vs, JsonRequestBehavior.AllowGet);
                }
            }
            catch
            {
                return Json(new { }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
