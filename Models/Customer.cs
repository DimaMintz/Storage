using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Storage5.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Fname { get; set; }

        [Required]
        public string Lname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}