using DAL.Doman.Models.Category;

namespace MenuAPI.ViewModels
{
    public class GenericModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public string? Day { get; set; }
    }
}
