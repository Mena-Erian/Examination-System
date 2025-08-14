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
        public TrueOrFalseQuestion(string header, string body, decimal mark, List<Answer> answerList, Answer rightAnswer) : base(header, body, mark, answerList, rightAnswer)
        {

        }

        public override List<Answer> AnswerList
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public override Answer RightAnswer
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public override List<Question> GetQuestionsFromUser(ExamType examType)
        {
            throw new NotImplementedException();
        }
    }
}
