using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    internal class FinalExam : Exam
    {
        #region Constructros
        public FinalExam(int numberOfQuestions, TimeOnly timeOfExam, List<Question> questionList, Subject subject) : base(numberOfQuestions, timeOfExam, questionList, subject)
        {
        }
        public FinalExam(Subject subject) : base(subject)
        {
            
        }
        #endregion

        #region Properties
        public decimal Grade { get; private set; }
        public override List<Question> QuestionList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        #region Methods
        private decimal CalcGrade()
        {
            throw new NotImplementedException();
        }
        public override void showAnswers()
        {
            throw new NotImplementedException();
        }
        public override string ToString() => $"{base.ToString()}, Grade: {Grade}";
        #endregion
    }
}
