using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Achitecture.Entities
{
    public abstract class BaseModel
    {
        [Key]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity)]
        public virtual int ID { get; set; }
       
    }
}
