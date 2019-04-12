using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace webApi.Model
{
    public enum Genre
    {
        Camedy,
        Drama,
        Action,
        Detective,
        Tragedy
    }

    public class Film : IComparable<Film>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Prod { get; set; }
        public string Country { get; set; }
        public Genre Genre { get; set; }
        public Studio Studio { get; set; }
        public Awards Awards { get; set; }

        public int CompareTo(Film film)
        {
            return this.Name.CompareTo(film.Name);
        }
    }
}