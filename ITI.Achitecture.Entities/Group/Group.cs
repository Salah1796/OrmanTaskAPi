using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Achitecture.Entities
{
    [Table("Group ", Schema = "dbo")]
    public class Group : BaseModel
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }


    }

}
