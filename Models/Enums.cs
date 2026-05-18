namespace ELGlamPOS.Models
{
    public enum EmployeeRole
    {
        Receptionist,
        ServiceProvider,
        Admin
    }

    public enum ItemType
    {
        Service,
        Product
    }

    public enum DraftOrderStatus
    {
        Draft,
        Completed,
        Cancelled
    }
}
