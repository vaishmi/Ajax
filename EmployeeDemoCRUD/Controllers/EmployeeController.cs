using EmployeeDemoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDemoCRUD.Controllers
{
    public class EmployeeController : Controller
    {
        EmpDb db = new EmpDb();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetEmployeeList()
        {
            return PartialView(db.Employee.ToList());
        }

        public ActionResult Create(string fn,string ln,DateTime joindate,string deptname)
        {
            Employee emp = new Employee();
            emp.FirstName = fn;
            emp.LastName = ln;
            emp.JoiningDate = joindate;
            emp.DeptName = deptname;
            if(ModelState.IsValid)
            {
                db.Employee.Add(emp);
                db.SaveChanges();
                return RedirectToAction("GetEmployeeList");
            }
            return View(emp);


        }
       
            
           
        

        private void PopulateDepartment(Object selected = null)
        {
            var departmentsQuery = from d in db.Department
                                   orderby d.Name
                                   select d;
            ViewBag.DeptId = new SelectList(departmentsQuery, "DeptId", "Name", selected);

        }
    }

}