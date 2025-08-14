using AssignmentExamination_System;
using Examination_System.Exams;
using Examination_System.Helpers;
using Examination_System.Questions;

namespace Examination_System
{
    internal class Program
    {
        static void Main()
        {
            Subject subject = new Subject(1, "OOP Exam");

            Exam exam = subject.CreateExam();
            
            Console.Clear();
            if (Helper.GetBoolFromUserByChar(
                "Do you Want to Start Exam (Y | N): ",
                true))
            {
                exam.StartExam();
            }



        }
    }
}
