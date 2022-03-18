using DiaryMVC.Application.Interfaces;
using DiaryMVC.Application.ViewModels.Subject;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiaryMVC.Web.Controllers
{
    public class StartController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ISubjectService _subjectService;
        public StartController(ITaskService taskService, ISubjectService subjectService)
        {
            _taskService = taskService;
            _subjectService = subjectService;
        }
        public IActionResult Index()
        {
            //utworzyć widok 
            //pojawią się kafelki z przedmiotami skróty 
            //
            //przygotować dane
            //serwis musi zwrócić dane w odpowiednim formacie
            var model = _subjectService.GetAllTaskAndSubjectForIndex();
            

            return View(model);
        }
        public IActionResult ViewSubject(int id)
        {
            var model = _subjectService.GetUniversityDeatailsById(id);



            return View(model);
        }
        [HttpGet]
        public IActionResult AddSubject()
        {

            return View(new NewSubjectVm());
        }
        [HttpPost]
        public IActionResult AddSubject(NewSubjectVm model)
        {
            var id = _subjectService.AddNewSubject(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult RemoveSubject(int id)
        {
            _subjectService.RemoveSubject(id);
            return RedirectToAction("Index");
        }

    }
}
