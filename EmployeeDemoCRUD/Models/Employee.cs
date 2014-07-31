using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeDemoCRUD.Models
{
    public class Employee
    {
        public int Id { get; set; }
         [Display(Name="First Name")]
        public string FirstName { get; set; }
         [Display(Name = "Lats Name")]
        public string LastName { get; set; }
        [Display(Name="Contact No")]
         public long Contactno { get; set; }
         [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
         public DateTime JoiningDate { get; set; }
       
        public string DeptName { get; set; }
       
    }
}