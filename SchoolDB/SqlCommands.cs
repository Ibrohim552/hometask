namespace SchoolDB;

public class SqlCommands
{
    public const string connectionString = "Server=localhost;Port=5432;Database=School_DB;User Id=postgres;Password=12345;";

    public const string InsertStudent =
        "insert into Student(Id,name, surname, age, grade) values (@Id,@name,@surname,@age,@grade)";
    public const string DeleteStudent = "delete from Student where id=@Id";

    public const string Update =
        "update student set name=@name, surname=@surname, age=@age, grade=@grade where id=@id";

    public const string GetbyId = "select *from student where  id =@id";
    public const string GetStudents = "select * from student";
}
