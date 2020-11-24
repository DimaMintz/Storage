using System.ComponentModel.DataAnnotations;

namespace Storage5.Models
{
    public class Status
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}