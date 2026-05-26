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
        Synced,
        Failed
    }

    public class Transaction : SyncableEntity
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public decimal TotalAmount { get; set; }
        public PaymentType PaymentType { get; set; }

        public decimal CashAmount { get; set; }
        public decimal GCashAmount { get; set; }
        public decimal MayaAmount { get; set; }
        public decimal BankTransferAmount { get; set; }

        public string? CustomerName { get; set; }
        public string? CustomerContactNo { get; set; }
        public string? Note { get; set; }

        public decimal DiscountAmount { get; set; }
        public string? DiscountDescription { get; set; }

        /// <summary>Firebase key of the source appointment, if this transaction originated from a booking.</summary>
        public string? SourceAppointmentKey { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public int ReceptionistId { get; set; }
        public Employee Receptionist { get; set; } = null!;

        public ICollection<TransactionItem> Items { get; set; } = new List<TransactionItem>();
    }
}
