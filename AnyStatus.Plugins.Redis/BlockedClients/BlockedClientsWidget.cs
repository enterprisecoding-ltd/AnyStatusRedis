﻿/*
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
using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus.Plugins.Redis.BlockedClients
{
    [DisplayName("Blocked Clients")]
    [DisplayColumn("Redis")]
    [Description("Clients blocked while waiting on BLPOP, BRPOP, or BRPOPLPUSH")]
    public class BlockedClientsWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [PropertyOrder(10)]
        [Category("Blocked Clients")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [PropertyOrder(20)]
        [Category("Blocked Clients")]
        [Description("Password for the redis server")]
        public string Password { get; set; }

        [Required]
        [PropertyOrder(30)]
        [Category("Blocked Clients")]
        [DisplayName("Connection Timeout")]
        [Description("Timeout (ms) for connect operations")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [PropertyOrder(40)]
        [Category("Blocked Clients")]
        [DisplayName("Connect Retry")]
        [Description("The number of times to repeat connect attempts during initial Connect")]
        public int ConnectRetry { get; set; }

        [Required]
        [PropertyOrder(50)]
        [Category("Blocked Clients")]
        [DisplayName("Enable SSL")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public BlockedClientsWidget() {
            Name = "Blocked Clients";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
            ConnectRetry = 3;
        }
    }
}
