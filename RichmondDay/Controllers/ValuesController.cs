using Newtonsoft.Json;
using RichmondDay.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RichmondDay.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")] // tune to your needs
 
    public class ValuesController : ApiController
    {
        List<MOCK_DATA> employees = new List<MOCK_DATA>();
        MOCK_DATA employee = new MOCK_DATA();
        // GET api/values
        public string Get()
        {

            using (var db = new richmondDayEntities())
            {
                employees = db.MOCK_DATA.ToList();
                return JsonConvert.SerializeObject(employees);
            }

        }
        // GET api/values/5
     
        public MOCK_DATA Get(Guid id)
        {
            using (var db = new richmondDayEntities())
            {
               employee = db.MOCK_DATA.FirstOrDefault(f => f.emp_id==id);
             }
            return employee ;
        }

        // POST api/values
        public void Post(EmployeeModel  emp)
        {
            using (var db = new richmondDayEntities())
            {
                employee.email = emp.email;
                employee.first_name = emp.first_name;
                employee.last_name = emp.last_name;
                employee.emp_id = Guid.NewGuid();

                db.MOCK_DATA.Add(employee);
                db.SaveChanges();
            }
        }

        // PUT api/values/5
        public void Put(EmployeeModel emp)
        {
           using (var db = new richmondDayEntities())
            {
                employee = db.MOCK_DATA.FirstOrDefault(f => f.emp_id== emp.emp_id);

                employee.email = emp.email;
                employee.first_name = emp.first_name;
                employee.last_name = emp.last_name;

                db.SaveChanges();
            }
        }

        // DELETE api/values/5
        public void Delete(Guid id)
        {
            
            using (var db = new richmondDayEntities())
            {
                employees = db.MOCK_DATA.ToList();
                employee = employees.FirstOrDefault(f => f.emp_id == id);

                db.MOCK_DATA.Remove(employee);
                db.SaveChanges();
            }
        }
    }
}
