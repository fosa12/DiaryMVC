using AutoMapper;
using DiaryMVC.Application.Mapping;
using DiaryMVC.Application.ViewModels.Subject;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;


namespace DiaryMVC.Application.ViewModels.Task
{
    public class NewTaskVm : IMapFrom<DiaryMVC.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskTypeId { get; set; }
        public int UniversitySubjectId { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? UserDeadline { get; set; }
        public bool IsDone { get; set; }
        public bool InProgres { get; set; }
        
        public void Mapping(Profile profie)
        {
            profie.CreateMap<NewTaskVm, DiaryMVC.Domain.Model.Task>();
        }
    }
}
