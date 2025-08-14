using AssignmentExamination_System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Exams
{
    internal class Subject
    {
        #region Constructors
        public Subject(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }
        public Subject(int subjectId, string subjectName, Exam examOfSubject) : this(subjectId, subjectName)
        {
            ExamOfSubject = examOfSubject;
        }
        #endregion

        #region Properteis
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamOfSubject { get; set; }
        #endregion

        #region Methods
        public Exam CreateExam()
        {
            ExamType examType = Helper.GetFromUserByType<ExamType>(
                "the type of Exam (1 for Practical | 2 for Final)",
                false);

            Exam exam;
            switch (examType)
            {
                case ExamType.Practical:
                    exam = new PracticalExam(this);
                    break;
                case ExamType.Final:
                    exam = new FinalExam(this);
                    break;
                default:
                    goto case ExamType.Practical;
            }

            return exam;
        }
        public override string ToString() =>
            $"Subject Id: {SubjectId},Subject Name: {SubjectName}";
        #endregion
    }
}
