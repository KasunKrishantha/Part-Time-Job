using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartTimeJob.Models
{
    public enum GenderType {
        Male,Female,Both
    }

    public enum EmployeementType {
        FullTime,PartTime
    }

    public enum District {
        Ampara,Anuradhapura,Badulla,Batticaloa,Colombo,Galle,Gampaha,Hambantota,Jaffna,Kalutara,
        Kandy,Kegalle,Kilinochchi,Kurunegala,Mannar,Matale,Matara,Moneragala,Mullaitivu,
        Nuwara_Eliya,Polonnaruwa,Puttalam,Ratnapura,Trincomalee,Vavuniya,
    }

    public enum Status
    {
        NotApproval, Approval
    }
    public class Job
    {
        public int ID { get; set; }

        [ForeignKey("Employer")]
        public int EmployerID { get; set; }

        public string Name { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Description { get; set; }
        public string AgeRange { get; set; }
        public string ContactNumber { get; set; }
        public GenderType? GenderType { get; set; }
        public EmployeementType? EmployeementType { get; set; }
        public string Qualification { get; set; }
        public int NumberOfEmp { get; set; }
        public District? District { get; set; }
        public string JobRole { get; set; }
        public string Education { get; set; }
        public string Requirement { get; set; }
        //public DateTime Date { get; set; }
        public Status? Status { get; set; }

        //public virtual ICollection<PostView> PostViews { get; set; }
        public virtual ICollection<PostApproval> PostApprovals { get; set; }
        public virtual ICollection<JobApply> JobApplies{ get; set; }
        public virtual Employer Employer { get; set; }

        //public virtual ICollection<Post> Posts { get; set; }


    }
}