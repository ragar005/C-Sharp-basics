using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {
        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
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

        public void AddGrades(float grade)
        {
            grades.Add(grade);
        }


        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name Cannot be Null");
                }

                //    if (_name != value)
                //{
                //    NameChangedEventArgs args = new NameChangedEventArgs();
                //    args.ExistingName = _name;
                //    args.NewName = value;
                //    //Delegate 
                //    NameChanged(this, args);
                //}
                _name = value;


            }
        }



        public event NameChangedDelegate NameChanged;

        public void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }



        private string _name;
        private List<float> grades;
    }
}
