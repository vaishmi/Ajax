using CRUDDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDDemo.Controllers
{
    public class StudentController : Controller
    {
        studentDb db=new studentDb();
        
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetStudentList()
        {

           
            return PartialView(db.Student.ToList());
            
        }
        public PartialViewResult Edit(int id, string Deptn)
        {
            IList<Student> student = db.Student.ToList();
            Student stu = student.Where(p => p.Id == id).SingleOrDefault();
            stu.DepartmentName = Deptn;
            db.SaveChanges();
            return PartialView("GetStudentList", student);
        }

      
        public ActionResult Create(string name,string Dept)
       {
          // IList<Student> student = db.Student.ToList();
           Student student = new Student();
         
           student.Name = name;
           student.DepartmentName = Dept;
          if(ModelState.IsValid)
          { 
               db.Student.Add(student);
               db.SaveChanges();
              return RedirectToAction("GetStudentList");
          }
               return View(student);
          
       }

        public ActionResult Delete(int id)
        {
           
            Student student = db.Student.Where(m => m.Id == id).FirstOrDefault();
            if (student != null)
            {
                db.Student.Remove(student);
                db.SaveChanges();
                
            }
          
            return RedirectToAction("GetStudentList");
            
        }
       
    }
}