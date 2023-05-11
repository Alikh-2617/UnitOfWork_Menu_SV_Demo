using DAL.AppDbContext;
using DAL.Doman.Contracts;
using DAL.Doman.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Categorys
{
    public class BreakFastService : GenericService<BreakFast> , IBreakFast
    {
        public BreakFastService(ApplicationDbContext context):base(context) 
        {
            
        }

        public async Task<IEnumerable<BreakFast>> DayMenu(string day) => await _context.BreakFasts.Where(x => x.Day == day).ToListAsync();
    }
}
