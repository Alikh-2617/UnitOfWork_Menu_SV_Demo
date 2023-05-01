using DAL.Doman.Models.Category;

namespace MenuAPI.ViewModels
{
    public class GenericVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public DaysMenu? Day { get; set; }
    }
}
