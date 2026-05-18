namespace ELGlamPOS.Models
{
    public class DraftOrder
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DraftOrderStatus Status { get; set; } = DraftOrderStatus.Draft;

        public string? CustomerName { get; set; }
        public string? CustomerContactNo { get; set; }
        public string? Note { get; set; }

        public decimal DiscountAmount { get; set; }
        public string? DiscountDescription { get; set; }
        public string? PaymentMethod { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public int CreatedByEmployeeId { get; set; }
        public Employee CreatedByEmployee { get; set; } = null!;

        public int? TransactionId { get; set; }
        public Transaction? Transaction { get; set; }

        public ICollection<DraftOrderItem> Items { get; set; } = new List<DraftOrderItem>();
    }
}
