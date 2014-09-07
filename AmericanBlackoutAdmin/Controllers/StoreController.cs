using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain;
using AmericanBlackout.Domain.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class StoreController : RedisCRUDController<StoreItem>
    {
        public StoreController(IABRedisClient client) : base(client) { }
    }
}
