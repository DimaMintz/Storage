using System;
using System.Collections.Generic;

namespace Storage5.Models
{
    public class OrderInfoViewModel
    {
        public int OrderId { get; set; }

        public DateTime OrderCreationDate { get; set; }

        public DateTime OrderEstimatedDate { get; set; }

        public int OrderStatusId { get; set; }

        public int OrderCustomerId { get; set; }

        public int CustomerId { get; set; }

        public string CustomerFname { get; set; }

        public string CustomerLname { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        public List<Product> products { get; set; }

        public OrderInfoViewModel()
        {
            this.products = new List<Product>();
        }


    }
}