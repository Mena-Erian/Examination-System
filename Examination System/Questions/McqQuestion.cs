using AssignmentExamination_System;
using Examination_System.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    internal class McqQuestion : Question
    {
        #region Constructors
        public McqQuestion() { }
        public McqQuestion(string header, string body, decimal mark, List<Answer> answerList, Answer rightAnswer) : base(header, body, mark, answerList, rightAnswer)
        {
        }
        #endregion

        #region Properteis
        internal int CountOfAnswers { get; } = 3;
        public override List<Answer> AnswerList
        {
            get => throw new NotImplementedException();
        }
        public override Answer RightAnswer
        {
            get => throw new NotImplementedException();
        }
        #endregion

        #region Methods
        public override List<Answer> SetAnswersFromUser()
        {
            List<Answer> answers = new List<Answer>(CountOfAnswers);

            Console.WriteLine("Choices Of Questions:");
            for (int i = 0; i < CountOfAnswers; i++)
            {
                string textAnswer = Helper.GetStringFromUser(
                    $"Choice Number ({i + 1})");
                answers.Add(new Answer(i + 1, textAnswer));
            }
            return answers;
        }

        public override Answer SetRightAnswerFromUser(List<Answer> answersList)
        {
            int rightAnswerid;
            do
            {
                rightAnswerid = Helper.GetIntFromUser("the right answer id", false);

            } while (!(rightAnswerid > 0 && CountOfAnswers >= rightAnswerid));

            Answer rightAnswer = answersList[rightAnswerid - 1];
            return rightAnswer;
        }
        #endregion
    }

}
