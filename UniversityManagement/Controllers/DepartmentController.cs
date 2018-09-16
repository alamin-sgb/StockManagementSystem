using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagement.Manager;
using UniversityManagement.Models;

namespace UniversityManagement.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(Department aDepartment)
        {
            ViewBag.Message = departmentManager.Save(aDepartment);
            return View();
        }

        public ActionResult ShowDepartment(Department department)
        {
            ViewBag.allDepartments= departmentManager.GetAllDepartments();
            return View(department);
        }

    }
}