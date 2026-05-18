namespace ELGlamPOS.Models
{
    public enum PaymentType
    {
        Cash,
        GCash,
        Maya,
        BankTransfer,
        Split
    }

    public enum SyncStatus
    {
        Pending,
        Synced
    }

    public class Transaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public PaymentType PaymentType { get; set; }
        public SyncStatus SyncStatus { get; set; }
        
        public decimal CashAmount { get; set; }
        public decimal GCashAmount { get; set; }
        public decimal MayaAmount { get; set; }
        public decimal BankTransferAmount { get; set; }
        
        public string? CustomerName { get; set; }
        public string? CustomerContactNo { get; set; }
        public string? Note { get; set; }

        public decimal DiscountAmount { get; set; }
        public string? DiscountDescription { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public int ReceptionistId { get; set; }
        public Employee Receptionist { get; set; } = null!;

        public ICollection<TransactionItem> Items { get; set; } = new List<TransactionItem>();
    }
}
