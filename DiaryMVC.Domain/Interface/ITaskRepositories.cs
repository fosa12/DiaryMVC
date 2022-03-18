using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiaryMVC.Domain.Interface
{
    public interface ITaskRepositories
    {
        void DeleteTask(int taskId);
        int AddTask(Task task);

        IQueryable<Task> GetTasksByTaskType(int typeId);

        Task GetTaskById(int taksId);

        IQueryable<TaskType> GetAllTaskType();

        string GetTaskTypeName();

        IQueryable<Task> GetAllTask();
        void StartTask(Task task);
        void MarkDone(Task task);
        void EditTask(Task task);
    }


}
