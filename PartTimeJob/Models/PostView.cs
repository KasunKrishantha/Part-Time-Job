using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Job")]
        public int JobID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        public Rate? Rate { get; set; }

        public string Comment { get; set; }


        public virtual Employee Employee { get; set; }
        public virtual Job Job { get; set; }


    }
}