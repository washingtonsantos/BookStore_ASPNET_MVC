using BookStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Contexto
{
    public class BookStoreContexto : DbContext
    {
        public BookStoreContexto(DbContextOptions<BookStoreContexto> options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autor>(entidade => 
            {
                entidade.Property(p => p.Nome).HasMaxLength(50).IsRequired();
                entidade.HasMany(p => p.Livros).WithMany(a => a.Autores);
            });

            modelBuilder.Entity<Categoria>(entidade => 
            {
                entidade.Property(p => p.Nome).HasMaxLength(30).IsRequired();
                entidade.HasMany(x => x.Livros).WithOne(x => x.Categoria);
            });

            modelBuilder.Entity<Livro>(entidade => 
            {
                entidade.Property(x => x.Nome).HasMaxLength(50).IsRequired();
                entidade.Property(x => x.ISBN).HasMaxLength(30).IsRequired();
                entidade.Property(x => x.CategoriaId).IsRequired();
                entidade.Property(x => x.DataLancamento).IsRequired();
            });
        }
    }
}
