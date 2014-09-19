using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain;
using AmericanBlackout.Domain.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class DonationCampaignController : RedisCRUDController<DonationCampaign>
    {
        public DonationCampaignController(IABRedisClient client)
            : base(client)
        {
        }
    }
}
