using System;
using System.Collections.Generic;
using Aplikacja_konsolowa_języka_C_;
using Microsoft.Data.SqlClient;
class Program
{
    public static void Main()
    {
        string connectionString = "Server=USER\\SQLEXPRESS; Database = Studenci_72228; Trusted_Connection = True; TrustServerCertificate=True";
        try
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connection Opened Successfully");
            //Zadanie 4
            DisplayStudentInfo(connection);
            //Zadanie 5
            DisplayStudentOne(connection, 1);
            //Zadanie 6
            AllStudentsWithGrades(connection);
            //Zadanie 7
            AddNewStudent(connection, new Student { Imie = "Anna", Nazwisko = "Kowalska" });
            //Zadanie 8
            AddGradeToStudent(connection, 1, new Ocena { Wartosc = 4.5, Przedmiot = "Biologia" });
            //Zadanie 9
            DeleteGradeforGeography(connection);
            //Zadanie 10
            UpdateNewOcena(connection, 1, 5.0);
        }
        catch (Exception e)
        {
            Console.WriteLine("An error occurred: " + e.Message);
        }
    }
    public static void DisplayStudentInfo(SqlConnection connection)
    {
        string sql = "SELECT Student_Id, Imie, Nazwisko FROM student";
        using SqlCommand sqlCommand = new SqlCommand(sql, connection);
        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            int studentId = reader.GetInt32(0);
            string imie = reader.GetString(1);
            string nazwisko = reader.GetString(2);
            Console.WriteLine($"ID: {studentId}, Imie: {imie}, Nazwisko: {nazwisko}");
        }
    }
    public static void DisplayStudentOne(SqlConnection connection, int id)
    {
        string sql = "SELECT Imie, Nazwisko FROM student WHERE student_id = @id";
        using SqlCommand sqlCommand = new SqlCommand(sql, connection);
        sqlCommand.Parameters.AddWithValue("@id", id);
        using SqlDataReader reader = sqlCommand.ExecuteReader();
        while (reader.Read())
        {
            string imie = reader.GetString(0);
            string nazwisko = reader.GetString(1);
            Console.WriteLine($"Imie: {imie}, Nazwisko: {nazwisko}");
        }
    }
    public static List<Student> DisplayStudentGrades(SqlConnection connection)
    {
        var students = new Dictionary<int, Student>();
        string sql = "SELECT s.student_id, s.imie, s.nazwisko, o.ocena_id, o.wartosc,o.przedmiot FROM student s LEFT JOIN ocena o ON s.student_id = o.student_id";


        using SqlCommand command = new SqlCommand(sql, connection);
        using SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            if (!students.ContainsKey(id))
            {
                students[id] = new Student
                {
                    StudentId = id,
                    Imie = reader.GetString(1),
                    Nazwisko = reader.GetString(2)
                };
            }

            if (!reader.IsDBNull(3))
            {
                students[id].Oceny.Add(new Ocena
                {
                    OcenaId = reader.GetInt32(3),
                    Wartosc = reader.GetDouble(4),
                    Przedmiot = reader.GetString(5),
                    StudentId = id
                });
            }
        }

        return students.Values.ToList();
    }
    public static void AllStudentsWithGrades(SqlConnection connection)
    {
        var students = DisplayStudentGrades(connection);
        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.StudentId}, Imie: {student.Imie}, Nazwisko: {student.Nazwisko}");
            foreach (var ocena in student.Oceny)
            {
                Console.WriteLine($"\tOcena ID: {ocena.OcenaId}, Wartosc: {ocena.Wartosc}, Przedmiot: {ocena.Przedmiot}");
            }
        }
    }
    public static void AddNewStudent(SqlConnection connection,Student student)
    {
        string sql = "INSERT INTO student (Imie, Nazwisko) VALUES (@imie, @nazwisko)";
        using SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@imie", student.Imie);
        command.Parameters.AddWithValue("@nazwisko", student.Nazwisko);
        command.ExecuteNonQuery();
    }
    public static void AddGradeToStudent(SqlConnection connection, int studentId, Ocena ocena)
    {
        if (!TrueGrade(ocena.Wartosc))
        {
            throw new ArgumentException("Nieprawidłowa wartość oceny.");
        }
        string sql = "INSERT INTO ocena(wartosc, przedmiot, student_id) VALUES(@w, @p, @s)";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@w", ocena.Wartosc);
        command.Parameters.AddWithValue("@p", ocena.Przedmiot);
        command.Parameters.AddWithValue("@s", studentId);
        command.ExecuteNonQuery();
    }
    public static void DeleteGradeforGeography(SqlConnection connection)
    {
        string sql = "DELETE FROM ocena WHERE przedmiot = 'Geografia'";
        SqlCommand command = new SqlCommand(sql, connection);
        command.ExecuteNonQuery();
    }
    public static void UpdateNewOcena(SqlConnection connection, int ocenaId, double wartosc)
    {
        if (!TrueGrade(wartosc))
        {
            throw new ArgumentException("Nieprawidłowa wartość oceny.");
        }
        string sql = "UPDATE ocena SET wartosc = @w WHERE ocena_id = @id";
        SqlCommand command = new SqlCommand(sql, connection);
        command.Parameters.AddWithValue("@w", wartosc);
        command.Parameters.AddWithValue("@id", ocenaId);
        command.ExecuteNonQuery();
    }
    static bool TrueGrade(double ocena)
    {
        return ocena >= 2.0 && ocena <= 5.0 && ocena!=2.5 && (ocena * 2) % 1 == 0;
    }
}