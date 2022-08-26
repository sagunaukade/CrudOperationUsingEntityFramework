using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeDetailsApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        EMPLOYEEDBEntities dbObj = new EMPLOYEEDBEntities();
        public ActionResult Employee(EMPLOYEE obj)
        {
            //if (obj != null)
            //    return View(obj);
            //else
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(EMPLOYEE model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                EMPLOYEE obj = new EMPLOYEE();
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Address = model.Address;
                obj.Mobile = model.Mobile;
                obj.DOB = model.DOB;

                if (model.Id == 0)
                {

                    dbObj.EMPLOYEES.Add(obj);
                    dbObj.SaveChanges();
                }
                else
                {
                    dbObj.Entry(obj).State = EntityState.Modified;
                    dbObj.SaveChanges();

                }

                ModelState.Clear();
                }
            var list = dbObj.EMPLOYEES.ToList();
            return View("EmployeeList", list);
            //    return View("Employee");
        }


        public ActionResult UpdateEmployee(EMPLOYEE obj)
        {

            return View();
        }

        [HttpPost]
        public ActionResult EditEmployee(EMPLOYEE model)
        {

            if (ModelState.IsValid)
            {
                EMPLOYEE obj = new EMPLOYEE();
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Address = model.Address;
                obj.Mobile = model.Mobile;
                obj.DOB = model.DOB;

                dbObj.Entry(obj).State = EntityState.Modified;
                dbObj.SaveChanges();

                ModelState.Clear();
            }
            var list = dbObj.EMPLOYEES.ToList();
            return View("EmployeeList", list);
        }

        public ActionResult EmployeeList()
        {
            var res = dbObj.EMPLOYEES.ToList();
            
            return View(res);
        }

        public ActionResult Delete(int id)
        {

            var res = dbObj.EMPLOYEES.Where(x => x.Id == id).First();
            dbObj.EMPLOYEES.Remove(res);
            dbObj.SaveChanges();

            var list = dbObj.EMPLOYEES.ToList();
            return View("EmployeeList", list);
        }

    }

}