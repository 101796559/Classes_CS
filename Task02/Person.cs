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

        /* 
        Takes a first and last name, date-of-birth, and height. 
        Assigns psuedo-random id between 1000 & 9999 and initialises empty subjects and grades lists.
        ISSUE: No check to ensure id is unique.
        */
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

        /* 
        Compares the heights of two people
        Returns a string statement like "Tom is taller than Harry by 15cm"
        */
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

        // Add or remove a specific subject from the enrolled subjects list.
        public void AddSubject(Subject subject) => this.subjects.Add(subject);
        public void RemoveSubject(Subject subject) => this.subjects.Remove(subject);

        /* 
        Lists all the student's enrolled subjects and their associated grade (if one exists).
        If none, returns a useable message 
        */
        public string GetSubjects() {
            string message = "";
            if (this.subjects.Count > 0) {
                foreach(Subject subject in subjects) {
                    string grade = GetGrades(subject) == "" ? "N/A" : GetGrades(subject);
                    message += $"Subject: {subject.name}, Year: {subject.year}, Grade: {grade}\n";
                }
            }
            else {
                message = $"{this.GetFullName()} is not enrolled in any subjects\n";
            }
            return message;
        }

        // ISSUE: No check to ensure grade is a valid number.
        public void AddGrades(Subject subject, int grade) {
            this.grades.Add(new Grade(subject, grade));
        }

        /* 
        Checks the student's list of enrolled subjects for a specific subject,
        if a match is found its grade is returned as a string.
        */
        public string GetGrades(Subject subject) {
            string message = "";
            foreach (Grade grade in this.grades) {
                if (grade.subject == subject) {
                    message += grade.grade.ToString();
                }
            }
            
            return message;
        }

        /* 
        Probably deprecated by the updated GetSubjects method
        Could still be used if you didn't care about the year of the subject
        */
        public string GetGrades() {
            string message = "";
            foreach (Grade grade in this.grades) {
                message += $"{grade.subject.name} {grade.grade}\n";
            }
            
            return message;
        }

        /*
        I'm just playing around with the idea now.
        A boolean check to see if a student is enrolled in a particular subject.
        */
        public bool IsEnrolled(Subject subject) {
            bool isEnrolled = false;
            foreach (Subject sub in this.subjects) {
                if (sub == subject) {
                    isEnrolled = true;
                }
            }
            return isEnrolled;
        }
    }
}