namespace ELGlamPOS.Models
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
