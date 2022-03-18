using AutoMapper;
using DiaryMVC.Application.Mapping;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.ViewModels.Task
{
    public class TaskDeatailsVm : IMapFrom<DiaryMVC.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TaskTypeId { get; set; }
        public virtual TaskType TaskType { get; set; }
        public int UniversitySubjectId { get; set; }
        public virtual UniversitySubject UniversitySubject { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime UserDeadline { get; set; }  
        public bool IsDone { get; set; }
        public bool InProgres { get; set; }
        public void Mapping(Profile profie)
        {
            profie.CreateMap<DiaryMVC.Domain.Model.Task, TaskDeatailsVm>();
        }
    }
}
