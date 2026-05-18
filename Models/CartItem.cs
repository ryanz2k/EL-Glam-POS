using System;

namespace ELGlamPOS.Models
{
    public class CartItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public ServiceItem ServiceItem { get; set; } = null!;
        public decimal FinalPrice { get; set; }
        public int Quantity { get; set; } = 1;
        
        // The employee who performed the service (gets the commission)
        public int? AssignedEmployeeId { get; set; }
        public string? AssignedEmployeeName { get; set; }

        public decimal Subtotal => FinalPrice * Quantity;
    }
}
