using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core
{
    public class RedisManager : ICacheManager
    {
        public T Get<T>(string key)
        {
            if (!IsSet(key))
                return default(T);
            var db = RedisConnection.Connection.GetDatabase();
            var json = db.StringGet(key);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Set(string key, object data, int cacheTime)
        {
            var json = JsonConvert.SerializeObject(data);
            var db = RedisConnection.Connection.GetDatabase();
            db.StringSet(key, json, TimeSpan.FromMinutes(cacheTime));
        }

        public bool IsSet(string key)
        {
            var db = RedisConnection.Connection.GetDatabase();
            return db.KeyExists(key);
        }

        public void Remove(string key)
        {
            var db = RedisConnection.Connection.GetDatabase();
            db.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var keys = SearchKeys(pattern + "*");

            var db = RedisConnection.Connection.GetDatabase();
            foreach (var s in keys)
            {
                db.KeyDelete(s);
            }
        }

        public void Clear()
        {
        }

        private IEnumerable<string> SearchKeys(string pattern)
        {
            var db = RedisConnection.Connection.GetDatabase();
            var keys = new HashSet<RedisKey>();

            var endPoints = db.Multiplexer.GetEndPoints();

            foreach (var endpoint in endPoints)
            {
                var dbKeys = db.Multiplexer.GetServer(endpoint).Keys(db.Database, pattern);

                foreach (var dbKey in dbKeys)
                {
                    if (!keys.Contains(dbKey))
                    {
                        keys.Add(dbKey);
                    }
                }
            }

            return keys.Select(x => (string)x);
        }
    }
}
