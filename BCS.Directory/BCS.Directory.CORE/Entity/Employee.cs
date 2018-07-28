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

        public int CivilStatus { get; set; }

        public int Gender { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string LanguagesSpoken { get; set; }

        public int PhoneNumber { get; set; }

        public int UserType { get; set; }

        public bool IsActive { get; set; }

        public int Department { get; set; }

        public DateTime HireDate { get; set; }

    }
}
