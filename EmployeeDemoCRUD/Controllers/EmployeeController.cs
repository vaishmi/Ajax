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
        EmpContext db = new EmpContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetEmployeeList()
        {
            return PartialView(db.Employee.ToList());
        }

        public ActionResult Create(string fn,string ln,long cn,DateTime joindate,string deptname)
        {
            Employee emp = new Employee();
            emp.FirstName = fn;
            emp.LastName = ln;
            emp.Contactno = cn;
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

        public PartialViewResult Edit(int id, string fn1,string ln1,long conNum,string deptname1)
        {
            IList<Employee> employee = db.Employee.ToList();
            Employee emp = employee.Where(p => p.Id == id).SingleOrDefault();
            emp.FirstName = fn1;
            emp.LastName = ln1;
            emp.Contactno = conNum;
            emp.DeptName = deptname1;
            db.SaveChanges();
            return PartialView("GetEmployeeList", employee);
        
        }
        public ActionResult Delete(int idV)
        {

            Employee emp = db.Employee.Where(m => m.Id == idV).FirstOrDefault();
            if (emp != null)
            {
                db.Employee.Remove(emp);
                db.SaveChanges();

            }

            return RedirectToAction("GetEmployeeList");

        }
       
            
           
        

        //private void PopulateDepartment(Object selected = null)
        //{
        //    var departmentsQuery = from d in db.Department
        //                           orderby d.Name
        //                           select d;
        //    ViewBag.DeptId = new SelectList(departmentsQuery, "DeptId", "Name", selected);

        //}
    }

}