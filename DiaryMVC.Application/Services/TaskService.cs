using AutoMapper;
using AutoMapper.QueryableExtensions;
using DiaryMVC.Application.Interfaces;
using DiaryMVC.Application.ViewModels.Subject;
using DiaryMVC.Application.ViewModels.Task;
using DiaryMVC.Domain.Interface;
using DiaryMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiaryMVC.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepositories _taskRepositories;
        private readonly ISubjectRepositories _subjectRepositories;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepositories taskRepositories, IMapper mapper, ISubjectRepositories subjectRepositories)
        {
            _taskRepositories = taskRepositories;
            _subjectRepositories = subjectRepositories;
            _mapper = mapper;
        }


        public int AddNewTask(NewTaskVm newTaskVm)
        {
            //var taskType = _taskRepositories.GetAllTaskType().FirstOrDefault(x => x.Id == newTaskVm.TaskTypeId);
            //var subjName = _subjectRepositories.GetAllUniversitySubjects().FirstOrDefault(x => x.Id == newTaskVm.UniversitySubjectId);

            var newTask = _mapper.Map<DiaryMVC.Domain.Model.Task>(newTaskVm);
            
            var id = _taskRepositories.AddTask(newTask);

            return id;
        }

        public NewTaskToSubjectVM AddNewTaskToSubject(int id)
        {
            Task task = new Task();
            task.UniversitySubjectId = id;
            var taskVm = _mapper.Map<NewTaskToSubjectVM>(task);
            return taskVm;
        }

        public EditTaskVm EditTask(int id)
        {
            var task = _taskRepositories.GetTaskById(id);
            var taskVm = _mapper.Map<EditTaskVm>(task);
            return taskVm;
        }

        public int EditTask(EditTaskVm editTaskVm)
        {


            Task task = new Task()
            {
                Id = editTaskVm.Id,
                UserDeadline = editTaskVm.UserDeadline

            };

            _taskRepositories.EditTask(task);

            return editTaskVm.Id;
        }

        public ListTaskForIndexVm GetAllTaskForIndexVmSortedByDeadLine()
        {
            var task = _taskRepositories.GetAllTask().OrderBy(x=> x.Deadline).ProjectTo<TaskForIndexVm>(_mapper.ConfigurationProvider).ToList();

            var taskList = new ListTaskForIndexVm()
            {
                Tasks = task,
                Count = task.Count
            };
            return taskList;
        }

        public ListEndTaskVm GetEndTask(int subjectId)
        {
            var tasks = _taskRepositories.GetAllTask()
                .Where(x => x.IsDone == true)
                .Where(x => x.UniversitySubjectId == subjectId)
                .ProjectTo<EndTaskVm>(_mapper.ConfigurationProvider)
                .ToList();
            var taskEndList = new ListEndTaskVm()
            {
                Tasks = tasks,
                Count = tasks.Count,
                UniversityId = subjectId
                
            };
            return taskEndList;
        }

        public TaskDeatailsVm GetTaskDeatailsById(int taskId)
        {
            var task = _taskRepositories.GetTaskById(taskId);
            var taskVm = _mapper.Map<TaskDeatailsVm>(task);
            return taskVm;
        }

        public void MarkDone(int id)
        {
            var task = _taskRepositories.GetTaskById(id);
            task.IsDone = true;
            task.TaskEndDate = DateTime.Now;
            _taskRepositories.MarkDone(task);
        }

        public void MarkTaskToStart(int id)
        {
            var task = _taskRepositories.GetTaskById(id);
            task.InProgres = true;
            


            _taskRepositories.StartTask(task);



        }
    }
}
