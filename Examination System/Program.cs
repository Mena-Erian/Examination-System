using AssignmentExamination_System;
using Examination_System.Exams;
using Examination_System.Questions;

namespace Examination_System
{
    internal class Program
    {
        static void Main()
        {
            Subject subject;
            
            ExamType typeOfExam = Helper.GetFromUserByType<ExamType>(
                "the type of Exam (1 for Practical | 2 for Final)",
                false);
            
            TimeOnly timeOfExam = Helper.GetTimeOnlyByMinutes(
                "the Time For Exam From (30 min to 180 min)",
                false);
            int numberOfQuestions = Helper.GetIntFromUser(
                "the Number of questions", false
                );
            Console.Clear();
            
            /// typeOfQuestion = Helper.GetFromUserByType<ExamType>(
            ///    "the type of Exam (1 for Practical | 2 for Final)",
            ///    false);
            /// 
            /// 
            /// switch (typeOfExam)
            /// {
            ///     case ExamType.Practical:
            /// 
            ///         break;
            ///     case ExamType.Final:
            ///         subject = new Subject(1, "FirstSubject",
            ///       new FinalExam(numberOfQuestions,timeOfExam)
            ///          );
            ///         break;
            ///     default:
            ///         break;
            /// }



        }
    }
}
