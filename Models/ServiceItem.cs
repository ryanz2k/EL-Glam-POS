namespace ELGlamPOS.Models
{
    public class ServiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        
        // Use BasePrice to handle both static and variable starting prices
        public decimal BasePrice { get; set; }
        
        // If true, the Receptionist can edit this price upwards during checkout
        public bool IsVariablePrice { get; set; } = false;
        
        public bool IsActive { get; set; } = true;
        
        public ItemType Type { get; set; } = ItemType.Service;
        
        public int CategoryId { get; set; }
        public ServiceCategory Category { get; set; } = null!;
    }
}
