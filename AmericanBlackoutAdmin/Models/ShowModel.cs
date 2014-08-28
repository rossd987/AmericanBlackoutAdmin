using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AmericanBlackout.Domain;

namespace AmericanBlackoutAdmin.Models
{
    public class ShowModel
    {
        public Show Show { get; set; }
        public Venue Venue { get; set; }
        public List<Band> Bands { get; set; }
    }
}