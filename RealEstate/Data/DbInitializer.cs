using RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Data
{
    public class DbInitializer 
    {
        public static void Initialize(RealEstateContext context)
        {
            context.Database.EnsureCreated();
           
            context.SaveChanges();
            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }
            var users = new User[]
            {
            new User{Login="Carson",Email="Alexander",Password="pass"},
            new User{Login="Meredith",Email="Alonso",Password="pass"},
            new User{Login="Arturo",Email="Anand",Password="pass"},
            new User{Login="Gytis",Email="Barzdukas",Password="pass"},
            new User{Login="Yan",Email="Li",Password="pass"},
            };
                foreach (User s in users)
                {
                    context.Users.Add(s);
                }
                context.SaveChanges();
                context.Cities.Add(new City { Name = "test", Area = "test", Region = "test" });
            context.Advertisements.Add(new Advertisement { UserID = 1, CreationDate = DateTime.Now,Latitude= 53.902496, Longitude= 27.561481, AirConditioner =true,Animals=true,Apartment=1,Balcony=true,City="Минск",Description="Квартира в отличном состоянии",TotalArea=100,ConstructionYear=2017,Cost=100,Elevator=true,Floor=11 });
            context.SaveChanges();

            //var courses = new Course[]
            //{
            //new Course{CourseID=1050,Title="Chemistry",Credits=3},
            //new Course{CourseID=4022,Title="Microeconomics",Credits=3},
            //new Course{CourseID=4041,Title="Macroeconomics",Credits=3},
            //new Course{CourseID=1045,Title="Calculus",Credits=4},
            //new Course{CourseID=3141,Title="Trigonometry",Credits=4},
            //new Course{CourseID=2021,Title="Composition",Credits=3},
            //new Course{CourseID=2042,Title="Literature",Credits=4}
            //};
            //foreach (Course c in courses)
            //{
            //    context.Courses.Add(c);
            //}
            //context.SaveChanges();
            //var enrollments = new Enrollment[]
            //{
            //new Enrollment{UserID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{UserID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{UserID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{UserID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{UserID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{UserID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{UserID=3,CourseID=1050},
            //new Enrollment{UserID=4,CourseID=1050},
            //new Enrollment{UserID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{UserID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{UserID=6,CourseID=1045},
            //new Enrollment{UserID=7,CourseID=3141,Grade=Grade.A},
            //};
            //foreach (Enrollment e in enrollments)
            //{
            //    context.Enrollments.Add(e);
            //}
            //context.SaveChanges();
        }

    }
}
