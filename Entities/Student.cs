using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAppNH.Entities
{
    public class Student
    {
        public virtual int ID { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual StudentAcademicStanding AcademicStanding { get; set; }
        public virtual Location Address { get; set; }
        public virtual Faculty Faculty { get; set; }


      
    }

    public class Location
    {
        public virtual string Street { get; set; }
        public virtual string City { get; set; }
        public virtual string Province { get; set; }
        public virtual string Country { get; set; }
    }

    public enum StudentAcademicStanding
    {
        Excellent,
        Good,
        Fair,
        Poor,
        Terrible
    }
}
