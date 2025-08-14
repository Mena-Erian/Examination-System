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
            //base.QuestionList = new List<Question>();

        }
        static PracticalExam()
        {
            AvilableQuestionTypes = [QuestionType.MCQ];
        }
        #endregion

        #region Propeties
        public override List<Question> QuestionList
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Methods
        private protected override List<Question> SetQuestionListFromUser()
        {
            throw new NotImplementedException();
        }
        public override void showAnswers()
        {
            throw new NotImplementedException();
        }

        public override List<Question> GetQuestionsFromUser(ExamType examType)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
