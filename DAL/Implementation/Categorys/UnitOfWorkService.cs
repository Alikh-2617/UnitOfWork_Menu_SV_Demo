using DAL.AppDbContext;
using DAL.Doman.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation.Categorys
{
    public class UnitOfWorkService : IUnitOfWork
    {
        protected readonly ApplicationDbContext _context;

        public UnitOfWorkService(ApplicationDbContext context)
        {
            _context = context;
            BreakFast = new BreakFastService(context);
            Dessert = new DessertService(context);
            Dinner = new DinnerService(context); 
            Drink = new DrinkService(context);
            Lunch = new LunchService(context);
            Soda = new SodaService(context);
            //Menu = new DaysMenuService(context);
        }

        // bör vara lika namn som står i IUnitOfWork Contrakt
        public IBreakFast BreakFast {get; private set;} 

        public IDessert Dessert{get; private set;}

        public IDinner Dinner {get; private set;}

        public IDrink Drink {get; private set;}

        public ILunch Lunch { get; private set;}    

        public ISoda Soda {get; private set;}

        public void Dispose() => _context.Dispose();    

        public Task save() => _context.SaveChangesAsync();
    }
}
