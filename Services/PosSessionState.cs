using ELGlamPOS.Models;

namespace ELGlamPOS.Services
{
    public class PosSessionState
    {
        public int? CurrentEmployeeId { get; private set; }
        public int? CurrentBranchId { get; private set; }
        public Employee? CurrentEmployee { get; private set; }
        public Branch? CurrentBranch { get; private set; }
        public ApplicationUser? CurrentUser { get; private set; }

        public event Action? OnChange;

        public void SetSession(ApplicationUser user, Employee employee)
        {
            CurrentUser = user;
            CurrentEmployee = employee;
            CurrentEmployeeId = employee.Id;
            
            // Auto-select their assigned branch by default
            SetBranch(employee.BranchId, employee.Branch);
            
            NotifyStateChanged();
        }

        public void SetBranch(int branchId, Branch? branch = null)
        {
            CurrentBranchId = branchId;
            CurrentBranch = branch;
            NotifyStateChanged();
        }

        public void ClearSession()
        {
            CurrentUser = null;
            CurrentEmployee = null;
            CurrentEmployeeId = null;
            CurrentBranch = null;
            CurrentBranchId = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
