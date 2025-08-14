using Examination_System.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    internal class TrueOrFalseQuestion : Question
    {
        #region Constructros
        public TrueOrFalseQuestion(string header, string body, decimal mark, List<Answer> answerList, Answer rightAnswer) : base(header, body, mark, answerList, rightAnswer)
        {

        }
        public TrueOrFalseQuestion() { }
        #endregion
        public override List<Answer> AnswerList
        {
            get => throw new NotImplementedException();
        }
        public override Answer RightAnswer
        {
            get => throw new NotImplementedException();
        }

        public override List<Answer> SetAnswersFromUser()
        {
            throw new NotImplementedException();
        }

        public override Answer SetRightAnswerFromUser(List<Answer> answersList)
        {
            throw new NotImplementedException();
        }
    }
}
