using System;
using System.Collections.Generic;

namespace Task02
{
    class Program
    {
        static Subject physics = new Subject("Physics", 2014);
        static Subject math = new Subject("Math", 2014);
        static Subject compSci = new Subject("Computer Science", 2018);
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>() {
                new Person("William", "Weir", new DateTime(1997, 12, 20), 187),
                new Person("Yiyun", "Zhan", new DateTime(1995, 08, 26), 172),
                new Person("Sanjay", "Jagannadhan", new DateTime(1994, 02, 15), 190),
            };

            new Program().UpdateGrades(people);
        }

        public void CompareStudentHeights(List<Person> people) {
            for (int i = 0; i < people.Count; i++) {
                Person person = people[i];
                System.Console.WriteLine($"\n{person.GetFullName()}");
                try {
                    int x = 1;
                    while (x < people.Count) {
                        System.Console.WriteLine(person.GetHeightDifference(people[i+x]));
                        x++;
                    }
                }
                catch {
                    try {
                        int x = i;
                        while (x > 0) {
                            System.Console.WriteLine(person.GetHeightDifference(people[i-x]));
                            x--;
                        }
                    }
                    catch {
                        continue;
                    }
                }
            }
        }

        public void UpdateGrades(List<Person> students) {
            foreach (Person student in students) {
                System.Console.WriteLine(student.GetFullName());
                student.AddSubject(Program.physics);
                student.AddGrades(Program.physics, new Random().Next(50,100));
                System.Console.WriteLine(student.GetSubjects());
            }
        }
    }
}
