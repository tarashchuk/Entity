using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entity2
{
    class PhoneContext : DbContext
    {
        static PhoneContext()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        public PhoneContext() : base("DBPhone")
        { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Phone> Phones { get; set; }
    }

   class MyContextInitializer : DropCreateDatabaseAlways<PhoneContext>
    {
        protected override void Seed(PhoneContext db)
        {
            Company c1 = new Company { Name = "Samsung" };
            Company c2 = new Company { Name = "Apple" };
            Company c3 = new Company { Name = "Xiaomi" };
            db.Companies.Add(c1);
            db.Companies.Add(c2);
            db.Companies.Add(c3);

            db.SaveChanges();
 
            Phone p1 = new Phone { Name = "Samsung Galaxy S10", Price = 25000, Company = c1 };
            Phone p2 = new Phone { Name = "Samsung Galaxy S9", Price = 20000, Company = c1 };
            Phone p3 = new Phone { Name = "iPhone xr", Price = 28000, Company = c2 };
            Phone p4 = new Phone { Name = "iPhone xs", Price = 23000, Company = c2 };
            Phone p5 = new Phone { Name = "Xiaomi mi 9 se", Price = 8000, Company = c3 };
            Phone p6 = new Phone { Name = "Xiaomi mi 8", Price =9000, Company = c3 };

            db.Phones.AddRange(new List<Phone>() { p1, p2, p3, p4, p5, p6 });
            db.SaveChanges();
        }
    }
    
}
