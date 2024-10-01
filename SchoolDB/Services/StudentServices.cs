using SchoolDB.Models;
using Dapper;
using  Npgsql;
namespace SchoolDB.Services;
public class StudentServices : IStudent
{
    public async Task<bool> Createstudent(Student student)
    {
        using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.InsertStudent, student) > 0;
        }
    }

    public async Task<bool> UpdateStudent(Student student)
    {
        using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.Update, student) > 0;
        }
    }

    public async Task<bool> DeleteStudent(int id)
    {
        using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.ExecuteAsync(SqlCommands.DeleteStudent, new { Id = id }) > 0;
        }
    }

    public async Task<IEnumerable<Student>> GetStudents()
    {
        using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryAsync<Student>(SqlCommands.GetStudents);
        }
    }

    public async Task<Student> GetStudentById(int id)
    {
        using (var connection = new NpgsqlConnection(SqlCommands.connectionString))
        {
            await connection.OpenAsync();
            return await connection.QueryFirstOrDefaultAsync<Student>(SqlCommands.GetbyId, new { Id = id });
        }
    }
}
