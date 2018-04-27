using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class Employee
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Birthday { get; set; }

        public Gender? Gender { get; set; }

        public string Payment { get; set; }
        public string Qualification { get; set; }
        public string YourTrip { get; set; }

        //public virtual User User { get; set; }
        public virtual ICollection<JobApply> JobApplies { get; set; }


    }
}