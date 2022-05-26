using DataAccessLayer_DAL;
using DataAccessLayer_DAL.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class SqlLaptopsRepository : IRepository<Laptop>
    {
        private LaptopStoreDbContext _context;
        public SqlLaptopsRepository(LaptopStoreDbContext context)
        {
            _context = context; 
        }
        public bool Add(Laptop item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Laptop item)
        {
            try
            {
                Laptop laptop = Get(item.Id);
                if (laptop != null)
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Laptop item)
        {
            try
            {
                Laptop laptop = Get(item.Id);
                if (laptop != null)
                {

                    /*_context.Update(item);
                    _context.SaveChanges();*/
                    var entry = _context.Laptops.First(e => e.Id == item.Id);
                    _context.Entry(entry).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                   
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Hello" + e);
                return false;
            }
        }

        public Laptop Get(int id)
        {
            if(_context.Laptops.Count(x=>x.Id==id)>0)
            {
                return _context.Laptops.FirstOrDefault(x => x.Id == id);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Laptop> GetAll()
        {
            return _context.Laptops;
        }

        public List<Laptop> GetByCustId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
