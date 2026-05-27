namespace ELGlamPOS.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Area { get; set; }

        public ICollection<ServiceItem> Items { get; set; } = new List<ServiceItem>();
    }
}
