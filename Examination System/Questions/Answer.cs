using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Questions
{
    class Answer
    {
        #region Constructors
        public Answer(int answerId, string answerText)
        {
            AnswerId = answerId;
            AnswerText = answerText;
        }
        #endregion

        #region Properties
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        
        #endregion


        #region Methods

        public override string ToString() => $"Answer Id: {AnswerId}, Answer Text: {AnswerText}";
        #endregion

    }
}
