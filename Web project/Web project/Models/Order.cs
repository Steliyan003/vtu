using System;
using System.Collections.Generic;

namespace WebProject.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        // Флаг дали поръчката е завършена
        public bool IsCompleted { get; set; }

        // 🔽🔽🔽 НОВИ СВОЙСТВА ЗА ДАННИТЕ НА КЛИЕНТА 🔽🔽🔽
        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? Notes { get; set; }
        // 🔼🔼🔼 НОВИ СВОЙСТВА 🔼🔼🔼

        public ICollection<OrderProduct> Items { get; set; } = new List<OrderProduct>();
    }
}
