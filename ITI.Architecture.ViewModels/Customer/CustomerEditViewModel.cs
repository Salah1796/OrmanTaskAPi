using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Architecture.ViewModels
{
    public class CustomerEditViewModel
    {

        [Required]

        public int ID { get; set; }
        [Required]

        public int GroupID { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Email { get; set; }
        [Required]
     
        public string Phone { get; set; }



    }
}
