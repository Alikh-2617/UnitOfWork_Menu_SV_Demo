using DAL.Doman.Models.Category;

namespace MenuAPI.ViewModels
{
    public class Drink_SodaVM
    {
        public string Name { get; set; }
        public string Size { get; set; }

        public IFormFile Image { get; set; }
    }
}
