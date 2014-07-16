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
    public class ShowsController : RedisCRUDController<Show>
    {
        public ShowsController(IABRedisClient client)
            : base(client)
        {
        }
    }
}
