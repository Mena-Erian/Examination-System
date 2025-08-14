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

            ExamType examType = Helper.GetFromUserByType<ExamType>(
                "the type of Exam (1 for Practical | 2 for Final)",
                false);

            Exam exam = subject.CreateExam(examType);

            if (Helper.GetBoolFromUserByChar(
                "Do you Want to Start Exam (Y | N)",
                true))
            {
                exam.StartExam();
            }



        }
    }
}
