using DataAccessLayer_DAL;
using DataAccessLayer_DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    
    public class SqlOrdersRepository : IRepository<Orders>
    {
        private LaptopStoreDbContext _context;
        public SqlOrdersRepository(LaptopStoreDbContext context)
        {
            _context = context;
        }
        public bool Add(Orders item)
        {
            try
            {
                /* var ords = _context.Orders.ToList();
                 Orders b1 = item;
                 b1.Id = ords.Max(x => x.Id) + 1;
                 _context.Orders.Add(b1);
                 _context.SaveChanges();*/
                _context.Add(item);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Orders item)
        {
            throw new NotImplementedException();
        }

        public bool Edit(Orders item)
        {
            throw new NotImplementedException();
        }

        public Orders Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetByCustId(string id)
        {
            if (_context.Orders.Count(x => x.CustomerId == id) > 0)
            {
                return _context.Orders.Where(x => x.CustomerId == id).ToList();
            }
            return null;
        }
        /* public List<Orders> GetByCustId(string custId)
{
    var orders = _context.Orders.Where(x => x.CustomerId ==custId ).ToList();
    return orders;
}*/
    }
}
