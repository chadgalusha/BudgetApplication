using BudgetApplication.Models;

namespace BudgetApplication.DataAccess
{
    public class IncomesDataAccess
    {
        private readonly BudgetApplicationContext _context;

        public IncomesDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }


    }
}
