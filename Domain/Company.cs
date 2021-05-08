namespace efcore_domain_event.Domain
{
    public class Company
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public float Discount { get; private set; }


        public Company(string name, float discount)
        {
            Name = name;
            Discount = discount;
        }
    }
}
