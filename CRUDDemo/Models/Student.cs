using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDDemo.Models
{
    public class Student
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String DepartmentName { get; set; }
    }

   }