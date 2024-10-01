using SchoolDB.Models;

namespace SchoolDB.Services;

public interface IStudent
{
    Task<bool> Createstudent(Student student);
    Task<bool>  UpdateStudent(Student student);
    Task<bool>  DeleteStudent(int id);
    Task<IEnumerable<Student>> GetStudents();
    Task<Student> GetStudentById(int id);
}