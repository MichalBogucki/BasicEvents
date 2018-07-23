using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    public class CustomerRepsitory
    {
        public static List<Customer> Retrive()
        {
            var customerList = new List<Customer>()
            {
                new Customer() {City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer() {City = "Phoenix", FirstName = "Zahn", LastName = "Zoe", ID = 500},
                new Customer() {City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer() {City = "New YorCity", FirstName = "Michelle", LastName = "Smith", ID = 4}
            };

            return customerList;
        }
    }
}
