using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyEdition_2._0.Models
{
    public  class Medicine_products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedAt { get; set; } 
        public int UpdatedAt { get; set;}
        public float Price { get; set; }
    }
}
