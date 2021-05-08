using efcore_domain_event.Domain;
using efcore_domain_event.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace efcore_domain_event
{
    class Program
    {
        static void Main()
        {
            using (var context = new ApplicationContext())
            {
                if (!context.Companies.Any())
                {
                    Console.WriteLine("Seeding compandies");

                    context.AddRange(new List<Company>
                    {
                        new Company("ABC 1", new Discount(0, 0)),
                        new Company("ABC 2", new Discount(1, 100)),
                        new Company("ABC 3", new Discount(0, 0))
                    });

                    context.SaveChanges();
                }

                var companies = context.Companies.ToArray();

                foreach(var company in companies)
                {
                    Console.WriteLine(company);
                }

                Console.WriteLine();
                foreach (var company in companies)
                {
                    Console.WriteLine("Adding order with amount 1000 to all companies");
                    
                    company.AddOrder(1000);
                    context.SaveChanges();
                }

                Console.WriteLine();
                foreach (var company in companies)
                {
                    Console.WriteLine($"{company.Name} orders:");
                    foreach(var order in company.Orders)
                    {
                        Console.WriteLine($"{order.Amount} after discount {order.AmountAfterDiscount}");
                    }
                    Console.WriteLine();
                }

                
            }
        }
    }
}
