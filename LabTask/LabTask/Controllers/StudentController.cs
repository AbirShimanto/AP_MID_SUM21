using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTask.Models;
using LabTask.Models.Database;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace LabTask.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student 
        public ActionResult Index()
        {
            
        
            Database db = new Database();
            var students = db.Students.GetAll();
            return View(students);
        

    }
        public ActionResult Department()
        {
            Database db = new Database();
            var departments = db.Departments.GetAll();
            return View(departments);
        }

        public ActionResult AddStudent()
        {
            Student p = new Student();
            return View(p);
        }

        [HttpPost]
        public ActionResult AddStudent(Student p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Students.Insert(p);
                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var p = db.Students.Get(id);

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Student p)
        {
            //update to db
            Database db = new Database();
            db.Students.Update(p);
            return RedirectToAction("Index");
        }
    }
}