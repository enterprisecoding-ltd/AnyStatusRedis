﻿using AnyStatus.API;
using AnyStatus.Plugins.Redis.Shared;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnyStatus.Plugins.Redis.BlockedClients
{
    [DisplayName("Blocked Clients")]
    [DisplayColumn("Redis")]
    [Description("Shows the connected client list for Redis")]
    public class BlockedClientsWidget : Sparkline, IRedisConnection, ISchedulable
    {
        [Required]
        [Category("Blocked Clients")]
        [Description("Redis endpoint in host:port format")]
        public string EndPoint { get; set; }

        [Category("Blocked Clients")]
        [Description("Redis password")]
        public string Password { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("connection timeout")]
        public int ConnectionTimeout { get; set; }

        [Required]
        [Category("Blocked Clients")]
        [Description("Enable ssl connection")]
        public bool EnableSSL { get; set; }

        public BlockedClientsWidget() {
            Name = "Blocked Clients";
            ConnectionTimeout = 60 * 1000;
            EnableSSL = false;
        }
    }
}