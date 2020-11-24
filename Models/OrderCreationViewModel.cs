using System.Collections.Generic;


namespace Storage5.Models
{
    public class OrderCreationViewModel : Order
    {
        public OrderCreationViewModel()
        {
            Products = new List<OrderedProduct>();
        }

        public List<OrderedProduct> Products { get; set; }

    }
}