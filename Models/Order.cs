using System;
using System.ComponentModel.DataAnnotations;

namespace Storage5.Models
{
    public class Order
    {
        public int Id { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreationDate { get; set; }

        [DataType(DataType.Date), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime EstimatedDate{ get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number")]
        public int StatusId { get; set; }

        public int CustomerId { get; set; }


        public Order()
        {
            this.CreationDate = DateTime.Now;
            this.StatusId = 1;
        }
    }
}