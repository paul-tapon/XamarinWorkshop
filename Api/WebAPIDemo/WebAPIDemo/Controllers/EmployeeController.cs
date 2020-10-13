using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;

namespace WebAPIDemo.Controllers
{
    public class EmployeeController : ApiController
    {
        public List<EmployeeDto> Get()
        {
            var context = new WebApiDemoContext();

            return context.Employees.ToList();
        }
        // api/employee/4
        public EmployeeDto Get(int id)
        {
            var context = new WebApiDemoContext();

            var employee = context.Employees.FirstOrDefault(e => e.EmployeeId == id);

            if (employee == null) throw new Exception("Employee id not found.");

            return employee;
        }

        //HttpGet
        // api/employee?dept=IT
        public IEnumerable<EmployeeDto> Get(string dept)
        {
            var context = new WebApiDemoContext();

            return context
                    .Employees
                    .Where(e => e.Department == dept) //filter
                    .OrderBy(e=>e.Firstname); //sort
        }

        [HttpPost]
        public string Post([FromBody]EmployeeDto employee)
        {
            var context = new WebApiDemoContext();

            context.Employees.Add(employee);
            context.SaveChanges();

            return "Employee #" + employee.EmployeeNumber + " is created successfully.";
        }


        // api/employee/1
        [HttpPut]
        public string Put(int id,[FromBody]EmployeeDto employee)
        {

            var context = new WebApiDemoContext();

            EmployeeDto employeeUpdate = context
                                .Employees
                                .FirstOrDefault(e => e.EmployeeId == id);

            if (employeeUpdate == null) 
                return "Employee id " + id.ToString() + " not found.";

            employeeUpdate.Firstname = employee.Firstname;
            employeeUpdate.Lastname = employee.Lastname;
            employeeUpdate.MiddleName = employee.MiddleName;
            employeeUpdate.SuffixName = employee.SuffixName;
            employeeUpdate.MobileNumber = employee.MobileNumber;
            employeeUpdate.LandlineNumber = employee.LandlineNumber;

            context.SaveChanges();

            return "Employee number "+employee.EmployeeNumber
                +" with name "+employee.Firstname 
                +" "+employee.Lastname +" successfully updated.";
        }

    }
}
