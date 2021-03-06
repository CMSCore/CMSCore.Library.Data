﻿// <auto-generated />
using System;
using CMSCore.Library.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CMSCore.Library.Data.Migrations
{
    [DbContext(typeof(ContentDbContext))]
    [Migration("20180726150136_content_version_added")]
    partial class content_version_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CMSCore.Library.Data.Models.Comment", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("FeedItemId");

                    b.Property<string>("FullName");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("FeedItemId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Content", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActiveContentVersionId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Content");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.ContentVersion", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("UserId");

                    b.Property<string>("Value");

                    b.Property<int>("VersionNumber");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("ContentVersions");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Feed", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("PageId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PageId")
                        .IsUnique()
                        .HasFilter("[PageId] IS NOT NULL");

                    b.ToTable("Feeds");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.FeedItem", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("CommentsEnabled");

                    b.Property<string>("ContentId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<string>("FeedId");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("NormalizedTitle");

                    b.Property<string>("Title");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("FeedId");

                    b.ToTable("FeedItems");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Page", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentId");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("FeedEnabled");

                    b.Property<string>("FeedId");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Tag", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("FeedItemId");

                    b.Property<bool>("Hidden");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FeedItemId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContentId");

                    b.Property<string>("ContentId1");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<bool>("Hidden");

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("LastName");

                    b.Property<bool>("MarkedToDelete");

                    b.Property<DateTime>("Modified");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ContentId1");

                    b.HasIndex("IdentityUserId")
                        .IsUnique()
                        .HasFilter("[IdentityUserId] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Comment", b =>
                {
                    b.HasOne("CMSCore.Library.Data.Models.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("CMSCore.Library.Data.Models.FeedItem", "FeedItem")
                        .WithMany("Comments")
                        .HasForeignKey("FeedItemId");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.ContentVersion", b =>
                {
                    b.HasOne("CMSCore.Library.Data.Models.Content", "Content")
                        .WithMany("ContentVersions")
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Feed", b =>
                {
                    b.HasOne("CMSCore.Library.Data.Models.Page", "Page")
                        .WithOne("Feed")
                        .HasForeignKey("CMSCore.Library.Data.Models.Feed", "PageId");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.FeedItem", b =>
                {
                    b.HasOne("CMSCore.Library.Data.Models.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("CMSCore.Library.Data.Models.Feed", "Feed")
                        .WithMany("FeedItems")
                        .HasForeignKey("FeedId");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Page", b =>
                {
                    b.HasOne("CMSCore.Library.Data.Models.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.Tag", b =>
                {
                    b.HasOne("CMSCore.Library.Data.Models.FeedItem", "FeedItem")
                        .WithMany("Tags")
                        .HasForeignKey("FeedItemId");
                });

            modelBuilder.Entity("CMSCore.Library.Data.Models.User", b =>
                {
                    b.HasOne("CMSCore.Library.Data.Models.Content", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId1");
                });
#pragma warning restore 612, 618
        }
    }
}
