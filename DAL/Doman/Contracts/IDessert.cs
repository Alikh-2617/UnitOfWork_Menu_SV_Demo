using DAL.Doman.Models.Category;
using DAL.Doman.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doman.Contracts
{
    public interface IDessert:IGenericRepository<Dessert>
    {
        Task<IEnumerable<Dessert>> DayMenu(string day);
    }
}
