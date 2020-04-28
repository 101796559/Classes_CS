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

            // Compares the height of each student in the "people" list and prints the results.
            new Program().CompareStudentHeights(people);

            /* 
            "Enrolls" each student in one of the above subjects, gives them a grade between 50 & 100,
            unenrolls William from whatever they're enrolled in,
            checks each student's enrolled subjects.
            This woud be done less randomly by an actual user, I suppose.
            */
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
                    int x = i;
                    while (x > 0) {
                        System.Console.WriteLine(person.GetHeightDifference(people[i-x]));
                        x--;
                    }
                }
            }
        }

        public void UpdateGrades(List<Person> students) {
            foreach (Person student in students) {
                Subject subject;
                var check = new Random().Next(0,10);
                if (check > 7) {
                    subject = Program.physics;
                }
                else if (check > 4) {
                    subject = Program.math;
                }
                else {
                    subject = Program.compSci;
                }
                System.Console.WriteLine(student.GetFullName());
                student.AddSubject(subject);
                student.AddGrades(subject, new Random().Next(50,100));
                students[0].RemoveSubject(subject);
                System.Console.WriteLine(student.GetSubjects());
            }
        }
    }
}
