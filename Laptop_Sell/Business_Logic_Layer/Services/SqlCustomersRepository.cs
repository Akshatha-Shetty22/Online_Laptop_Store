
using DataAccessLayer_DAL;
using DataAccessLayer_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class SqlCustomersRepository : IRepository<Customer>
    {
        private LaptopStoreDbContext _context;
        public SqlCustomersRepository(LaptopStoreDbContext context)
        {
            _context = context;
        }
        public bool Add(Customer item)
        {
            try
            {
                /*   var customers = _context.Customers.ToList();
                   Customer b1 = item;
                   b1.Id = customers.Max(x => x.Id) + 1;
                   b1.CustId= "5a1160e3 - 9e44 - 4e9c - ade1 - 640dc36a6178";
                   _context.Customers.Add(b1);
                   _context.SaveChanges();
                */
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Customer item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Customer item)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            if (_context.Customers.Count(x => x.Id == id) > 0)
            {
                return _context.Customers.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Customers;
        }

        public List<Customer> GetByCustId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
