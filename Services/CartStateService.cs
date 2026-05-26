using ELGlamPOS.Models;
using System.Collections.Generic;
using System.Linq;

namespace ELGlamPOS.Services
{
    public class DiscountEntry
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Type { get; set; } = "Flat"; // "Flat" or "Percentage"
        public decimal Value { get; set; }
        public HashSet<string> TargetCartItemIds { get; set; } = new(); // empty = Total Order
        public bool IsTotal => TargetCartItemIds.Count == 0;
    }

    public class CartStateService
    {
        private List<CartItem> _items = new();
        public IReadOnlyList<CartItem> Items => _items.AsReadOnly();

        private List<DiscountEntry> _discounts = new();
        public IReadOnlyList<DiscountEntry> Discounts => _discounts.AsReadOnly();

        /// <summary>Firebase key of the appointment this cart was loaded from. Null for walk-in orders.</summary>
        public string? SourceAppointmentKey { get; private set; }

        public int? SourceDraftOrderId { get; private set; }

        public void SetSourceAppointment(string firebaseKey, int? draftOrderId = null)
        {
            SourceAppointmentKey = firebaseKey;
            SourceDraftOrderId = draftOrderId;
        }

        /// <summary>Tracks a regular (non-booking) draft so SaveAndLeave updates it instead of duplicating.</summary>
        public void SetSourceDraftOrder(int draftOrderId) => SourceDraftOrderId = draftOrderId;

        /// <summary>Customer name pre-filled from a booking. Checkout page reads this on init.</summary>
        public string? BookingCustomerName { get; private set; }
        public string? BookingCustomerPhone { get; private set; }
        public string? BookingNote { get; private set; }

        public void SetBookingCustomer(string? name, string? phone, string? note)
        {
            BookingCustomerName = name;
            BookingCustomerPhone = phone;
            BookingNote = note;
        }

        public event Action? OnChange;

        public decimal Subtotal => _items.Sum(i => i.Subtotal);

        public decimal DiscountAmount => _discounts.Sum(d => CalculateDiscountEntry(d));

        public string DiscountDescription
        {
            get
            {
                if (_discounts.Count == 0) return string.Empty;
                return string.Join("; ", _discounts.Select(d => BuildSingleDescription(d)));
            }
        }

        public decimal Total => Math.Max(0, Subtotal - DiscountAmount);

        private decimal CalculateDiscountEntry(DiscountEntry d)
        {
            if (d.Value <= 0) return 0;

            if (d.IsTotal)
            {
                return d.Type == "Flat"
                    ? Math.Min(d.Value, Subtotal)
                    : Math.Round(Subtotal * d.Value / 100m, 2);
            }

            // Per-item: flat applies to each targeted item individually
            decimal total = 0;
            foreach (var item in _items.Where(i => d.TargetCartItemIds.Contains(i.Id)))
            {
                total += d.Type == "Flat"
                    ? Math.Min(d.Value, item.FinalPrice)
                    : Math.Round(item.FinalPrice * d.Value / 100m, 2);
            }
            return total;
        }

        private string BuildSingleDescription(DiscountEntry d)
        {
            string target;
            if (d.IsTotal)
            {
                target = "Total Order";
            }
            else if (d.TargetCartItemIds.Count == 1)
            {
                var item = _items.FirstOrDefault(i => i.Id == d.TargetCartItemIds.First());
                target = item?.ServiceItem?.Name ?? "Item";
            }
            else
            {
                target = $"{d.TargetCartItemIds.Count} items";
            }

            return d.Type == "Flat"
                ? $"₱{d.Value:N2} off {target}"
                : $"{d.Value}% off {target}";
        }

        public void AddItem(ServiceItem service, decimal customPrice = 0)
        {
            decimal price = service.IsVariablePrice ? customPrice : service.BasePrice;
            _items.Add(new CartItem { ServiceItem = service, FinalPrice = price });
            NotifyStateChanged();
        }

        public void RemoveItem(string cartItemId)
        {
            var item = _items.FirstOrDefault(i => i.Id == cartItemId);
            if (item != null)
            {
                _items.Remove(item);
                // Remove this item from any targeted discounts
                foreach (var d in _discounts)
                    d.TargetCartItemIds.Remove(cartItemId);
                // Remove discounts that now have no targets (were item-specific but all items removed)
                _discounts.RemoveAll(d => !d.IsTotal && d.TargetCartItemIds.Count == 0);
                NotifyStateChanged();
            }
        }

        public void AssignEmployee(string cartItemId, int employeeId, string employeeName)
        {
            var item = _items.FirstOrDefault(i => i.Id == cartItemId);
            if (item != null)
            {
                item.AssignedEmployeeId = employeeId;
                item.AssignedEmployeeName = employeeName;
                NotifyStateChanged();
            }
        }

        public void UpdatePrice(string cartItemId, decimal newPrice)
        {
            var item = _items.FirstOrDefault(i => i.Id == cartItemId);
            if (item != null)
            {
                item.FinalPrice = newPrice;
                NotifyStateChanged();
            }
        }

        public void AddDiscount(string type, decimal value, HashSet<string> targetCartItemIds)
        {
            _discounts.Add(new DiscountEntry
            {
                Type = type,
                Value = value,
                TargetCartItemIds = targetCartItemIds
            });
            NotifyStateChanged();
        }

        public void UpdateDiscount(string discountId, string type, decimal value, HashSet<string> targetCartItemIds)
        {
            var d = _discounts.FirstOrDefault(x => x.Id == discountId);
            if (d != null)
            {
                d.Type = type;
                d.Value = value;
                d.TargetCartItemIds = targetCartItemIds;
                NotifyStateChanged();
            }
        }

        public void RemoveDiscount(string discountId)
        {
            _discounts.RemoveAll(x => x.Id == discountId);
            NotifyStateChanged();
        }

        public void ClearDiscount()
        {
            _discounts.Clear();
            NotifyStateChanged();
        }

        // Legacy compat — used by ApplyDiscount in old code
        public void ApplyDiscount(string type, decimal value, string? targetCartItemId)
        {
            var targets = new HashSet<string>();
            if (targetCartItemId != null) targets.Add(targetCartItemId);
            AddDiscount(type, value, targets);
        }

        public void ClearCart()
        {
            _items.Clear();
            _discounts.Clear();
            SourceAppointmentKey = null;
            SourceDraftOrderId = null;
            BookingCustomerName = null;
            BookingCustomerPhone = null;
            BookingNote = null;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
