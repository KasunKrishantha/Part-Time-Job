using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class JobApply
    {
        public int ID { get; set; }
        public int JobID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ApplyDate { get; set; }


        
        public virtual Employee Employee { get; set; }
        public virtual Job Job { get; set; }


    }
}