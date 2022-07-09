using BudgetApplication.Service;
using BudgetApplication.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BudgetApplicationTests
{
    public class BankAccountTypeServiceTests
    {
        Mock<BankAccountTypeService> bankAccountTypeServiceMock = new Mock<BankAccountTypeService>();
        DbSet<BankAccountTypes> dbSetBankAccountType = new Mock<DbSet<BankAccountTypes>>().Object;
        BankAccountTypes bankAccountType = new BankAccountTypes();

        [Fact]
        public void GetBankAccountTypesTest()
        {
            // arrange
            bankAccountTypeServiceMock.Setup(x => x.GetBankAccountTypes()).Returns(dbSetBankAccountType);

            // act
            DbSet<BankAccountTypes> result = bankAccountTypeServiceMock.Object.GetBankAccountTypes();

            // assert
            Assert.Equal(dbSetBankAccountType, result);
        }
    }
}
