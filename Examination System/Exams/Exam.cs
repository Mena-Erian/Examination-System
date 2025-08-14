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
            QuestionList = questionList;
            Subject = subject;
        }
        protected Exam()
        {

        }
        #endregion

        #region Properties
        public int NumberOfQuestions { get; set; }
        public TimeOnly TimeOfExam { get; set; }
        public abstract List<Question> QuestionList { get; set; }
        public Subject Subject { get; set; }
        #endregion

        #region Methods
        public abstract void showAnswers();
        public override string ToString()
            => $"Number: {NumberOfQuestions},Time: {TimeOfExam},Subject: {Subject.SubjectName}";
        #endregion

    }
}
