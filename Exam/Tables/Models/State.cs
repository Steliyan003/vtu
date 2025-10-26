using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables.Models
{
    public class State
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(20)]
        public string stateName { get; set; }
    }
}
