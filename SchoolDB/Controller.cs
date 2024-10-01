using Microsoft.AspNetCore.Mvc;
using SchoolDB.Models;
using SchoolDB.Services;

namespace SchoolDB;

[Route("/api/students/")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudent _studentServices;

 
    public StudentController(IStudent studentServices)
    {
        _studentServices = studentServices;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateStudent([FromBody] Student student, [FromServices] IStudent studentservices)
    {
        bool result = await studentservices.Createstudent(student);
        if (result)
        {
            return Ok();
        }
        return BadRequest("Ошибка при создании студента");
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudents()
    {
        IEnumerable<Student> students = await _studentServices.GetStudents();
        return Ok(students);
    }

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetStudentById(int id)
    {
        var student = await _studentServices.GetStudentById(id);
        if (student is not null)
        {
            return Ok(student);
        }
        return NotFound("Студент не найден");
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateStudent([FromBody] Student student, [FromServices] IStudent studentservices)
    {
        var result = await studentservices.UpdateStudent(student);
        if (result)
        {
            return Ok();
        }
        return BadRequest("Ошибка при изменении студента");
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteStudent(int id)
    {
        var result = await _studentServices.DeleteStudent(id);
        if (result)
        {
            return Ok();
        }
        return NotFound("Студент не найден");
    }
    
}