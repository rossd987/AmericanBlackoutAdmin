using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using AmericanBlackout.Domain;

namespace AmericanBlackoutAdmin.Models
{
    public class ShowBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var show = base.BindModel(controllerContext, bindingContext) as Show;

            string bandids = "";
            try
            {
                bandids = bindingContext.ValueProvider
                                    .GetValue("Show.BandIds").AttemptedValue
                                    .ToString();
            }
            catch (Exception ex)
            {

            }

            if (!string.IsNullOrEmpty(bandids))
            {
                show.BandIds = bandids.Split(',').Select(x => long.Parse(x)).ToList();
            }

            return show;
        }
    }
}