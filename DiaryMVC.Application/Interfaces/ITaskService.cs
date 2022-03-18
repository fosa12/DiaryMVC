using DiaryMVC.Application.ViewModels.Subject;
using DiaryMVC.Application.ViewModels.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiaryMVC.Application.Interfaces
{
    public interface ITaskService
    {
        ListTaskForIndexVm GetAllTaskForIndexVmSortedByDeadLine();
        TaskDeatailsVm GetTaskDeatailsById(int taskId);
        int AddNewTask(NewTaskVm newTaskVm);
        NewTaskToSubjectVM AddNewTaskToSubject(int id);
        ListEndTaskVm GetEndTask(int subjectId);
        void MarkTaskToStart(int id);
        void MarkDone(int id);
        EditTaskVm EditTask(int id);
        int EditTask(EditTaskVm editTaskVm);
    }
}
