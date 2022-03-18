using DiaryMVC.Application.ViewModels.Subject;
using DiaryMVC.Application.ViewModels.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.ViewModels.Task
{
    public class IndexVm
    {
        public List<SubjectForCardsVm> Subjects { get; set; }
        public int CountSubject { get; set; }
        public List<TaskForIndexVm> Tasks { get; set; }
        public int CountTask { get; set; }
        public List<WarningVm> Warnings { get; set; }
        public int CountWarnings { get; set; }
    }
}
