using AssignmentExamination_System;
using Examination_System.Helpers;
using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

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
            this.questionsList = SetQuestionListFromUser();
        }
        #endregion

        #region Feilds
        private protected List<Question> questionsList;

        #endregion

        #region Properties
        public int NumberOfQuestions { get; set; }
        public TimeOnly TimeOfExam { get; set; }
        public abstract List<Question> QuestionList { get; }
        public List<Answer> userAnswers { get; set; }
        public Subject Subject { get; set; }
        internal protected static List<QuestionType>? AvilableQuestionTypes { get; set; }
        #endregion

        #region Methods
        private protected abstract List<Question> SetQuestionListFromUser();
        private protected virtual void ShowExamQustions()
        {
            userAnswers = new List<Answer>(questionsList.Count);
            for (int i = 0; i < questionsList.Count; i++)
            {
                Console.WriteLine($"{questionsList[i].Body}\n");
                foreach (var ans in questionsList[i].AnswerList)
                {
                    Console.WriteLine($"{ans.AnswerId}- {ans.AnswerText}");
                }
                int userAnswerId = Helper.GetIntFromUser("The answer Id", false);
                userAnswers.Add(
                    new Answer(userAnswerId,
                     questionsList[i].AnswerList[userAnswerId].AnswerText));
            }
        }
        public void StartExam()
        {
            DateTime endTime = DateTime.Now.Add(TimeOfExam.ToTimeSpan());

            System.Timers.Timer timer = new System.Timers.Timer(1000); // 1 second
            timer.Elapsed += OnTimedEvent;
            timer.Start();

            ShowExamQustions(); // Show once at the start

            // Prevent program from exiting before timer finishes
            while (DateTime.Now < endTime)
            {
                Thread.Sleep(500);
            }

            timer.Stop();
            Console.WriteLine("⏰ Exam ended.");

            void OnTimedEvent(object sender, ElapsedEventArgs e)
            {
                //Console.WriteLine($"⏳ Exam running... {DateTime.Now}");
            }
        }

        public abstract void showAnswers();
        public TimeOnly GetTimeFromUserByMinutes()
        {
            return Helper.GetTimeOnlyByMinutes(
                        "the Time For Exam From (30 min to 180 min)",
                        false,
                        range: new Range<int>(30, 180));
        }
        public int GetNumberOfQuestions(bool withConsoleClear = true)
        {
            int value = Helper.GetIntFromUser(
                        "the Number of questions", false
                        );

            if (withConsoleClear) Console.Clear();

            return value;
        }
        public override string ToString()
            => $"Number: {NumberOfQuestions},Time: {TimeOfExam},Subject: {Subject.SubjectName}";
        #endregion
    }
    internal enum ExamType
    {
        Practical = 1, Final
    }
}
