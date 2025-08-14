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
        public override List<Question> QuestionList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void showAnswers()
        {
            throw new NotImplementedException();
        }
    }
}
