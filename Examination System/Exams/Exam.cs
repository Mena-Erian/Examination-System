using AssignmentExamination_System;
using Examination_System.Helpers;
using Examination_System.Questions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private protected virtual void ShowExamQustions(string ExamType)
        {
            userAnswers = new List<Answer>(questionsList.Count);
            for (int i = 0; i < questionsList.Count; i++)
            {
                Console.WriteLine($"{ExamType}\t Mark {questionsList[i].Mark}\t");
                Console.WriteLine($"{questionsList[i].Body}\n");
                foreach (var ans in questionsList[i].AnswerList)
                {
                    Console.WriteLine($"{ans.AnswerId}- {ans.AnswerText}");
                }

                int userAnswerId = Helper.GetIntFromUser("The answer Id", false);
                userAnswers.Add(
                    new Answer(userAnswerId,
                     questionsList[i].AnswerList[userAnswerId - 1].AnswerText));
            }
        }
       public void StartExam()
        {
            DateTime examStart = DateTime.Now;
            DateTime examEndLimit = examStart.Add(TimeOfExam.ToTimeSpan());
            bool examFinished = false;

            using System.Timers.Timer timer = new System.Timers.Timer(1000); // 1 second
            timer.Elapsed += OnTimedEvent;
            timer.Start();

            // Show the exam questions
            ShowExamQustions("MCQ Question");

            // Simulate answering questions (replace with your logic)
            showResultOfAnswers(userAnswers, out _, out _);
            examFinished = true; // User finished early

            // Wait until either time runs out or user finished
            while (!examFinished && DateTime.Now < examEndLimit)
            {
                Thread.Sleep(200);
            }

            timer.Stop();

            DateTime examActualEnd = DateTime.Now;
            TimeSpan durationTaken = examActualEnd - examStart;
            
            Console.WriteLine($"Time = {durationTaken.TotalSeconds} seconds");
            Console.WriteLine("Thank you.");

            void OnTimedEvent(object sender, ElapsedEventArgs e)
            {
                if (examFinished || DateTime.Now >= examEndLimit)
                {
                    timer.Stop();
                }
            }
        }

        public virtual void showResultOfAnswers(List<Answer> userAnswers, out string gradeText, out decimal grade)
        {
            Console.Clear();
            List<decimal> userMarks = new List<decimal>(userAnswers.Count);
            decimal totalFinalMarks = this.questionsList.Select(s => s.Mark).Sum();
            for (int i = 0; i < this.questionsList.Count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1} : {questionsList[i].Body}");
                Console.WriteLine($"Your Answer => {userAnswers[i]}");
                Console.WriteLine($"Right is Answer => {this.questionsList[i].RightAnswer}");

                if (userAnswers[i].AnswerId.CompareTo(questionsList[i].RightAnswer.AnswerId) == 0)
                {
                    userMarks.Add(i);
                }
            }
            grade = userMarks.Sum();
            gradeText = $"Your Grade is {userMarks.Sum()} from {totalFinalMarks}";
        }
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
