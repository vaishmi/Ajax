using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDDemo.Models
{
    public class studentDb : DbContext
    {
        public DbSet<Student> Student { get; set; }
    }
}