using Demo_API_NET5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo_API_NET5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public static List<Student> studentList = new List<Student>();
        [HttpGet]
        public IActionResult GetAll()
        {
            //Console.WriteLine(studentList);
            return Ok(studentList);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(string id)
        {
            try
            {
                var getStudent = studentList.FirstOrDefault(a => a.studentId == Guid.Parse(id));
                if (getStudent == null)
                {
                    return NotFound($"Can not found Customer with ID {id}");
                }
                return Ok(getStudent);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            var newStudent = new Student
            {
                studentId = Guid.NewGuid(),
                studentName = student.studentName
            };
            studentList.Add(newStudent);
            //Console.WriteLine(studentList);
            return Ok(
                new
                {
                    Success = true,
                    Data = studentList
                }
                );
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateStudent(Student student, string Id)
        {
            try
            {
                var getStudent = studentList.FirstOrDefault(st => st.studentId == Guid.Parse(Id));
                if (getStudent == null)
                {
                    return NotFound();
                }
                else
                {
                    if(Id != student.studentId.ToString())
                    {
                        return BadRequest();
                    }
                    getStudent.studentName = student.studentName;
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteStudent(string Id)
        {
            try
            {
                var getStudent = studentList.FirstOrDefault(st => st.studentId == Guid.Parse(Id));
                if (getStudent == null)
                {
                    return NotFound();
                }
                else
                {
                    studentList.Remove(getStudent);
                }
                return Ok(studentList);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
