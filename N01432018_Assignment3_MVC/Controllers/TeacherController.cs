using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N01432018_Assignment3_MVC.Models;
using System.Diagnostics;

namespace N01432018_Assignment3_MVC.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET : Teacher(name of Controller)/List
        public ActionResult List(string SearchKey,string Number,string Date)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(SearchKey,Number,Date);

            return View(Teachers);
        }
        //GET : Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher newTeacher = controller.findTeacher(id);
            return View(newTeacher);
        }

        //GET :Teacher/DeleteTeacherConfirm/{id}
        public ActionResult DeleteTeacherConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher newTeacher = controller.findTeacher (id);
            return View(newTeacher);
        }

        //POST:Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: Teacher/New
        public ActionResult New()
        {
            //We are not providing any parameter in this because we dont need to know the information of id
            return View();
        }

        //POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname , string EmployeeNumber , string HireDate)
        {
            //Idetify that this method is running
            //Identify the inputs provided from the form

            Debug.WriteLine("I have access the create method");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(HireDate);

            //Server side validation
            if (TeacherFname == "" && TeacherLname == "")
            {
                Debug.WriteLine("Invalid Name");
                return RedirectToAction("New");
            } 

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.HireDate = Convert.ToDateTime(HireDate);
            //NewTeacher.Salary = Convert.ToDecimal(Salary);

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
    }
}
