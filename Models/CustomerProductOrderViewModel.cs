using System.Collections.Generic;

namespace Storage5.Models
{
    public class CustomerProductOrderViewModel : Order
    {
        public string CustomerFname { get; set; }

        public string CustomerLname { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        public List<Product> Products { get; set; }

    }
}