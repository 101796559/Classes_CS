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
                new Person("Test", "User", new DateTime(1980, 08, 08), 182),
            };

            /* 
            For every person in the above list, displays their full name,
            Compares their height to everyone else's,
            Assigns them a random subject,
            Gives them a random grade between 50 & 100 for that subject,
            Removes William's subject,
            Then prints the person's enrolled subjects, the year of that subject, and their grade for that subject.
            */
            new Program().Display(people);
        }

        public void Display(List<Person> people) {
            for (int i = 0; i < people.Count; i++) {
                Person person = people[i]; // So I don't have to write people[i] every time.

                System.Console.WriteLine($"\n{person.GetFullName()}");

                try { // compares current person against every other person, not including themselves.
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

                Subject sub = new Program().UpdateGrades(person);

                // Remove William's only subject as proof the method works.
                if (i == 0) {
                    person.RemoveSubject(sub);
                }

                // Print all the subjects associated with this person.
                System.Console.WriteLine(person.GetSubjects());
            }
        }

        /* 
        "Enrolls" student in a random subject, gives them a grade between 50 & 100.
        */
        public Subject UpdateGrades(Person person) {
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
            person.AddSubject(subject);
            person.AddGrades(subject, new Random().Next(50,100));
            return subject;
        }
    }
}
