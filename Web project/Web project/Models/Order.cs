using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public DateTime CreatedOn { get; set; }


        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }



        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Notes { get; set; }


        public ApplicationUser User { get; set; } = null!;
        public ICollection<OrderProduct> Items { get; set; } = new List<OrderProduct>();
        


    }
}
