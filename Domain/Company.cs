using System;
using System.Collections.Generic;

namespace efcore_domain_event.Domain
{
    public class Company
    {
        private List<Order> _orders = new();

        public int Id { get; private set; }
        public string Name { get; private set; }
        public Discount Discount { get; private set; }
        public IReadOnlyCollection<Order> Orders => _orders;

        private Company()
        {
        }

        public Company(string name, Discount discount)
        {
            Name = name;
            Discount = discount;
        }

        public void UpdateDiscount(Discount discount)
        {
            Discount = discount ?? throw new ArgumentNullException(nameof(discount));
        }

        public void AddOrder(int amount)
        {
            var orderAmountAfterDiscount = amount - Discount.Amount;
            var order = new Order(amount, orderAmountAfterDiscount);
            _orders.Add(order);
        }

        public override string ToString()
        {
            return $"Name: {Name}, Discount Amount: {Discount.Amount} Discount Level: {Discount.Level}";
        }
    }
}
