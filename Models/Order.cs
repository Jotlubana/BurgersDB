using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BurgersDB.Models
{
    public class Order // Order model class
    {
        [Key]
        public int OId { get; set; }
        // quantity of the order
        public int Quantity { get; set; }
        // name of the person giving order
        public string Name { get; set; } = "Client";
        // total price of the order
        public double TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
    }
}
