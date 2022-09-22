using System.Collections.Generic;
using System.Linq;
using SharedModels;

namespace CustomerApi.Data
{
    public class DbInitializer : IDbInitializer
    {
        // This method will create and seed the database.
        public void Initialize(CustomerApiContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            // Look for any Customers
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            List<Customer> customers = new List<Customer>
            {
                new Customer { Name = "Brian", Email = "Brian@home.dk", Phone = 123456789, BillingAddress = "Storegade 1", ShippingAddress ="Storegade 2",HasGoodCreditStanding=true},
                new Customer { Name = "Hans",  Email = "Hans@home.dk", Phone = 888888888, BillingAddress = "Storegade 3", ShippingAddress ="Storegade 4",HasGoodCreditStanding=false}
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
