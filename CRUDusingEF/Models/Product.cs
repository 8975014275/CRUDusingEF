using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDusingEF.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required(ErrorMessage = "name is required")]
        public string? Name { get; set; }
        [Required(ErrorMessage = " company name is required")]
        public string? CompanyName { get; set; }
        [Required(ErrorMessage = "price is required")]
        public int Price { get; set; }

    }
}
