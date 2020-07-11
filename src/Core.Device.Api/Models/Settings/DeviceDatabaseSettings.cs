namespace Core.Device.Api.Models.Settings
{
    public class DeviceDatabaseSettings
    {
        public string DeviceCollectionName { get; set; }
        public string TypeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}