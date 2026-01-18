using Microsoft.EntityFrameworkCore;
using pressAgency.Domain.Entites;

namespace pressAgency.Domain.Context
{
    public class PressDbContext : DbContext
    {
        public PressDbContext(DbContextOptions<PressDbContext> options) : base(options) { }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<PostsLock> PostsLocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new DBInitializer(modelBuilder).Seed();

            modelBuilder.Entity<Authors>(entity =>
            {
                entity.HasKey(e => e.AuthorId);

                entity.Property(e => e.Email)
                      .IsRequired();

                entity.HasIndex(e => e.Email)
                      .IsUnique();
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.Title)
                      .IsRequired(true)
                      .HasMaxLength(100);

                entity.Property(e => e.Content)
                      .IsRequired(true)
                      .HasMaxLength(1000);

                entity.HasOne(x => x.Author)
                      .WithMany(x => x.Posts)
                      .HasForeignKey(e => e.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<PostsLock>(entity =>
            {
                entity.HasKey(e => e.PostLockId);

                entity.HasOne(x => x.Post)
                      .WithMany(x => x.PostsLocks)
                      .HasForeignKey(e => e.PostId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(x => x.Author)
                      .WithMany(x => x.PostsLocks)
                      .HasForeignKey(e => e.AuthorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
