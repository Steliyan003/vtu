using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebProject.Models;

namespace WebProject.ViewModels
{
    public class CheckoutViewModel
    {
        
        public List<OrderProduct> Items { get; set; } = new List<OrderProduct>();

        
        [Display(Name = "Обща сума")]
        public decimal TotalAmount { get; set; }

        
        [Required]
        [Display(Name = "Име и фамилия")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Адрес")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Град")]
        public string City { get; set; } = string.Empty;

        [Display(Name = "Бележки")]
        public string? Notes { get; set; }
    }
}
