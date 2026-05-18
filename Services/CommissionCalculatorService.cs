using ELGlamPOS.Models;

namespace ELGlamPOS.Services
{
    public class CommissionCalculatorService : ICommissionCalculatorService
    {
        public decimal CalculateCommission(TransactionItem item, Employee employee)
        {
            if (employee == null || !employee.CommissionRules.Any())
                return 0m;

            // Order rules by priority descending to find the most specific rule first
            var rules = employee.CommissionRules.OrderByDescending(r => r.Priority).ToList();

            foreach (var rule in rules)
            {
                bool matchesType = !rule.TargetItemType.HasValue || rule.TargetItemType.Value == item.ServiceItem.Type;
                
                bool matchesCategory = string.IsNullOrEmpty(rule.TargetCategory) || 
                                     string.Equals(rule.TargetCategory, item.ServiceItem.Category?.Name, StringComparison.OrdinalIgnoreCase);
                
                bool matchesMinPrice = !rule.MinPrice.HasValue || item.PriceAtTimeOfSale > rule.MinPrice.Value;
                
                bool matchesMaxPrice = !rule.MaxPrice.HasValue || item.PriceAtTimeOfSale < rule.MaxPrice.Value;

                bool matchesSpecificService = string.IsNullOrEmpty(rule.TargetServiceIds) || 
                                              rule.TargetServiceIds.Split(',').Contains(item.ServiceItem.Id.ToString());

                if (matchesType && matchesCategory && matchesSpecificService && matchesMinPrice && matchesMaxPrice)
                {
                    // Rule matched, calculate percentage
                    return item.PriceAtTimeOfSale * (rule.Percentage / 100m);
                }
            }

            return 0m;
        }
    }
}
