using DiaryMVC.Domain.Interface;
using DiaryMVC.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DiaryMVC.Infrastructure.Repositories
{
    public class TaskRepositories : ITaskRepositories
    {
        private readonly Context _context;

        public TaskRepositories(Context context)
        {
            _context = context;
        }
        public void DeleteTask(int taskId)
        {
            var taskToDelete = _context.Tasks.FirstOrDefault(x => x.Id == taskId);
            if (taskToDelete != null)
            {
                _context.Tasks.Remove(taskToDelete);
                _context.SaveChanges();
            }
        }
        public int AddTask(Task task)
        {
            task.Id = 0;//Do zastanowienia czemu z serwisu zwraca 1?????? mimo iż wartość nie jest przypisana ?

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task.Id;
        }
        public IQueryable<Task> GetTasksByTaskType(int typeId)
        {
            var tasks = _context.Tasks.Where(x => x.TaskTypeId == typeId);
            return tasks;
        }
        public Task GetTaskById(int taksId)
        {
            var task = _context.Tasks.Include(x => x.TaskType).Include(x => x.UniversitySubject).FirstOrDefault(x => x.Id == taksId);
            return task;
        }

        public IQueryable<TaskType> GetAllTaskType()
        {
            var taskType = _context.TaskTypes;
            return taskType;
        }
        public IQueryable<Task> GetAllTask()
        {
            var tasks = _context.Tasks;
            return tasks;
        }

        public string GetTaskTypeName()
        {
            throw new NotImplementedException();
        }

        public void StartTask(Task task)
        {
            _context.Attach(task);
            _context.Entry(task).Property("InProgres").IsModified = true;
            _context.SaveChanges();


        }
        public void MarkDone(Task task)
        {
            _context.Attach(task);
            _context.Entry(task).Property("IsDone").IsModified = true;
            _context.Entry(task).Property("TaskEndDate").IsModified = true;
            _context.SaveChanges();


        }

        public void EditTask(Task task)
        {
            _context.Attach(task);
            _context.Entry(task).Property("UserDeadline").IsModified=true;
            _context.SaveChanges();
        }
    }
}
