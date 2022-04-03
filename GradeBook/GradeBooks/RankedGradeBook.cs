using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    internal class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("You need at least 5 students");
            var a = (int)Math.Ceiling(Students.Count * 0.2);
            var gradeList = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (gradeList[a - 1] <= averageGrade)
                return 'A';
            else if (gradeList[(a * 2) - 1] <= averageGrade)
                return 'B';
            else if (gradeList[(a * 3) - 1] <= averageGrade)
                return 'C';
            else if (gradeList[(a * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}