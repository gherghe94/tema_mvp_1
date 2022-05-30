using System.Collections.Generic;

namespace MVP1.Model
{
    public class Table
    {
        public long Id { get; set; }

        public int Number { get; set; }

        public int MaxOcc { get; set; }

        public int Occ { get; set; }

        public Employee AssignedEmployee { get; set; }

        public List<Product> Products { get; set; }
    }
}
