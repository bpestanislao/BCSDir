using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.CORE.Entity
{
    public class SystemParameter : EntityBase<int>
    {
        public string FieldGroup { get; set; }
        public string FieldValue { get; set; }
        public int FieldId { get; set; }
        public bool IsActive { get; set; }
    }
}
