namespace AnyStatus.Plugins.Redis.Shared
{
    internal interface IRedisConnection
    {
        string EndPoint { get; set; }
        string Password { get; set; }
        int ConnectionTimeout { get; set; }
        bool EnableSSL { get; set; }
    }
}
