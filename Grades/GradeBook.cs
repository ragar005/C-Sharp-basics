using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook: GradeTracker
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public override void AddGrades(float grade)
        {
            grades.Add(grade);
        }

        public override GradeStatistics ComputeStatistics()
        {
            float sum = 0;
            GradeStatistics stats = new GradeStatistics();
            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }
            stats.AverageGrade = sum/grades.Count;
            return stats;
        }



        public override void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        protected List<float> grades;


    }
}
