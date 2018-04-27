using PartTimeJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PartTimeJob.DAL
{
    public class PartTimeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PartTimeContext>
    {
        protected override void Seed(PartTimeContext context)
        {
            var employers = new List<Employer>
            {
            new Employer{FirstName="Thilina",LastName="Chamika",UserName="user",Password="1234",Email="thilinachamikashtc@gmail.com",PhoneNumber="0778952135",Birthday=DateTime.Parse("1994-01-23"),Gender=Gender.Male,Position="Senior Software Enigineer",Country="Sri lanka"},

            };
            employers.ForEach(s => context.Employers.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
            new Employee{FirstName="Sameera",LastName="Nandathilaka",UserName="users",Password="12345",Email="thilinachamikashtc@gmail.com",PhoneNumber="0778952135",Birthday=DateTime.Parse("1994-01-23"),Gender=Gender.Male,Payment="Rs 1,000.00",Qualification="O/L,A/L",YourTrip=""},

            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var admins = new List<Admin>
            {
            new Admin{FirstName="Thilina",LastName="Chamika",UserName="2015CS090",Password="2015/Cs/091",Email="thilinachamikashtc@gmail.com",PhoneNumber="0778952135",Birthday=DateTime.Parse("1994-01-23"),Gender=Gender.Male,Grade=Grade.A},

            };
            admins.ForEach(s => context.Admins.Add(s));
            context.SaveChanges();



            var jobs = new List<Job>
            {
            new Job{EmployerID=1,Name="WSO2",Title="Former Software Engineer",Position="QA",Location="Colombo 03",Salary="Rs 90,000.00",Description="5 Years Exeperience",AgeRange="Up to 20",ContactNumber="0715916092",GenderType=GenderType.Male,EmployeementType=EmployeementType.FullTime,Qualification="Required Degree in Computer Science",NumberOfEmp=5,District=District.Colombo,JobRole="8 Hours",Education="Degree Level",Requirement="C,C++,Java",Status=Status.Approval},

            };
            jobs.ForEach(s => context.Jobs.Add(s));
            context.SaveChanges();

            var postapprovals = new List<PostApproval>
            {
                new PostApproval{ AdminID =1,JobID=1,ApprovalDate=DateTime.Parse("2018-04-21")}
            };
            postapprovals.ForEach(s => context.PostApprovals.Add(s));
            context.SaveChanges();

            var jobapplys = new List<JobApply>
            {
                new JobApply{ JobID =1,EmployeeID=1,ApplyDate=DateTime.Parse("2018-04-22")}
            };
            jobapplys.ForEach(s => context.JobApplies.Add(s));
            context.SaveChanges();

            var postviews = new List<PostView>
            {
                new PostView{ JobID =1,EmployerID=1,Rate=Rate.A}
            };
            postviews.ForEach(s => context.PostViews.Add(s));
            context.SaveChanges();



        }

    }
}