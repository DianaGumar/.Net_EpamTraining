using DBClassLibrary.DAO;
using System.Collections.Generic;
using System.Linq;

namespace DBClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Reports
    {
        private DaoGroups daoGroup;
        private DaoSubjects daoSubject;
        private DaoStudents daoStudent;
        private DaoSessionExams daoExams;
        private DaoSessionResults daoResults;
        private string connectionString = null;

        /// <summary>
        /// Initializes a new instance of the Report class
        /// </summary>
        /// <param name="daoFactory"> Dao factory</param>
        public Reports(DaoFactory daoFactory)
        {
            daoGroup = daoFactory.GetDaoGroups();
            daoSubject = daoFactory.GetDaoSubjects();
            daoStudent = daoFactory.GetDaoStudents();
            daoExams = daoFactory.GetDaoSessExams();
            daoResults = daoFactory.GetDaoSessResults();
        }

        /// <summary>
        /// Get student session results
        /// </summary>
        /// <param name="sessionNumber"> Session number</param>
        /// <param name="groupName"> Group name</param>
        /// <returns></returns>
        public List<ReportSessionStudent> GetStudentsResults(int sessionNumber, string groupName)
        {
            var students = daoStudent.GetAllRecords();
            var subjects = daoSubject.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var exams = daoExams.GetAllRecords();
            var results = daoResults.GetAllRecords();
            
            int id = groups.Where(x => x.Name == groupName).Select(x => x.ID).First();

            List<ReportSessionStudent> studs = new List<ReportSessionStudent>();

            var allResults = from result in results
                                 join exam in exams on result.ExamID equals exam.ID
                                 join sbj in subjects on exam.SubjectID equals sbj.ID
                                 join grp in groups on exam.GroupID equals grp.ID
                                 join student in students on result.StudentID equals student.ID
                                 where exam.SessionNumber == sessionNumber & exam.GroupID == id
                                 select new { LastName = student.LastName, FirstName = student.FirstName, MiddleName = student.MiddleName,
                                              GroupName = grp.Name, SubjectName = sbj.Name, ExamType = exam.Type, Grade = result.Grade};

            foreach (var st in allResults)
            {
                studs.Add(new ReportSessionStudent()
                {
                    LastName = st.LastName,
                    FirstName = st.FirstName,
                    MiddleName = st.MiddleName,
                    GroupName = st.GroupName,
                    SubjectName = st.SubjectName,
                    ExamType = st.ExamType,
                    Grade = st.Grade
                });

            }

            return studs;
        }

        /// <summary>
        /// Get group session results
        /// </summary>
        /// <returns></returns>
        public List<ReportSessionGroup> GetGroupResults()
        {
            var students = daoStudent.GetAllRecords();
            var subjects = daoSubject.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var exams = daoExams.GetAllRecords();
            var results = daoResults.GetAllRecords();
            
            var myGroups = exams.GroupBy(g => g.GroupID).Where(w => w.Count() >= 1).Select(s => s.Key);

            List<ReportSessionGroup> groupResults = new List<ReportSessionGroup>();

            foreach (var item in myGroups)
            {
                var allResults = from result in results
                                 join exam in exams on result.ExamID equals exam.ID
                                 join grp in groups on exam.GroupID equals grp.ID
                                 where exam.GroupID == item
                                 select result;
                int minGrade = allResults.Min(x => x.Grade);
                int maxGrade = allResults.Max(x => x.Grade);
                double avgGrade = allResults.Average(x => x.Grade);
                string groupName = groups.Where(x => x.ID == item).Select(x => x.Name).First();

                groupResults.Add(new ReportSessionGroup()
                {
                    GroupName = groupName,
                    MaxGrade = maxGrade,
                    MinGrade = minGrade,
                    AverageGrade = avgGrade
                });
            }

            return groupResults;
        }

        /// <summary>
        /// Get all students to be expelled
        /// </summary>
        /// <returns></returns>
        public List<ReportBadStudent> GetBadStudents()
        {
            var students = daoStudent.GetAllRecords();
            var groups = daoGroup.GetAllRecords();
            var results = daoResults.GetAllRecords();

            List<ReportBadStudent> badStudents = new List<ReportBadStudent>();

            var allResults = from student in students
                             join result in results on student.ID equals result.StudentID
                             where result.Grade < 4 
                             select student;

            var badStuds = allResults.GroupBy(g => g.ID).Select(g => g.First());
            var groupResults = badStuds.Distinct().GroupBy(g => g.GroupID);

            foreach (var g in groupResults)
            {
                foreach (var x in g)
                {
                    badStudents.Add(new ReportBadStudent()
                    {
                        LastName = x.LastName,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        Sex = x.Sex,
                        GroupName = groups.Where(s => s.ID == x.GroupID).Select(s => s.Name).First(),
                        BirthDate = x.BirthDate
                    });
                }
            }

            return badStudents;
        }
    }
}
