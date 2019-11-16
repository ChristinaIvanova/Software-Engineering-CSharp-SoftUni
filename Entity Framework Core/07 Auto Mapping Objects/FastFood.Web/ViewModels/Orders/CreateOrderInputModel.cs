using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Orders
{
    public class CreateOrderInputModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Customer { get; set; }

        public string ItemName { get; set; }

        public string EmployeeName { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Quantity { get; set; }

        public string OrderType { get; set; }
    }
}
