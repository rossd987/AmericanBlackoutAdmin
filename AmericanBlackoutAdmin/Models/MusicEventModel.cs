using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AmericanBlackout.Domain.SchemaOrg;

namespace AmericanBlackoutAdmin.Models
{
    public class MusicEventModel 
    {
        public MusicEvent MusicEvent { get; set; }
        public string Offers { get; set; }
        public string Performers { get; set; }

    }
}