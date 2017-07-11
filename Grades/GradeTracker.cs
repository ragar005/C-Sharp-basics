using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker
    {
        public abstract void AddGrades(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);

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
        protected string _name;
        public event NameChangedDelegate NameChanged;
    }




}
