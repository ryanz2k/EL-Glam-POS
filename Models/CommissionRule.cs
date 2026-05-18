namespace ELGlamPOS.Models
{
    public class CommissionRule
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public decimal Percentage { get; set; }
        
        // Null means applies to both Product and Service
        public ItemType? TargetItemType { get; set; }
        
        // Null means applies to any category
        public string? TargetCategory { get; set; }
        
        // Comma separated list of ServiceItem IDs, e.g. "1,4,5"
        public string? TargetServiceIds { get; set; }
        
        // Null means no minimum
        public decimal? MinPrice { get; set; }
        
        // Null means no maximum
        public decimal? MaxPrice { get; set; }
        
        // Higher value means higher priority when evaluating rules
        public int Priority { get; set; }
    }
}
