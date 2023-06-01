using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Doman.Models.Category
{
    public class BreakFast 
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public string? Day { get; set; }
        public string? ImageName { get; set; }

        //[NotMapped] 
        //public string ImageUrl { get; set;}
    }
}
