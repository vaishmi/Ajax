using EmployeeDemoCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDemoCRUD.Controllers
{
    public class DepartmentController : Controller
    {
        EmpContext db = new EmpContext();
        public ActionResult DeptIndex()
        {
            return View();
        }

        public ActionResult GetDepartmentList()
        {
            return View(db.Department.ToList());
        }
       public ActionResult Create(string deptname)
        {
            Department dept = new Department();
            dept.Name = deptname;
           if(ModelState.IsValid)
           {
               db.Department.Add(dept);
               db.SaveChanges();
               return RedirectToAction("GetDepartmentList");
           }
           return View(dept);
        }

        public PartialViewResult Edit(int id,string deptname1)
       {
           IList<Department> department = db.Department.ToList();
           Department dept = department.Where(d => d.DeptId == id).FirstOrDefault();
           dept.DeptId = id;
           dept.Name = deptname1;
           db.SaveChanges();
           return PartialView("GetDepartmentList", department);
        }

        public ActionResult Delete(int idV)
        {
            Department dept = db.Department.Where(d => d.DeptId == idV).FirstOrDefault();
            if(dept!=null)
            {
                db.Department.Remove(dept);
                db.SaveChanges();
            }
            return RedirectToAction("GetDepartmentList");
        }

   }
}