using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public enum Rate
    {
        A,B,C,D,E,
    }
    public class PostView
    {
        public int ID { get; set; }
        public Rate? Rate { get; set; }

        //public int EmployeeID { get; set; }
        public int EmployerID { get; set; }
        //public int AdminID { get; set; }
        public int JobID { get; set; }

        //public virtual User User { get; set; }
        //public virtual Employee Employee { get; set; }
        //public virtual Employer Employer { get; set; }
        //public virtual Job Job { get; set; }


    }
}