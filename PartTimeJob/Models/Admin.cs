using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public enum Grade {
        A,B,C,D
    }
    public enum Gender
    {
        Male, Female
    }
    public class Admin
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

        public Grade? Grade { get; set; }

        //public virtual User User { get; set; }
        public virtual ICollection<PostApproval> PostApprovals { get; set; }

    }
}