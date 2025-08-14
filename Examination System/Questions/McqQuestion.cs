using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    internal class McqQuestion : Question
    {
        public CountOfAnswer CountOfAnswers { get; set; }
        public override List<Answer> AnswerList
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
        public override Answer RightAnswer
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
    enum CountOfAnswer
    {
        One = 1, three, Many
    }
}
