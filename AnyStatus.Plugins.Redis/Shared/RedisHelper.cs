using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyStatus.Plugins.Redis.Shared
{
    internal static class RedisHelper
    {
        internal static ConnectionMultiplexer GetConnectionMultiplexer(IRedisConnection redisConnection) {
            var options = new ConfigurationOptions()
            {
                ConnectTimeout = redisConnection.ConnectionTimeout,
                Ssl = redisConnection.EnableSSL,
                AllowAdmin = true
            };


            options.EndPoints.Add(redisConnection.EndPoint);


            if (!string.IsNullOrWhiteSpace(redisConnection.Password))
            {
                options.Password = redisConnection.Password;
            }

            return ConnectionMultiplexer.Connect(options);
        }
    }
}
