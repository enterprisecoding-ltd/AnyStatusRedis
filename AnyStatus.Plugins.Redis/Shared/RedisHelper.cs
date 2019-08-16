/*
Anystatus Redis plugin
Copyright (C) 2019  Enterprisecoding (Fatih Boy)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License for more details.

You should have received a copy of the GNU Affero General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
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
