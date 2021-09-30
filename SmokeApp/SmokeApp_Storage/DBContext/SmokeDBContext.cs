using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SmokeApp_Storage.Models
{
    public partial class SmokeDBContext : DbContext
    {
        public SmokeDBContext()
        {
        }

        public SmokeDBContext(DbContextOptions<SmokeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Discussion> Discussions { get; set; }
        public virtual DbSet<DiscussionReply> DiscussionReplies { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<GamesPlatform> GamesPlatforms { get; set; }
        public virtual DbSet<Platform> Platforms { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionsComment> SubscriptionsComments { get; set; }
        public virtual DbSet<SubscriptionsDiscussion> SubscriptionsDiscussions { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:smokedb-server.database.windows.net,1433;Initial Catalog=SmokeDB;Persist Security Info=False;User ID=thesdbadmin;Password=Smokingh0t;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentsId)
                    .HasName("PK__Comments__9487C62CF8C9DD36");

                entity.Property(e => e.CommentsId).HasColumnName("CommentsID");

                entity.Property(e => e.CommentsContext)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SubscriptionsCommentsId).HasColumnName("SubscriptionsCommentsID");

                entity.HasOne(d => d.SubscriptionsComments)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.SubscriptionsCommentsId)
                    .HasConstraintName("FK__Comments__Subscr__7B5B524B");
            });

            modelBuilder.Entity<Discussion>(entity =>
            {
                entity.HasKey(e => e.DiscussionsId)
                    .HasName("PK__Discussi__40DC06E65E491888");

                entity.Property(e => e.DiscussionsId).HasColumnName("DiscussionsID");

                entity.Property(e => e.DiscussionsContext)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DiscussionsDate).HasColumnType("datetime");

                entity.Property(e => e.DiscussionsTitle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SubscriptionsDiscussionsId).HasColumnName("SubscriptionsDiscussionsID");

                entity.HasOne(d => d.SubscriptionsDiscussions)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.SubscriptionsDiscussionsId)
                    .HasConstraintName("FK__Discussio__Subsc__71D1E811");
            });

            modelBuilder.Entity<DiscussionReply>(entity =>
            {
                entity.HasKey(e => e.DiscussionRepliesId)
                    .HasName("PK__Discussi__E1B0E3DE9A55D579");

                entity.Property(e => e.DiscussionRepliesId).HasColumnName("DiscussionRepliesID");

                entity.Property(e => e.DiscussionRepliesContext)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DiscussionsId).HasColumnName("DiscussionsID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Discussions)
                    .WithMany(p => p.DiscussionReplies)
                    .HasForeignKey(d => d.DiscussionsId)
                    .HasConstraintName("FK__Discussio__Discu__75A278F5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DiscussionReplies)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Discussio__UserI__74AE54BC");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.GameDescription)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.GameName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GamesPlatform>(entity =>
            {
                entity.HasKey(e => e.GamePlatformId)
                    .HasName("PK__GamesPla__F6E218964C3F33A2");

                entity.Property(e => e.GamePlatformId).HasColumnName("GamePlatformID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.PlatformId).HasColumnName("PlatformID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GamesPlatforms)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__GamesPlat__GameI__6B24EA82");

                entity.HasOne(d => d.Platform)
                    .WithMany(p => p.GamesPlatforms)
                    .HasForeignKey(d => d.PlatformId)
                    .HasConstraintName("FK__GamesPlat__Platf__6C190EBB");
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.Property(e => e.PlatformId).HasColumnName("PlatformID");

                entity.Property(e => e.PlatformName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.Property(e => e.GameId).HasColumnName("GameID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Subscript__GameI__628FA481");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Subscript__UserI__6383C8BA");
            });

            modelBuilder.Entity<SubscriptionsComment>(entity =>
            {
                entity.HasKey(e => e.SubscriptionsCommentsId)
                    .HasName("PK__Subscrip__5B90AB33985C4B0A");

                entity.Property(e => e.SubscriptionsCommentsId).HasColumnName("SubscriptionsCommentsID");

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionsComments)
                    .HasForeignKey(d => d.SubscriptionId)
                    .HasConstraintName("FK__Subscript__Subsc__787EE5A0");
            });

            modelBuilder.Entity<SubscriptionsDiscussion>(entity =>
            {
                entity.HasKey(e => e.SubscriptionsDiscussionsId)
                    .HasName("PK__Subscrip__3CACE1E45BCDC43C");

                entity.Property(e => e.SubscriptionsDiscussionsId).HasColumnName("SubscriptionsDiscussionsID");

                entity.Property(e => e.SubscriptionId).HasColumnName("SubscriptionID");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.SubscriptionsDiscussions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .HasConstraintName("FK__Subscript__Subsc__6EF57B66");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E49EA2B263")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
