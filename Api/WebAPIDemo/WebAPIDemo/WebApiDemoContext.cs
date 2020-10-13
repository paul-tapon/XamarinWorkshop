using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebAPIDemo.Models;

namespace WebAPIDemo
{
    public class WebApiDemoContext : DbContext
    {
        public WebApiDemoContext() : base()
        {

        }
        public DbSet<EmployeeDto> Employees { get; set; }

        public DbSet<Product> Products { get; set; }

    }

}