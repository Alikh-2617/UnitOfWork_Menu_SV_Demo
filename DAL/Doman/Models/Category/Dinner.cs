using System.ComponentModel.DataAnnotations;

namespace DAL.Doman.Models.Category
{
    public class Dinner
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Update { get; set; }
        public string? Day { get; set; }
    }
}