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

        public static implicit operator AllFood(GenericVM food)
        {
            return new AllFood
            {
                Id = Guid.NewGuid(),
                Name = food.Name,
                Description = food.Description,
                Create = DateTime.Now,
                Update = DateTime.Now,  
                Day = food.Day,
            };
        }
    }
}
