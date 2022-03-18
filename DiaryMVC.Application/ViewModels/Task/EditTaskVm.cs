using AutoMapper;
using DiaryMVC.Application.Mapping;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiaryMVC.Application.ViewModels.Task
{
    public class EditTaskVm : IMapFrom<DiaryMVC.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskTypeId { get; set; }
        public string TaskType { get; set; }
        public int UniversitySubjectId { get; set; }
        public string UniversitySubject { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? UserDeadline { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public bool IsDone { get; set; }
        public bool InProgres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<EditTaskVm, DiaryMVC.Domain.Model.Task>().ReverseMap()
                .ForMember(s => s.TaskType, opt => opt.MapFrom(d=> d.TaskType.Name))
                .ForMember(s => s.UniversitySubject, opt => opt.MapFrom(d => d.UniversitySubject.Name));
        }

    }
}
