using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [Required]
        [MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "1000")]
        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
