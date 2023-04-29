using DAL.AppDbContext;
using DAL.Doman.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Categorys
{
    public class DaysMenuService : IDaysMenu
    {
        protected readonly ApplicationDbContext _context;

        public DaysMenuService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<string> BreakFastMenu()
        {
            var breakFastMenu = _context.DaysMenu.
                Include(x=>x.BreakFasts).
                Include(y=>y.Desserts).
                Include(g=>g.Sodas).
                Include(t=>t.Drinks).ToList();
            return (IEnumerable<string>)breakFastMenu;
        }
        public IEnumerable<string> LunchMenu()
        {
            var lunchMenu = _context.DaysMenu.
                Include(x => x.Lunches).
                Include(y => y.Desserts).
                Include(g => g.Drinks).
                Include(j => j.Sodas).ToList();
            return (IEnumerable<string>)lunchMenu;
        }
        public IEnumerable<string> DinnerMenu()
        {
            var dinnerMenu = _context.DaysMenu.
                Include(x => x.Dinners).
                Include(y => y.Desserts).
                Include(h => h.Drinks).
                Include(f => f.Sodas).ToList();
            return (IEnumerable<string>)dinnerMenu; 
        }
    }
}
