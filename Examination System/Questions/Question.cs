using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    abstract class Question
    {
        #region Constructors
        protected Question(string header, string body, decimal mark, List<Answer> answerList, Answer rightAnswer)
        {
            Header = header;
            Body = body;
            Mark = mark;
            AnswerList = answerList;
            RightAnswer = rightAnswer;
        }
        protected Question() { }
        #endregion

        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public decimal Mark { get; set; }
        public abstract List<Answer> AnswerList { get; set; }
        public abstract Answer RightAnswer { get; set; }
        #endregion

        #region Methods

        public override string ToString() =>
            $"Header: {Header}, Body: {Body}, Mark: {Mark}, RightAnswer: {RightAnswer}";
        #endregion

    }
}
