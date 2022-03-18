using AutoMapper;
using AutoMapper.QueryableExtensions;
using DiaryMVC.Application.Interfaces;
using DiaryMVC.Application.ViewModels.Subject;
using DiaryMVC.Application.ViewModels.Task;
using DiaryMVC.Domain.Interface;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ITaskRepositories _taskRepositories;
        private readonly ISubjectRepositories _subjectRepositories;
        private readonly IMapper _mapper;
        public SubjectService(ITaskRepositories taskRepositories, ISubjectRepositories subjectRepositories,IMapper mapper)
        {
            _taskRepositories = taskRepositories;
            _subjectRepositories = subjectRepositories;
            _mapper = mapper;
        }
        public int AddNewSubject(NewSubjectVm newSubjectVm)
        {
            var newSubject = _mapper.Map<UniversitySubject>(newSubjectVm);
            var id = _subjectRepositories.AddUniversitySubject(newSubject);

            return id;
        }

        public IndexVm GetAllTaskAndSubjectForIndex()
        {
            var subject = _subjectRepositories.GetAllUniversitySubjects()
                .Where(x => x.IsDeleted == false)
                .ProjectTo<SubjectForCardsVm>(_mapper.ConfigurationProvider)
                .ToList();
            var task = _taskRepositories.GetAllTask()
                .Where(x => x.IsDone == false)
                .OrderBy(x => x.Deadline)
                .ProjectTo<TaskForIndexVm>(_mapper.ConfigurationProvider)
                .Take(15)
                .ToList();
                



            /*typy warning
             * Attention! You have more than one task at the same time! The names of these tasks are: #Type1
             * Attention! Today the time to complete the task is running out:
             * 
             */



            var taskWarningType1 = _taskRepositories.GetAllTask().Where(x => x.IsDone == false).OrderBy(x => x.Deadline).ToArray();
            List<WarningVm> warnings = new List<WarningVm>();

            //int liczbaElementow = taskWarningType1.Length / 2 + 1;

            //for (int i = 0; i < liczbaElementow; i+=2)
            //{
            //    for (int j = 1; j < liczbaElementow; j+=2)
            //    {
            //        if (taskWarningType1[i].Deadline == taskWarningType1[j].Deadline)
            //        {
            //            WarningVm warningVm = new WarningVm();
            //            warningVm.WarningString = $"Attention! You have more than one task at the same time! The names of these tasks are: {taskWarningType1[i].Name},{taskWarningType1[j].Name}";
            //            warnings.Add(warningVm);
            //        }
            //    }
            //}
            DateTime dateTime = DateTime.Now;
            foreach (var item in taskWarningType1)
            {
                if (dateTime.Day == item.Deadline.Day && dateTime.Month == item.Deadline.Month && dateTime.Year == item.Deadline.Year)
                {
                    WarningVm warningVm = new WarningVm();
                    warningVm.TaskId = item.Id;
                    warningVm.WarningString = $"Attention! Today the time to complete the task is running out: {item.Name}";
                    warnings.Add(warningVm);
                }
            }
            







            var taskAndSubjectIndex = new IndexVm()
            {
                Subjects = subject,
                CountSubject = subject.Count,
                Tasks = task,
                CountTask = task.Count,
                Warnings = warnings,
                CountWarnings = warnings.Count
                
            };
            return taskAndSubjectIndex;

        }

        public SubjectDeatilsVm GetUniversityDeatailsById(int subjectId)
        {
            var subject = _subjectRepositories.GetUniversitySubjectById(subjectId);
            var task = _taskRepositories.GetAllTask().Where(x => x.UniversitySubjectId == subjectId).Where(x => x.IsDone == false)
                .ProjectTo<TaskDeatailsVm>(_mapper.ConfigurationProvider).ToList();
            var subjectVm = new SubjectDeatilsVm
            {
                Id = subject.Id,
                Name = subject.Name,
                ShortName = subject.ShortName,
                Tasks = task
            };
            return subjectVm;
        }
        public CardsSubjectForCardsVm GetAllShortNameUniversitySubjectForCards()
        {
            var subject = _subjectRepositories.GetAllUniversitySubjects()
                .ProjectTo<SubjectForCardsVm>(_mapper.ConfigurationProvider).ToList();

            var subjectList = new CardsSubjectForCardsVm()
            {
                Subjects = subject,
                Count = subject.Count
            };
            return subjectList;
        }

        public CardsSubjectForCardsVm GetAllShortName()
        {
            var subject = _subjectRepositories.GetAllUniversitySubjects()
                .ProjectTo<SubjectForCardsVm>(_mapper.ConfigurationProvider).ToList();


            var subjectList = new CardsSubjectForCardsVm()
            {
                Subjects = subject,
                Count = subject.Count
            };
            return subjectList;
        }

        public void RemoveSubject(int id)
        {
            _subjectRepositories.DeleteUniversitySubject(id);
        }
    }
}
