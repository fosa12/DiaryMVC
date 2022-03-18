using System;
using System.Collections.Generic;

namespace DiaryMVC.Domain.Model
{
    public class TaskType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }





    }
}
