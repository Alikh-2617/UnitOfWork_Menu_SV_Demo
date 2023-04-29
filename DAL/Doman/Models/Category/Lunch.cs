using System.ComponentModel.DataAnnotations;

namespace DAL.Doman.Models.Category
{
    public class Lunch
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public DaysMenu? Day { get; set; }
    }
}
