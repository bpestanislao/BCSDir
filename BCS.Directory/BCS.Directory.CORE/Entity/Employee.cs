using System;
using System.Collections.Generic;
using System.Text;

namespace BCS.Directory.CORE.Entity
{
    public class Employee : EntityBase<int>
    {
        public DateTime Birthdate { get; set; }

        public int Age { get; set; }

        public string HobbiesAndInterest { get; set; }

        public string CivilStatus { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LanguagesSpoken { get; set; }

        public int PhoneNumber { get; set; }

        public int UserType { get; set; }

        public bool IsActive { get; set; }
        
    }
}
