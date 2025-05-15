using System.ComponentModel.DataAnnotations;

namespace SimpleApi.Models
{
    public class Item
    {
        [Required]
        public int Id { get; set; }

        [Required, MinLength(3)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
    }
}
