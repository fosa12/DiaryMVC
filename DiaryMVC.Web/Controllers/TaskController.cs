using DiaryMVC.Application.Interfaces;
using DiaryMVC.Application.ViewModels.Task;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DiaryMVC.Web.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ISubjectService _subjectService;
        public TaskController(ITaskService taskService, ISubjectService subjectService)
        {
            _taskService = taskService;
            _subjectService = subjectService;
        }
        
        public IActionResult Index()
        {
            var model = _taskService.GetAllTaskForIndexVmSortedByDeadLine();
            return View(model);
        }
        public IActionResult ViewTask(int id)
        {
            var model = _taskService.GetTaskDeatailsById(id);

            return View(model);
        }
        [HttpGet]
        public IActionResult AddTask()
        {
            var subject = _subjectService.GetAllShortName();
            return View(new NewTaskVm());
        }
        [HttpPost]
        public IActionResult AddTask(NewTaskVm model, int idSu)
        {
            var id = _taskService.AddNewTask(model);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddTaskToConcretSubject(int id)
        {
            var model = _taskService.AddNewTaskToSubject(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult AddTaskToConcretSubject(NewTaskVm model)
        {
            var id = _taskService.AddNewTask(model);

            return RedirectToAction("Index","Start");
        }
        [HttpGet]
        public IActionResult StartTask(int id)
        {
            _taskService.MarkTaskToStart(id);
            return Redirect(Request.Headers["Referer"].ToString());
            //return RedirectToAction("Index", "Start");
        }
        [HttpGet]
        public IActionResult MarkTaskDone(int id)
        {
            _taskService.MarkDone(id);
            return Redirect(Request.Headers["Referer"].ToString());
            //return RedirectToAction("Index", "Start");
        }
        [HttpGet]
        public IActionResult EndTaskSubject(int id)
        {
            var model = _taskService.GetEndTask(id);

            return View(model);
        }
        [HttpGet]
        public IActionResult EditTask(int id)
        {
            var model = _taskService.EditTask(id);



            return View(model);
        }
        [HttpPost]
        public IActionResult EditTask(EditTaskVm editTaskVm)
        {
            var id = _taskService.EditTask(editTaskVm);



            return RedirectToAction("Index", "Start");
        }

    }
}
