using MVP1.Model;
using System.Collections.Generic;
using System.Linq;

namespace MVP1.DataLayer
{
    public class EmployeeRepository
    {
        private RestaurantDbContext _ctx;

        public EmployeeRepository(RestaurantDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Employee> GetAllEmployees()
        {
            return _ctx.Employees.ToList();
        }


        public List<Employee> GetAllWaiters()
        {
            var waiterType = Enums.EmployeeType.Waiter.ToString();
            return _ctx.Employees
                .Where(e=>e.Type == waiterType)
                .ToList();
        }

        public Employee GetEmployeeByNameAndPin(string name, string pin)
        {
            return _ctx.Employees.
                FirstOrDefault(e => e.Name == name && e.Pin == pin);
        }

        public void Add(Employee employee)
        {
            _ctx.Employees.Add(employee);
            _ctx.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _ctx.Entry(employee).State = System.Data.Entity.EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void RemoveAt(long id)
        {
            var x = _ctx.Employees.Find(id);
            if(x != null)
            {
                _ctx.Employees.Remove(x);
                _ctx.SaveChanges();
            }
        }
    }
}
