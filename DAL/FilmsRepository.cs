using System.Collections.Generic;
using System.Linq;
using webApi.Model;
namespace webApi.DAL
{
    public class FilmsRepository : IRepository<Film>
    {
        FilmContext db;
        public FilmsRepository(FilmContext context)
        {
            db = context;
        }

        public void Create(Film film)
        {
            db.Films.Add(film);
            db.SaveChanges();
        }

        public bool Delete(int id)
        {
            Film deletingFilm = db.Films.Where(f => f.Id == id).FirstOrDefault();
            db.Films.Remove(deletingFilm);
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Film> Get()
        {
            return db.Films;
        }
        public Film Get(int id)
        {
            return db.Films.Where(f => f.Id == id).FirstOrDefault();
        }

        public void Update(Film film)
        {
            // Film updatingFilm = db.Films.Where(f => f.Id == id).FirstOrDefault();
            db.Films.Update(film);
            // updatingFilm = film;
            db.SaveChanges();
        }
    }
}