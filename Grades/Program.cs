using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("hiii Ravi!");

            GradeBook book = new GradeBook();
            book.NameChanged += new NameChangedDelegate(OnNameChanged);
            
            // book.NameChanged = null; //Error because of event. A example to not use delegate

            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2; // No need to use new NameChangedDelegate


            book.Name = "Ravi's Grade Book";
            book.Name = null;
            book.AddGrades(91);
            book.AddGrades(89.5f);
            book.AddGrades(75);

            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult("Grade", stats.LetterGrade);
        }

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        //}

        static void WriteResult(string description, string result)
        {
            Console.WriteLine(description + ":" + result);
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }


        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description +":"+result);
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }
    }
}
