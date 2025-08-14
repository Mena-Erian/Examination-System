using AssignmentExamination_System;
using Examination_System.Exams;
using Examination_System.Helpers;
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
            this.answersList = answerList;
            this.rightAnswer = rightAnswer;
        }
        protected Question()
        {
            this.Body = Helper.GetStringFromUser("Question Body", true);
            this.Mark = Helper.GetDecimalFromUser("Question Mark", false);
            this.answersList = SetAnswersFromUser();
            this.rightAnswer = SetRightAnswerFromUser(this.answersList);
        }
        #endregion

        #region Fields
        private protected List<Answer> answersList;
        private protected Answer rightAnswer;
        #endregion

        #region Properties
        public string Header { get; set; }
        public string Body { get; set; }
        public decimal Mark { get; set; }
        public abstract List<Answer> AnswerList { get; }
        public abstract Answer RightAnswer { get; }
        #endregion

        #region Methods
        public abstract List<Answer> SetAnswersFromUser();
        public abstract Answer SetRightAnswerFromUser(List<Answer> answersList);
        public override string ToString() =>
            $"Header: {Header}, Body: {Body}, Mark: {Mark}, RightAnswer: {RightAnswer}";
        #endregion
    }
    internal enum QuestionType
    {
        MCQ = 1, TrueOrFalse
    }
}
