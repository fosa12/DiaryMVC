using AutoMapper;
using DiaryMVC.Application.Mapping;
using DiaryMVC.Application.ViewModels.Task;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiaryMVC.Application.ViewModels.Task
{
    public class SubjectDeatilsVm : IMapFrom<UniversitySubject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public List<TaskDeatailsVm> Tasks { get; set; }
        public void Mapping(Profile profie)
        {
            profie.CreateMap<UniversitySubject, SubjectDeatilsVm>();
        }
    }
}
