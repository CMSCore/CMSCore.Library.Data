namespace CMSCore.Library.Data.Configuration
{
    using Microsoft.Extensions.Configuration;

    public class DataConfiguration : IDataConfiguration
    {
        public DataConfiguration()
        {
            
        }
        public DataConfiguration(IConfiguration configuration)
        {
            configuration.GetSection("data").Bind(this);
        }

        public virtual string ConnectionString { get; set; }
    }
}