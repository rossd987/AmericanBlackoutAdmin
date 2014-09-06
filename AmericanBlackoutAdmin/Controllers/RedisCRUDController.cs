using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using AmericanBlackout.Domain.Redis;

namespace AmericanBlackoutAdmin.Controllers
{
    public class RedisCRUDController<T> : Controller where T:RedisItem
    {
        public RedisCRUDController(IABRedisClient client)
        {
            _client = client;
        }
        protected readonly IABRedisClient _client;

        public virtual ActionResult Index()
        {
            using (var redis = _client.Create())
            {
                return View(redis.As<T>().GetAll());
            }
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Create(T venue)
        {
            try
            {
                _client.Create(venue);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public virtual ActionResult Edit(int id)
        {
            return View(_client.Get<T>(id));
        }

        [HttpPost]
        public virtual ActionResult Edit(int id, T venue)
        {
            try
            {
                _client.Store(venue);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View(_client.Get<T>(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, T venue)
        {
            try
            {
                _client.Delete(venue);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



	}
}