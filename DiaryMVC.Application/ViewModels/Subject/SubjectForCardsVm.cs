using AutoMapper;
using DiaryMVC.Application.Mapping;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.ViewModels.Subject
{
    public class SubjectForCardsVm : IMapFrom<UniversitySubject>
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        //public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UniversitySubject, SubjectForCardsVm>();
                //.ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                //.ForMember(d => ShortName, opt => opt.MapFrom(s => s.ShortName));
        }
    }
}
