﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Achitecture.Entities
{
    [Table("Item", Schema ="dbo")]
    public class Item : BaseModel
    {
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
}
}
