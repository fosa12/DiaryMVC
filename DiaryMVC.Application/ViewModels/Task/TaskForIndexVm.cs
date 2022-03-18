using AutoMapper;
using DiaryMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiaryMVC.Application.ViewModels.Task
{
    public class TaskForIndexVm : IMapFrom<DiaryMVC.Domain.Model.Task>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }


        public void Mapping(Profile profie)
        {
            profie.CreateMap<DiaryMVC.Domain.Model.Task, TaskForIndexVm>();
        }
    }
}
