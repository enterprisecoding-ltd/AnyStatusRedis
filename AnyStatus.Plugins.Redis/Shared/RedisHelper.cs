/*
Anystatus Redis plugin
Copyright 2019 Fatih Boy

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
 */
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
