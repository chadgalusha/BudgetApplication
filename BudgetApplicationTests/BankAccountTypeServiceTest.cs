using BudgetApplication.DataAccess;
using BudgetApplication.Models;
using BudgetApplication.Service;
using Moq;

namespace BudgetApplicationTests
{
    public class BankAccountTypeServiceTest
    {
        private readonly BankAccountTypeService _bankAccountTypeService;
        private readonly Mock<ITypeDataAccess<BankAccountTypes>> _bankAccountDataAccess = new();

        public BankAccountTypeServiceTest()
        {
            _bankAccountTypeService = new BankAccountTypeService(_bankAccountDataAccess.Object);
        }

        [Fact]
        public async Task GetAllAsync_ReturnsListOf_BankAccountTypes()
        {
            // Arrange
            var checking = "Checking";
            var savings = "Savings";
            List<BankAccountTypes> listOfBankAccountTypes = new()
            {
                new BankAccountTypes()
                {
                    BankAccountTypeId = 1,
                    BankAccountType = checking
                },
                new BankAccountTypes()
                {
                    BankAccountTypeId = 2,
                    BankAccountType = savings
                }
            };
            _bankAccountDataAccess.Setup(a => a.GetAllAsync()).ReturnsAsync(listOfBankAccountTypes);

            // Act
            var result = await _bankAccountTypeService.GetAllAsync();
            Type type = result.GetType();

            // Assert
            Assert.True(result != null);
            Assert.True(type.IsGenericType);
            Assert.Equal(listOfBankAccountTypes, result);
        }
    }
}
