using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class Payment
    {
        public int ID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [ForeignKey("Employer")]
        public int EmployerID { get; set; }

        //[ForeignKey("Job")]
        //public int JobID { get; set; }

        public string Price { get; set; }

        public DateTime Date { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employer Employer { get; set; }
        //public virtual Job Job { get; set; }
    }
}