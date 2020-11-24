namespace Storage5.Models
{
    public class CustomerProductOrder
    {
        public int Id {get; set;}

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }
    }
}