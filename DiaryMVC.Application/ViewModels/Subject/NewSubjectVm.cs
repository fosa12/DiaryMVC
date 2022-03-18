using AutoMapper;
using DiaryMVC.Application.Mapping;
using DiaryMVC.Domain.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.ViewModels.Subject
{
    public class NewSubjectVm : IMapFrom<UniversitySubject>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public void Mapping(Profile profie)
        {
            profie.CreateMap<NewSubjectVm, UniversitySubject>();
        }
    }
    public class NewSubjectValidiation : AbstractValidator<NewSubjectVm>
    {
        public NewSubjectValidiation()
        {
            RuleFor(x => x.Name).NotNull();
            RuleFor(x => x.Name).MaximumLength(255);
            RuleFor(x => x.ShortName).MaximumLength(10);
        }
    }
}
