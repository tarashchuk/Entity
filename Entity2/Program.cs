using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entity2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Показывает начальную базу данных
            Console.WriteLine("Начальна база");
            Console.WriteLine(new String('-', 30));
            using (PhoneContext db = new PhoneContext())
            {
                var groups = db.Phones.GroupBy(p => p.Company.Name);

                foreach (var g in groups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var p in g)
                        Console.WriteLine("{0} - {1}", p.Name, p.Price);
                    Console.WriteLine(new String('-', 30));
                }
            }

            //Код снизу добавляет записи в таблицы
            using (PhoneContext db = new PhoneContext())
            {
                while (true)
                {
                    Console.WriteLine("Чтобы добавить запись, нажмите далее, если не хотите добавлялть - введите next");

                    string search = Console.ReadLine();

                    if (search == "next")
                        break;
                    else
                    {
                        
                        Console.WriteLine("КОМПАНИЯ:");
                        string company_name = Console.ReadLine();
                        if (company_name == db.Companies.FirstOrDefault().Name)
                        {
                            Console.WriteLine("Такая компания существует, добавте телефон");
                            Company company = db.Companies.Where(c => c.Name == company_name).FirstOrDefault();
                            Console.WriteLine("Name:");
                            string phone_name = Console.ReadLine();
                            Console.WriteLine("Price:");
                            int phone_price = Convert.ToInt32(Console.ReadLine());
                            Phone phone = new Phone { Name = phone_name, Price = phone_price, Company = company };
                            db.Phones.Add(phone);
                            db.SaveChanges();

                        }
                        else
                        {
                            Company company = new Company { Name = company_name };
                            db.Companies.Add(company);
                            db.SaveChanges();
                            Console.WriteLine(" Компания добавлена, добавте телефон");
                            Console.WriteLine("Name:");
                            string phone_name = Console.ReadLine();
                            Console.WriteLine("Price:");
                            int phone_price = Convert.ToInt32(Console.ReadLine());
                            Phone phone = new Phone { Name = phone_name, Price =phone_price, Company = company };
                            db.Phones.Add(phone);
                            db.SaveChanges();
                        }

                    }

                }
            }
            Console.WriteLine(new String('-', 30));
            Console.WriteLine("База");
            Console.WriteLine(new String('-', 30));

            using (PhoneContext db = new PhoneContext())
            {
                var groups = db.Phones.GroupBy(p => p.Company.Name);

                foreach (var g in groups)
                {
                    Console.WriteLine(g.Key);
                    foreach (var p in g)
                        Console.WriteLine("{0} - {1}", p.Name, p.Price);
                    Console.WriteLine(new String('-', 30));
                }
            }

            //Поиск по компании
            using (PhoneContext db = new PhoneContext())
            {

                while (true)
                {
                    Console.WriteLine("Введити название компании для поиска или exit для выхода");

                    string search = Console.ReadLine();

                    if (search == "exit")
                        break;
                    else
                    {

                        var phones = db.Phones.Where(p => p.Company.Name==search);
                        foreach (Phone p in phones)
                            Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);

                        Console.WriteLine();
                    }

                }
            }

            using (PhoneContext db = new PhoneContext())
            {

                while (true)
                {
                    Console.WriteLine("Введити цену для поиска или exit для выхода");

                    string search = Console.ReadLine();

                    if (search == "exit")
                        break;
                    else
                    {
                        int price = Convert.ToInt32(search);

                        var phones = db.Phones.Where(p => p.Price <= price );
                        foreach (Phone p in phones)
                            Console.WriteLine("{0}.{1} - {2}", p.Id, p.Name, p.Price);

                        Console.WriteLine();
                    }

                }
            }

        }
    }
}
