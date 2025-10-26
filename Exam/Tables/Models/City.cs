﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string CityName { get; set; }
    }
}
