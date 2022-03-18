using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.ViewModels.Task
{
    public class ListTaskForIndexVm
    {
        public List<TaskForIndexVm> Tasks { get; set; }
        public int Count { get; set; }
    }
}
