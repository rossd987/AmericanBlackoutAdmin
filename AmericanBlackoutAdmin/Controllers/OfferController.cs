using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain.SchemaOrg;
using AmericanBlackout.Domain.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class OfferController : RedisCRUDController<Offer>
    {
        public OfferController(IABRedisClient client)
            : base(client)
        {
        }
    }
}