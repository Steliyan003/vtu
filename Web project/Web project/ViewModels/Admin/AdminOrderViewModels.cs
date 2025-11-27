using System;
using System.Collections.Generic;
using WebProject.Models;

namespace WebProject.ViewModels.Admin
{
    public class AdminOrderListItemViewModel
    {
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public string? FullName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsCompleted { get; set; }
        public decimal TotalAmount { get; set; }
    }

    public class AdminOrderDetailsViewModel
    {
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsCompleted { get; set; }
        public decimal TotalAmount { get; set; }

        public IList<OrderProduct> Items { get; set; } = new List<OrderProduct>();
    }
}
