using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BCS.Directory.CORE.Entity
{
    public class EntityBase<T>
    {
        [Key]
        public virtual T Id { get; set; }
    }
}
