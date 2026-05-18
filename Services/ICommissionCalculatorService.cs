using ELGlamPOS.Models;

namespace ELGlamPOS.Services
{
    public interface ICommissionCalculatorService
    {
        decimal CalculateCommission(TransactionItem item, Employee employee);
    }
}
