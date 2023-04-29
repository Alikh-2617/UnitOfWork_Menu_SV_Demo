using DAL.AppDbContext;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Categorys
{
    public class DinnerService:GenericService<Dinner> ,IDinner
    {
        public DinnerService(ApplicationDbContext context) : base(context) 
        {
            
        }
    }
}
