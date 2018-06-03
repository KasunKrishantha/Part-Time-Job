using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PartTimeJob.Models
{
    public class YourTrip
    {
        public int ID { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeID { get; set; }

        [ForeignKey("Job")]
        public int JobID { get; set; }

        public virtual Job Job { get; set; }
        public virtual Employee Employee { get; set; }
    }
}