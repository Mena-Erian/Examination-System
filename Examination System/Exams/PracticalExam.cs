using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    internal class PracticalExam : Exam
    {
        #region Constructors
        public PracticalExam(int numberOfQuestions, TimeOnly timeOfExam, List<Question> questionList, Subject subject) : base(numberOfQuestions, timeOfExam, questionList, subject)
        {
        }
        public PracticalExam(Subject subject) : base(subject)
        {
        }
        #endregion


        public override List<Question> QuestionList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void showAnswers()
        {
            throw new NotImplementedException();
        }
    }
}
