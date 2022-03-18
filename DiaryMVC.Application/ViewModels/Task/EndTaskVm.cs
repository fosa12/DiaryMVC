using AutoMapper;
using DiaryMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiaryMVC.Application.ViewModels.Task
{
    public class EndTaskVm : IMapFrom<DiaryMVC.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UniversitySubjectId { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? UserDeadline { get; set; }
        public DateTime? TaskEndDate { get; set; }
        public bool IsDone { get; set; }


        public void Mapping(Profile profie)
        {
            profie.CreateMap<DiaryMVC.Domain.Model.Task, EndTaskVm>();
        }
    }
}
