using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public class ItemEditViewModel
    {

        [Required]

        public int ID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]

        public decimal Price { get; set; }

    }
}
