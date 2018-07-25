using System;
using System.Collections.Generic;
using System.Text;

namespace CMSCore.Library.Data.Factories
{
    using Configuration;
    using Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class ContentDbContextFactory : IDesignTimeDbContextFactory<ContentDbContext>
    {
        public ContentDbContext CreateDbContext(string [ ] args)
        {
            //return new ContentDbContext(new DataConfiguration());
            return new ContentDbContext(new MigrationDataConfiguration());
        }

        public IDataConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder();
            //builder.AddJsonFile("appsettings.json", optional: false);

            var configuration = builder.Build();

            return new DataConfiguration(configuration);
        }
    }

    internal class MigrationDataConfiguration : DataConfiguration
    {
        public override string ConnectionString { get; set; } = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CMSCoreDbContextv2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}


//var b = new DbContextOptionsBuilder().UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CMSCoreDbContextv2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");