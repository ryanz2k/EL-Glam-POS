namespace ELGlamPOS.Models
{
    public class DailyReport
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        // Manual Inputs for End of Day
        public decimal CashAdvance { get; set; }
        public decimal Expenses { get; set; }
        public decimal PullOut { get; set; }
        public decimal OpeningCashOnHand { get; set; }
        
        // Denominations
        public int Denom1000 { get; set; }
        public int Denom500 { get; set; }
        public int Denom200 { get; set; }
        public int Denom100 { get; set; }
        public int Denom50 { get; set; }
        public int Denom20 { get; set; }
        public int Denom10 { get; set; }
        public int Denom5 { get; set; }
        public int Denom1 { get; set; }

        public decimal ComputeTotalCashOnHand()
        {
            return (Denom1000 * 1000m) +
                   (Denom500 * 500m) +
                   (Denom200 * 200m) +
                   (Denom100 * 100m) +
                   (Denom50 * 50m) +
                   (Denom20 * 20m) +
                   (Denom10 * 10m) +
                   (Denom5 * 5m) +
                   (Denom1 * 1m);
        }
    }
}
