using DiaryMVC.Application.ViewModels.Subject;
using DiaryMVC.Application.ViewModels.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.Interfaces
{
    public interface ISubjectService
    {

        SubjectDeatilsVm GetUniversityDeatailsById(int subjectId);
        int AddNewSubject(NewSubjectVm newSubjectVm);
        IndexVm GetAllTaskAndSubjectForIndex();
        CardsSubjectForCardsVm GetAllShortNameUniversitySubjectForCards();

        CardsSubjectForCardsVm GetAllShortName();
        void RemoveSubject(int id);
        
    }
}
