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
    public class LunchService : GenericService<Lunch>, ILunch
    {
        public LunchService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Lunch>> DayMenu(string day) => await _context.Lunch.Where(x=>x.Day == day).ToListAsync();
    }
}
