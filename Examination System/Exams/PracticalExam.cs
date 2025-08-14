using AssignmentExamination_System;
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
        public PracticalExam(Subject subject) : base(subject) { }
        static PracticalExam()
        {
            AvilableQuestionTypes = [QuestionType.MCQ];
        }
        #endregion

        #region Propeties
        public override List<Question> QuestionList => this.questionsList;
        #endregion

        #region Methods
        private protected override List<Question> SetQuestionListFromUser()
        {
            List<Question> questions = new List<Question>(NumberOfQuestions);

            for (int i = 0; i < NumberOfQuestions; i++)
            {
                Console.Clear();

                Console.WriteLine("MCQ Question");
                questions.Add(new McqQuestion());
            }

            return questions;
        }
        public override void showResultOfAnswers(List<Answer> userAnswers, out string gradeText, out decimal grade)
        {
            base.showResultOfAnswers(userAnswers, out gradeText, out grade);
        }
        private protected override void ShowExamQustions(string ExamType)
        {
            base.ShowExamQustions("True | False Question");
        }
        #endregion
    }
}
