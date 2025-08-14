using AssignmentExamination_System;
using Examination_System.Helpers;
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
        static FinalExam()
        {
            AvilableQuestionTypes = [QuestionType.MCQ, QuestionType.TrueOrFalse];
        }
        #endregion

        #region Properties
        public decimal Grade { get; private set; }
        public override List<Question> QuestionList
        {
            get { return questionsList; }
        }
        #endregion

        #region Methods
        private protected override List<Question> SetQuestionListFromUser()
        {
            List<Question> questions = new List<Question>(NumberOfQuestions);

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Clear();
                QuestionType questionsType = GetQuestionsTypeFromUser();
                Console.Clear();

                switch (questionsType)
                {
                    case QuestionType.MCQ:
                        Console.WriteLine("MCQ Question");
                        questions.Add(new McqQuestion());
                        break;
                    case QuestionType.TrueOrFalse:
                        Console.WriteLine("True | False Question");
                        questions.Add(new TrueOrFalseQuestion());
                        break;
                }
            }

            return questions;
        }
        private static QuestionType GetQuestionsTypeFromUser()
        {
            return Helper.GetFromUserByType<QuestionType>(
               "the Type of Question (1 for MCQ | 2 For True | False)",
               false);
        }
        private protected override void ShowExamQustions(string E)
        {
            base.ShowExamQustions("MCQ Question");
        }
        public override void showResultOfAnswers(List<Answer> userAnswers, out string gradetext, out decimal grade)
        {
            base.showResultOfAnswers(userAnswers, out gradetext, out grade);
            Console.WriteLine(gradetext);
            this.Grade = grade;
        }
        public override string ToString() => $"{base.ToString()}, Grade: {Grade}";
        #endregion
    }
}
