using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core
{
    public static class CacheExtensions
    {
        private static readonly object SyncObject = new object();
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            lock (SyncObject)
            {
                if (cacheManager.IsSet(key))
                {
                    return cacheManager.Get<T>(key);
                }
                var result = acquire();
                if (cacheTime > 0)
                    cacheManager.Set(key, result, cacheTime);
                return result;
            }
        }

    }
}
