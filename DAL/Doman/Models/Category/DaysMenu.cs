using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doman.Models.Category
{
    public class DaysMenu
    {
        [Key]
        public string Day { get; set; }
        public ICollection<BreakFast>? BreakFasts { get; set; }
        public ICollection<Dessert>? Desserts { get; set; }
        public ICollection<Dinner>? Dinners { get; set; }
        public ICollection<Lunch>? Lunches { get; set; }
        public ICollection<Soda>? Sodas { get; set; }
        public ICollection<Drink>? Drinks { get; set; }
    }
}
