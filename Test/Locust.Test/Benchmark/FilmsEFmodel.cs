namespace Locust.Test.Benchmark
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FilmsEFmodel : DbContext
    {
        public FilmsEFmodel()
            : base("name=FilmsEFmodel")
        {
        }

        public virtual DbSet<FilmTBL> FilmTBLs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FilmTBL>()
                .Property(e => e.Trailer)
                .IsUnicode(false);

            modelBuilder.Entity<FilmTBL>()
                .Property(e => e.Year)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<FilmTBL>()
                .Property(e => e.Filmimage)
                .IsUnicode(false);

            modelBuilder.Entity<FilmTBL>()
                .Property(e => e.FilmHorizontalImage)
                .IsUnicode(false);
        }
    }
}
