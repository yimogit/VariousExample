using Example.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Example.Core;

namespace WebApiDemo.Controllers
{
    public class CacheController : ApiController
    {
        private readonly ICacheManager _cacheManager;
        public CacheController(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public string Get(string id)
        {
            Random random = new Random();
            return _cacheManager.Get(id, () =>
            {
                return "redis字符串:" + random.Next(0, 1000);
            });
        }
    }
}
