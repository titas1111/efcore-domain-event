namespace efcore_domain_event.Domain
{
    public record Order
    {
        public int Amount { get; private set; }
        public int AmountAfterDiscount { get; private set; }

        public Order(int amount, int amountAfterDiscount)
        {
            Amount = amount;
            AmountAfterDiscount = amountAfterDiscount;
        }

        public override string ToString()
        {
            return $"Amount: {Amount}, AmountAfterDiscount: {AmountAfterDiscount}";
        }
    }
}
