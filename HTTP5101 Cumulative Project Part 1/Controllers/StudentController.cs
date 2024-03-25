using HTTP5101_Cumulative_Project_Part_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTTP5101_Cumulative_Project_Part_1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        //GET : Student/List
        public ActionResult List(string SearchKey = null)
        {

            StudentDataController controller = new StudentDataController();
            IEnumerable<Students> Students = controller.ListStudent(SearchKey);
            return View(Students);
        }

        //GET : /Student/Show/{id}
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Students NewStudent = controller.FindStudent(id);
            
            return View(NewStudent);
        }

    }
}