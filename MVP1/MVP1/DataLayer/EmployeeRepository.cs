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

        public Employee GetEmployeeByNameAndPin(string name, string pin)
        {
            return _ctx.Employees.
                FirstOrDefault(e => e.Name == name && e.Pin == pin);
        }
    }
}
