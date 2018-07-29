using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.CORE.Entity
{
    public class EmployeeSettings : EntityBase<int>
    {
        public int EmployeeId { get; set; }
        public bool IsBirthDatePrivate { get; set; }
        public bool IsAgePrivate { get; set; }
        public bool IsHobbiesAndInterestPrivate { get; set; }
        public bool IsCivilStatusPrivate { get; set; }
        public bool IsAddressPrivate { get; set; }

    }
}
