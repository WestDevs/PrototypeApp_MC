using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEST.Api.Data;
using WEST.Api.DTOs;
using WEST.Api.Entities;
using WEST.Api.Interfaces;


namespace WEST.Api.Controllers
{
    public class CourseController : BaseApiController
    {
        private readonly DataContext _context;
        public CourseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync(); 
        }

        [HttpPost("register")]
        public async Task<ActionResult<CourseDto>> RegisterCourse(CourseDto courseDto)
        {
            var course = new Course
            {
                Name = courseDto.Name,
                IconPath = courseDto.IconPath
            };

            _context.Courses.Add(course);

            await _context.SaveChangesAsync();

            return new CourseDto 
            {
                Id = course.Id,
                Name = course.Name,
                IconPath = course.IconPath
            };
        }

    }
}