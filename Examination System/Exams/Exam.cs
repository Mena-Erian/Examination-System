using AssignmentExamination_System;
using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    abstract class Exam
    {
        #region Constructors
        protected Exam(int numberOfQuestions, TimeOnly timeOfExam, List<Question> questionList, Subject subject)
        {
            NumberOfQuestions = numberOfQuestions;
            TimeOfExam = timeOfExam;
            this.questionsList = questionList;
            Subject = subject;
        }
        protected Exam(Subject subject)
        {
            this.TimeOfExam = GetTimeFromUserByMinutes();
            this.NumberOfQuestions = GetNumberOfQuestions();
            this.Subject = subject;
            questionsList = SetQuestionListFromUser();

        }
        #endregion

        #region Feilds
        private protected List<Question> questionsList;
        #endregion

        #region Properties
        public int NumberOfQuestions { get; set; }
        public TimeOnly TimeOfExam { get; set; }
        public abstract List<Question> QuestionList { get; }
        public Subject Subject { get; set; }
        internal protected static List<QuestionType>? AvilableQuestionTypes { get; set; }
        #endregion

        #region Methods
        private protected abstract List<Question> SetQuestionListFromUser();
        public TimeOnly GetTimeFromUserByMinutes()
          => Helper.GetTimeOnlyByMinutes(
                "the Time For Exam From (30 min to 180 min)",
                false);
        public int GetNumberOfQuestions(bool withConsoleClear = true)
        {
            int value = Helper.GetIntFromUser(
                        "the Number of questions", false
                        );

            if (withConsoleClear) Console.Clear();

            return value;
        }
        public abstract List<Question> GetQuestionsFromUser(ExamType examType);
        public abstract void showAnswers();
        public override string ToString()
            => $"Number: {NumberOfQuestions},Time: {TimeOfExam},Subject: {Subject.SubjectName}";
        #endregion
    }
    internal enum ExamType
    {
        Practical = 1, Final
    }
}
