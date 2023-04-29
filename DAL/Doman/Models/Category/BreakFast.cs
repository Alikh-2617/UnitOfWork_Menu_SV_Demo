using System.ComponentModel.DataAnnotations;

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
        public DaysMenu? Day { get; set; }
    }
}
