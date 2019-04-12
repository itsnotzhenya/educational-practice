using webApi.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace webApi.Model
{
    public class Awards : Entity
    {
        public bool Oscar { get; set; }
        public bool GoldenGlob { get; set; }
        public bool Bafta { get; set; }

        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}