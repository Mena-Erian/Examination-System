using AssignmentExamination_System;
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
            get => this.answersList;
        }
        public override Answer RightAnswer
        {
            get => this.rightAnswer;
        }

        public override List<Answer> SetAnswersFromUser()
         => new List<Answer>(2)
            {
                new Answer(1,"True"),
                new Answer(2,"False")
            };
        public override Answer SetRightAnswerFromUser(List<Answer> answersList)
        {
            int rightAnswerid;
            do
            {
                rightAnswerid = Helper.GetIntFromUser(
                    "the right answer id (1 for true | 2 for false)",
                    false);

            } while (!(rightAnswerid > 0 && 2 >= rightAnswerid));

            Answer rightAnswer = answersList[rightAnswerid - 1];
            return rightAnswer;
        }
    }
}
