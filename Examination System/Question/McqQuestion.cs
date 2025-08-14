using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Question
{
    internal class McqQuestion : Question
    {
        public CountOfAnswer CountOfAnswers { get; set; }
    }
    enum CountOfAnswer
    {
        One = 1, three, Many
    }
}
