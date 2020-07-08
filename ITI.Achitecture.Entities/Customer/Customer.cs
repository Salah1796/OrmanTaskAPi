using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Achitecture.Entities
{
    [Table("Customer ", Schema = "dbo")]
    public class Customer : BaseModel
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Email { get; set; }
        [Required]
      
        public string Phone { get; set; }

        public virtual Group Group { get; set; }
        [Required]
        [ForeignKey("Group")]
        public int GroupID { get; set; }

    }

}
