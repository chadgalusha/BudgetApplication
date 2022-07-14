﻿using BudgetApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace BudgetApplication.DataAccess
{
    public class IncomeTypesDataAccess : ITypeDataAccess<IncomeTypes>
    {
        private readonly BudgetApplicationContext _context;

        public IncomeTypesDataAccess(BudgetApplicationContext context)
        {
            _context = context;
        }

        public async Task<IList> GetAllAsync()
        {
            return await _context.IncomeTypes.ToListAsync();
        }

        public async Task<IncomeTypes> GetByIdAsync(int incomeTypeid)
        {
            return await _context.IncomeTypes.Where(i => i.IncomeTypeId == incomeTypeid).FirstOrDefaultAsync();
        }
    }
}
