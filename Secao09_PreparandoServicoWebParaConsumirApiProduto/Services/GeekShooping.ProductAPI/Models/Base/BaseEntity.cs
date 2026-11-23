using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShooping.ProductAPI.Models.Base
{
    public class BaseEntity
    {
        [Key] //Annotation to specify that this property is the primary key of the entity
        [Column("id")] 
        public long Id { get; set; }
    }
}