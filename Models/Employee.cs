namespace ELGlamPOS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public EmployeeRole Role { get; set; }
        public string JobTitle { get; set; } = "Aesthetician";

        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public ICollection<CommissionRule> CommissionRules { get; set; } = new List<CommissionRule>();

        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Matches employee names from Firebase /appointments stylists array.
        /// Format used in Firebase: "LastName, FirstName" (e.g. "Dela Torre, Imae Rose").
        /// </summary>
        public string? FirebaseNameKey { get; set; }
    }
}
