namespace ELGlamPOS.Models
{
    public class DraftOrderItem
    {
        public int Id { get; set; }
        public int DraftOrderId { get; set; }
        public DraftOrder DraftOrder { get; set; } = null!;

        public int ServiceItemId { get; set; }
        public ServiceItem ServiceItem { get; set; } = null!;

        public int? AssignedEmployeeId { get; set; }
        public Employee? AssignedEmployee { get; set; }

        public decimal FinalPrice { get; set; }
    }
}
