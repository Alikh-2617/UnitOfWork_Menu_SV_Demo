using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Doman.Contracts
{
    public interface IUnitOfWork :IDisposable
    {
        IBreakFast BreakFast { get; }
        IDessert Dessert { get; }
        IDinner Dinner { get; } 
        IDrink Drink { get; }
        ILunch Lunch { get; }
        ISoda Soda { get; }
        //IDaysMenu Menu { get; }
        Task save();   
    }
}
