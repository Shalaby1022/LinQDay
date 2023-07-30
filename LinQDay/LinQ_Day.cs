using System;
using System.Collections.Generic;
using System.Linq;

class LinQDay
{

    public class Subject
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Subject[] Subjects { get; set; }
    }
    static void Main()
    {

        #region task1
 
        List<int> numbers = new List<int> { 2, 4, 6, 7, 1, 4, 2, 9, 1 };


        var Nonrepeatedsorted = numbers.Distinct().OrderBy(n => n);

        Console.WriteLine("Numbers without any repeated data and sorted:");
        foreach (var numero in Nonrepeatedsorted)
        {
            Console.WriteLine(numero);
        }

        // Query using first query result and show its numbers and beside it its multiplication
        var Multiplication = Nonrepeatedsorted.Select(n => $"number = {n} , multiply  = {n * n}");
        Console.WriteLine();
        Console.WriteLine("Numbers and their multiplications:");
        foreach (var result in Multiplication)
        {
            Console.WriteLine(result);
        }

        Console.WriteLine("---------------------------------------------------");

        #endregion

        #region Task2


        string[] names = { "tom", "dick", "harry", "mary", "jay" };

        // query to select names with length equal to 3
        var namesWithLength3 = names.Where(name => name.Length == 3);

        Console.WriteLine("Names with length equal to 3:");
        foreach (var name in namesWithLength3)
        {
            Console.WriteLine(name);
        }

        // Selecting names that contain "a" letter (capital or small) and sort them by length
        var namesWithA = names.Where(name => name.ToLower().Contains("a")).OrderBy(name => name.Length);
        Console.WriteLine();
        Console.WriteLine("Names containing 'a' letter (capital or small) and sorted by length:");
        foreach (var name in namesWithA)
        {
            Console.WriteLine(name);
        }

        Console.WriteLine("------------------------------------------------------");

        #endregion

        #region Third Task 
        // Create a list of students
        List<Student> students = new List<Student>
        {
            new Student {ID = 1, FirstName = "Ali", LastName = "Mohammed",
                Subjects = new Subject[]{new Subject {Code = 22, Name = "EF"}, new Subject {Code = 33, Name = "UML" } } },

            new Student {ID = 2, FirstName = "Mona", LastName = "Gala",
                Subjects = new Subject[]{new Subject {Code = 22, Name = "EF"}, new Subject {Code = 34, Name = "XML" }, new Subject { Code = 25, Name = "JS" } } },

            new Student {ID = 3, FirstName = "Yara", LastName = "Yosuf",
                Subjects = new Subject[]{new Subject {Code = 22, Name = "EF"}, new Subject { Code = 25, Name = "JS" } } },

            new Student {ID = 1, FirstName = "Ali", LastName = "Ali",
                Subjects = new Subject[]{new Subject {Code = 33, Name = "UML" } } }
        };

        //Display full name and number of subjects for each student
        var studentsFullNameAndSubjectsCount = students.Select(s => new
        {
            FullName = $"{s.FirstName} {s.LastName}",
            SubjectsCount = s.Subjects.Length
        });

        Console.WriteLine("Full name and number of subjects for each student:");
        foreach (var student in studentsFullNameAndSubjectsCount)
        {
            Console.WriteLine($"{student.FullName} - Subjects Count: {student.SubjectsCount}");
        }

        Console.WriteLine();
        //  Order the elements in the list by FirstName descending, then by LastName ascending
        var orderedFirstAndLastNames = students
            .OrderByDescending(s => s.FirstName)
            .ThenBy(s => s.LastName)
            .Select(s => new { s.FirstName, s.LastName });

        Console.WriteLine("First names and last names in the list after ordering:");
        foreach (var name in orderedFirstAndLastNames)
        {
            Console.WriteLine($"{name.FirstName} {name.LastName}");
        }
    }
    #endregion
}


