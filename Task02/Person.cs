using System;
using System.Collections.Generic;

namespace Task02
{
    public class Person
    {
        public int id;
        public string firstname;
        public string lastname;
        public DateTime birthDate;
        public int height;
        public List<Subject> subjects;
        public List<Grade> grades;

        public Person(string first, string last, DateTime birthDate, int height) {
            this.id = new Random().Next(1000,9999);
            this.firstname = first;
            this.lastname = last;
            this.birthDate = birthDate;
            this.height = height;
            this.subjects = new List<Subject>();
            this.grades = new List<Grade>();
        }

        public string GetFullName() {
            return $"{this.firstname} {this.lastname}";
        }

        public string GetHeightDifference(Person other) {
            string message;
            int difference = this.height - other.height;
            
            if (difference > 0) {
                message = $"{this.firstname} is taller than {other.firstname} by {difference}cm";
            }
            else if (difference < 0) {
                difference *= -1;
                message = $"{this.firstname} is shorter than {other.firstname} by {difference}cm";
            }
            else {
                message = $"{this.firstname} and {other.firstname} are the same height.";
            }
            return message;
        }

        public void AddSubject(Subject subject) {
            this.subjects.Add(subject);
        }

        public void RemoveSubject(Subject subject) {
            this.subjects.Remove(subject);
        }

        public string GetSubjects() {
            string message = "";
            foreach(Subject subject in subjects) {
                string grade = GetGrades(subject) == "" ? "N/A" : GetGrades(subject);
                message += $"Subject: {subject.name}, Year: {subject.year}, Grade: {grade}\n";
            }
            return message;
        }

        public void AddGrades(Subject subject, int grade) {
            this.grades.Add(new Grade(subject, grade));
        }

        public string GetGrades(Subject subject) {
            string message = "";
            foreach (Grade grade in this.grades) {
                if (grade.subject == subject) {
                    message += grade.grade.ToString();
                }
            }
            
            return message;
        }
        public string GetGrades() {
            string message = "";
            foreach (Grade grade in this.grades) {
                message += $"{grade.subject.name} {grade.grade}\n";
            }
            
            return message;
        }
    }
}