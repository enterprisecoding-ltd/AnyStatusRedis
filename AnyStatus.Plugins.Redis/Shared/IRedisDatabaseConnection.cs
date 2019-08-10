namespace AnyStatus.Plugins.Redis.Shared
{
    internal interface IRedisDatabaseConnection: IRedisConnection
    {
        int Database { get; set; }
    }
}
