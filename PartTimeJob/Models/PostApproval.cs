using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public class PostApproval
    {
        public int ID { get; set; }

        [ForeignKey("Admin")]
        public int AdminID { get; set; }

        [ForeignKey("Job")]
        public int JobID { get; set; }

        public DateTime ApprovalDate { get; set; }

        public virtual Admin Admin { get; set; }
        public virtual Job Job { get; set; }


    }
}