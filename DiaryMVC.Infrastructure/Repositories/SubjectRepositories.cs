using DiaryMVC.Domain.Interface;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Infrastructure.Repositories
{
    public class SubjectRepositories:ISubjectRepositories
    {
        private readonly Context _context;

        public SubjectRepositories(Context context)
        {
            _context = context;
        }
        public IQueryable<UniversitySubject> GetAllUniversitySubjects()
        {
            var universitySubjects = _context.UniversitySubjects;
            return universitySubjects;
        }
        public UniversitySubject GetUniversityByShortName(string shortName)
        {
            var universitySubject = _context.UniversitySubjects.FirstOrDefault(x => x.ShortName == shortName);
            return universitySubject;
        }
        public int AddUniversitySubject(UniversitySubject universitySubject)
        {
            _context.UniversitySubjects.Add(universitySubject);
            _context.SaveChanges();
            return universitySubject.Id;
        }
        public void DeleteUniversitySubject(int subjectToDeleteId)
        {
            var subjectToDelete = _context.UniversitySubjects.FirstOrDefault(x => x.Id == subjectToDeleteId);
            if (subjectToDelete != null)
            {
                subjectToDelete.IsDeleted = true;
                _context.Attach(subjectToDelete);
                _context.Entry(subjectToDelete).Property("IsDeleted").IsModified = true;
                _context.SaveChanges();
            }
        }

        public UniversitySubject GetUniversitySubjectById(int subjectId)
        {
            var subject = _context.UniversitySubjects.FirstOrDefault(x => x.Id == subjectId);
            return subject;
        }
    }
}
