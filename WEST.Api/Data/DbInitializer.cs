using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WEST.Api.DTOs;
using WEST.Api.Entities;

namespace WEST.Api.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            if(context.UserTypes.Any()) return;

            var userTypes = new UserType[]
            {
                new UserType { Name = "Admin"},
                new UserType { Name = "Tutor"},
                new UserType { Name = "Learner"},
                new UserType { Name = "Other"}
            };

            foreach (var userType in userTypes)
                context.UserTypes.Add(userType); 
            
            context.SaveChanges();

            var orgs = new Organisation[]
            {
                new Organisation { Name = "WEST" },
                new Organisation { Name = "Tribal" },
                new Organisation { Name = "Others" }
            };

            foreach (var org in orgs)
                context.Organisations.Add(org);
            context.SaveChanges();

            using var hmac = new HMACSHA512(); //will provide hashing algorithm
            var users = new AppUser[]
            {
                new AppUser
                    {  
                        Username = "admin0",
                        Firstname = "Admin0 FN",
                        Lastname = "Admin0 LN",
                        OrganisationId = 1,
                        Birthdate = DateTime.Parse("1990-01-01"),
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")),
                        PasswordSalt = hmac.Key,
                        TypeId = 1                        
                    },
                new AppUser
                    {  
                        Username = "tutor0",
                        Firstname = "Tutor0 FN",
                        Lastname = "Tutor0 LN",
                        OrganisationId = 2,
                        Birthdate = DateTime.Parse("1991-01-01"),
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")),
                        PasswordSalt = hmac.Key,
                        TypeId = 2                        
                    },
                new AppUser
                    {  
                        Username = "learner0",
                        Firstname = "Learner0 FN",
                        Lastname = "Learner0 LN",
                        OrganisationId = 2,
                        Birthdate = DateTime.Parse("2005-01-01"),
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password")),
                        PasswordSalt = hmac.Key,
                        TypeId = 3                        
                    }                
            };
            foreach(var user in users)
                context.Users.Add(user);
            context.SaveChanges();
            
            var learnerUsers =  users.Where(u => u.TypeId == 3);
            var learners = new List<Learner>();
            foreach (var learnerUser in learnerUsers)
            {
                var learner = new Learner { UserId = learnerUser.Id };
                learners.Add(learner);
                context.Learners.Add(learner);             
            }
            context.SaveChanges();

            var courses = new Course[] {
                new Course { Name = "Application of Number 2015" , IconPath = "./assets/esm.png" },
                new Course { Name = "Communication (English) 2015" , IconPath = "./assets/esl.png" },
                new Course { Name = "Communication (Welsh) 2015" , IconPath = "./assets/esw.png" },
                new Course { Name = "Digital Literacy" , IconPath = "./assets/esd.png" },
                new Course { Name = "ESOL" , IconPath = "./assets/esol.png" }
            };
            foreach (var course in courses)
                context.Courses.Add(course);
            context.SaveChanges();

            var groups = new Group[] {
                new Group { Name = "default" }
            };
            foreach (var group in groups)
                context.Groups.Add(group);
            context.SaveChanges();

            var learnerGroups = new LearnerGroup[] 
            {
                new LearnerGroup { 
                    LearnerId = learners.Single(l => l.User.Username == "learner0").LearnerId,
                    GroupId = groups.Single(g => g.Name == "default").Id
                }
            };

            foreach (var learnerGroup in learnerGroups)
                context.LearnerGroup.Add(learnerGroup);
            context.SaveChanges();

            var learnerCourses = new LearnerCourse[] {
                new LearnerCourse {
                    LearnerId = learners.Single(l => l.User.Username == "learner0").LearnerId,
                    CourseId = courses.Single(c => c.Name == "Application of Number 2015").Id
                },
                new LearnerCourse {
                    LearnerId = learners.Single(l => l.User.Username == "learner0").LearnerId,
                    CourseId = courses.Single(c => c.Name == "ESOL").Id
                }
            };

            foreach (var learnerCourse in learnerCourses)
                context.LearnerCourses.Add(learnerCourse);
            context.SaveChanges();
            
        }
    }
}