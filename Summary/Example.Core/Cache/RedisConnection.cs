using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Core
{
    public static class RedisConnection
    {
        private static readonly string ConnectionString = ConfigurationManager.AppSettings["Redis_ConfigString"];
        private static readonly Lazy<ConnectionMultiplexer> Conn = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(ConnectionString));
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return Conn.Value;
            }
        }
    }
}
