using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapping
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? NullableAge1 { get; set; }
        public int? NullableAge2 { get; set; }
        public int? NullableAge3 { get; set; }
        public int? NullableAge4 { get; set; }
        public double? Weight { get; set; }
        public double Height { get; set; }
        public DateTime BirthDate { get; set; }
        public bool CarOwner { get; set; }
        public Gender Gender { get; set; }
    }
}
