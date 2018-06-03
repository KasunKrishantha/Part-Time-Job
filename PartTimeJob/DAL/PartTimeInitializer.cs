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
            new Employer{FirstName="Sameera",LastName="Nandathilaka",UserName="user1",Password="12345",Email="sameeranandathilaka@gmail.com",PhoneNumber="0711421530",Birthday=DateTime.Parse("1993-07-03"),Gender=Gender.Male,Position="Software Enigineer",Country="Sri lanka"},

            };
            employers.ForEach(s => context.Employers.Add(s));
            context.SaveChanges();

            var employees = new List<Employee>
            {
            new Employee{FirstName="Sameera",LastName="Nandathilaka",UserName="users",Password="12345",Email="thilinachamikashtc@gmail.com",PhoneNumber="0778952135",Birthday=DateTime.Parse("1994-01-23"),Gender=Gender.Male,Qualification="O/L,A/L"},
            new Employee{FirstName="Nuwan",LastName="Chathuranga",UserName="nuwan",Password="nuwan",Email="nuwanchathuranga@gmail.com",PhoneNumber="0778952135",Birthday=DateTime.Parse("1994-05-24"),Gender=Gender.Male,Qualification="O/L,A/L"},

            };
            employees.ForEach(s => context.Employees.Add(s));
            context.SaveChanges();

            var admins = new List<Admin>
            {
            new Admin{FirstName="Thilina",LastName="Chamika",UserName="2015CS090",Password="2015/Cs/091",Email="thilinachamikashtc@gmail.com",PhoneNumber="0778952135",Birthday=DateTime.Parse("1994-01-23"),Gender=Gender.Male,Grade=Grade.A},
            new Admin{FirstName="Sisira",LastName="Jayawardene",UserName="2015CS100",Password="2015/Cs/100",Email="sisirajayawardene@gmail.com",PhoneNumber="0715648252",Birthday=DateTime.Parse("1994-05-15"),Gender=Gender.Male,Grade=Grade.B},


            };
            admins.ForEach(s => context.Admins.Add(s));
            context.SaveChanges();



            var jobs = new List<Job>
            {
            new Job{EmployerID=1,Catagory="IT",Title="Former Software Engineer",Position="QA",Location="Colombo 03",Salary="Rs 90,000.00",Description="5 Years Exeperience",AgeRange="Up to 20",ContactNumber="0715916092",GenderType=GenderType.Male,EmployeementType=EmployeementType.FullTime,Qualification="Required Degree in Computer Science",NumberOfEmp=5,District=District.Colombo,JobRole="8 Hours",Education="Degree Level",Requirement="C,C++,Java",Date=DateTime.Parse("2018-06-12"),Status=Status.Approval},
            new Job{EmployerID=2,Catagory="Clean",Title="Office Cleaner",Position="Office",Location="Colombo 10",Salary="Rs 20,000.00",Description="We don't need Exeperience",AgeRange="Up to 18",ContactNumber="0778952135",GenderType=GenderType.Both,EmployeementType=EmployeementType.FullTime,Qualification="Non Required",NumberOfEmp=20,District=District.Colombo,JobRole="8 Hours",Education="Non",Requirement="Non",Date=DateTime.Parse("2018-06-30"),Status=Status.Approval},


            };
            jobs.ForEach(s => context.Jobs.Add(s));
            context.SaveChanges();

            var postapprovals = new List<PostApproval>
            {
                new PostApproval{ AdminID =1,JobID=1,ApprovalDate=DateTime.Parse("2018-04-21")},
                new PostApproval{ AdminID =2,JobID=2,ApprovalDate=DateTime.Parse("2018-05-14")}
            };
            postapprovals.ForEach(s => context.PostApprovals.Add(s));
            context.SaveChanges();

            var jobapplys = new List<JobApply>
            {
                new JobApply{ JobID =1,EmployeeID=1,ApplyDate=DateTime.Parse("2018-04-22")},
                new JobApply{ JobID =2,EmployeeID=2,ApplyDate=DateTime.Parse("2018-05-20")},

            };
            jobapplys.ForEach(s => context.JobApplies.Add(s));
            context.SaveChanges();

            var postviews = new List<PostView>
            {
                new PostView{ JobID =1,EmployeeID=1,Rate=Rate.A,Comment="Geade Job Guys"},
                new PostView{ JobID =1,EmployeeID=1,Rate=Rate.B,Comment="Ela Job Guys,Well Payment for us"},
                new PostView{ JobID =2,EmployeeID=2,Rate=Rate.E,Comment="Bad Job Guys"}
            };
            postviews.ForEach(s => context.PostViews.Add(s));
            context.SaveChanges();

            var payments = new List<Payment>
            {
                new Payment{EmployeeID=1,EmployerID=1,Price="15,000",Date=DateTime.Parse("2015-06-08") },
                new Payment{EmployeeID=2,EmployerID=2,Price="10,000",Date=DateTime.Parse("2015-06-20") }
            };
            payments.ForEach(s => context.Payments.Add(s));
            context.SaveChanges();

            var yourtrip = new List<YourTrip>
            {
                new YourTrip{ EmployeeID=1,JobID=1},
                new YourTrip{ EmployeeID=2,JobID=2}
            };
            yourtrip.ForEach(s => context.YourTrips.Add(s));
            context.SaveChanges();


        }

    }
}