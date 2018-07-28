namespace CMSCore.Library.Data.Context
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Configuration;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ContentDbContext : DbContext, IContentDbContext
    {
        private readonly IDataConfiguration _dataConfiguration;

        public DbSet<Comment> Comments { get; set; }
        public DbSet<FeedItem> FeedItems { get; set; }

        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Content> Content { get; set; }
        public DbSet<ContentVersion> ContentVersions { get; set; }
        public ContentDbContext(IDataConfiguration dataConfiguration)
        {
            _dataConfiguration = dataConfiguration;
            if (dataConfiguration?.ConnectionString == null)
            {
                throw new Exception("appsettings.json must contain a 'data' section with a property 'ConnectionString'.");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dataConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.IdentityUserId)
                .IsUnique();


            modelBuilder.Entity<Page>().HasOne(x => x.Feed).WithOne(x => x.Page).HasForeignKey(typeof(Page), "FeedId");
            modelBuilder.Entity<Feed>().HasOne(x => x.Page).WithOne(x => x.Feed).HasForeignKey(typeof(Feed), "PageId");
        }


        DbSet<TEntity> IContentDbContext.Set<TEntity>()
        {
            return Set<TEntity>();
        }

        TEntity IContentDbContext.Add<TEntity>(TEntity entity)
        {
            return Add(entity)?.Entity;
        }

        TEntity IContentDbContext.Update<TEntity>(TEntity entity)
        {
            return Update(entity)?.Entity;
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            base.AddRange(entities);
        }

        public void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase
        {
            base.UpdateRange(entities);
        }

        void IContentDbContext.Remove<TEntity>(TEntity entity)
        {
            Remove(entity);
        }

        async Task<int> IContentDbContext.SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}