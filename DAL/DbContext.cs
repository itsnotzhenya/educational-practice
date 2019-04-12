using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;
using webApi.Model;
namespace webApi
{
    public class FilmContext : DbContext
    {
        public FilmContext(DbContextOptions<FilmContext> options)
        : base(options)
        { }
        public DbSet<Film> Films { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=filmsdb;Uid=root;Pwd=;CharSet=utf8");
        }
    }
}