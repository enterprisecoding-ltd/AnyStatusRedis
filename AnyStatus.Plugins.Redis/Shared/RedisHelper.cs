using StackExchange.Redis;

namespace AnyStatus.Plugins.Redis.Shared
{
    internal static class RedisHelper
    {
        internal static ConnectionMultiplexer GetConnectionMultiplexer(IRedisConnection redisConnection) {
            var options = new ConfigurationOptions()
            {
                ConnectTimeout = redisConnection.ConnectionTimeout,
                Ssl = redisConnection.EnableSSL,
                AllowAdmin = true,
                AbortOnConnectFail = false,
                ConnectRetry = redisConnection.ConnectRetry
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
