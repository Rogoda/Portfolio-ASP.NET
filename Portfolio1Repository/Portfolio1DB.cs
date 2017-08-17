namespace Portfolio1Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Portfolio1DB : DbContext
    {
        public Portfolio1DB()
            : base("name=Portfolio1DB")
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<ContactMe> ContactMe { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ContactMe>()
                .Property(e => e.EmailPassword)
                .IsUnicode(false);
        }
    }
}
