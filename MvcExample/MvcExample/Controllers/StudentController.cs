using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcExample.Models;

namespace MvcExample.Controllers
{
    public class StudentController : Controller
    {

        List<Student> studentsList = new List<Student>() { 
                                                            new Student{Id = 1, Name = "Vlad"},
                                                            new Student{Id = 2, Name = "Tudor"}
                                                            };

        public ActionResult GetStudentDetails(int id)
        {
            
            Student st = new Student();
            foreach(Student s in studentsList)
            {
                if (s.Id == id)
                {
                    return View("StudentView", s);
                }
            }
            return View("StudentNotFoundView");
        }

        [HttpPost]
        public ActionResult UpdateStudentDetails(Student st)
        {
            if (ModelState.IsValid)
            {
                foreach (Student s in studentsList)
                {
                    if (s.Id == st.Id)
                    {
                        studentsList[studentsList.IndexOf(s)] = st;
                        return View("StudentView", st);
                    }
                }
                return View("FailView");
            }
            else
            {
                return View("FailView");
            }
        }

    }
}
