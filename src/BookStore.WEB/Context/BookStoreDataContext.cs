using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WEB.Context
{
    public class BookStoreDataContext : DbContext
    {
        public BookStoreDataContext(DbContextOptions<BookStoreDataContext> contextOptions) : base(contextOptions)
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entity => 
            {
                entity.ToTable("Autor");
                entity.Property(x => x.Nome).HasMaxLength(50).IsRequired();
                entity.HasMany(x => x.Livros).WithMany(x => x.Autores);
            });

            modelBuilder.Entity<Categoria>(entity => 
            {
                entity.ToTable("Categoria");
                entity.Property(x => x.Nome).HasMaxLength(20).IsRequired();
                entity.HasMany(x => x.Livros).WithOne(x => x.Categoria);
            });

            modelBuilder.Entity<Livro>(entity =>
            {
                entity.ToTable("Livro");
                entity.Property(x => x.Nome).HasMaxLength(50).IsRequired();
                entity.Property(x => x.ISBN).HasMaxLength(30).IsRequired();
            }); 
        }
    }
}
