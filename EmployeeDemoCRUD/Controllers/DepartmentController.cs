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
        EmpDb db = new EmpDb();
        public ActionResult DeptIndex()
        {
            return View(db.Department.ToList());
        }
       

   }
}