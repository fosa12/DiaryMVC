using System;
using System.Collections.Generic;


namespace DiaryMVC.Domain.Model
{
    public class UniversitySubject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public bool IsDeleted { get; set; }

    }
}
