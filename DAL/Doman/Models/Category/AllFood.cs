using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doman.Models.Category
{
    public class AllFood
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create { get; set; }
        public DateTime? Update { get; set; }
        public DaysMenu? Day { get; set; }
    }
}
