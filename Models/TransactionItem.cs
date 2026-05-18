namespace ELGlamPOS.Models
{
    public class TransactionItem
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int ServiceItemId { get; set; }
        
        public int AssignedEmployeeId { get; set; }
        public Employee AssignedEmployee { get; set; } = null!;

        public int Quantity { get; set; }
        public decimal PriceAtTimeOfSale { get; set; }
        public decimal CalculatedCommission { get; set; }

        public Transaction Transaction { get; set; } = null!;
        public ServiceItem ServiceItem { get; set; } = null!;
    }
}
