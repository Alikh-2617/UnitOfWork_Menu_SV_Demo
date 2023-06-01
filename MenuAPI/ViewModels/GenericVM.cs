using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MenuAPI.ViewModels
{
    public class GenericVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public string? Day { get; set; }
        public int MyProperty { get; set; }
        public string ImageName { get; set; }
        public IFormFile Image { get; set; }
    }
}
