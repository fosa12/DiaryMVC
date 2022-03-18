using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.ViewModels.Task
{
    public class ListEndTaskVm
    {
        public List<EndTaskVm> Tasks { get; set; }
        public int Count { get; set; }
        public int UniversityId { get; set; }
    }
}
