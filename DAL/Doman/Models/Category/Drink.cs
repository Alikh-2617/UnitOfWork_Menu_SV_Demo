using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doman.Models.Category
{
    public class Drink
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string? ImageName { get; set; }

        //[NotMapped]
        //public string ImageUrl { get; set; }
    }
}
