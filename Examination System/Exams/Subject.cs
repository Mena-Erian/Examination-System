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
        public Subject(int subjectId, string subjectName, Exam examOfSubject)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            ExamOfSubject = examOfSubject;
        } 
        #endregion

        #region Properteis
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam ExamOfSubject { get; set; } 
        #endregion

        #region Methods
        public void CreateExam()
        {

        }
        public override string ToString() =>
            $"Subject Id: {SubjectId},Subject Name: {SubjectName}"; 
        #endregion
    }
}
