using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Domain.Interface
{
    public interface ISubjectRepositories
    {

        IQueryable<UniversitySubject> GetAllUniversitySubjects();

        UniversitySubject GetUniversityByShortName(string shortName);
        UniversitySubject GetUniversitySubjectById(int subjectId);

        int AddUniversitySubject(UniversitySubject universitySubject);

        void DeleteUniversitySubject(int subjectToDeleteId);
    }
}
