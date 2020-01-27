using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransferObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccessLayer;
using BusinessLayer;
using Microsoft.AspNetCore.Authorization;

namespace DotNetCoreBasicAssignment.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        private static IEmployee _dataAccess;

        public EmployeeController(IEmployee dataAccess)
        {
            _dataAccess = dataAccess;
        }

        EmployeeModel employeeObj = new EmployeeModel(_dataAccess);

        [HttpGet]
        public ActionResult GetEmployees()
        {
            EmployeeModel employeeObj = new EmployeeModel();
            EmployeeDTO objDTO= new EmployeeDTO();
            try
            {
                employeeObj =  new EmployeeModel(_dataAccess);
                var empList = employeeObj.GetAllEmployees();
                objDTO.employeeList = empList;
                return View("GetEmployees", objDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        [HttpGet]
        public ActionResult EmployeeDetails(int id)
        {
            var empDetails = employeeObj.GetEmployeeDetails(id);
            return View(empDetails);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEmployee(EmployeeDTO employee)
        {
            try
            {
                if (ModelState.IsValid) {
                    employeeObj.AddEmployee(employee);
                }
                return RedirectToAction(nameof(AddEmployee));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return View();
            }
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            var empdata = employeeObj.GetEmployeeDetails(id);
            return View(empdata);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEmployee(int id, EmployeeDTO employeeDTO)
        {
            try
            {
                employeeObj.UpdateEmployee(id, employeeDTO);
                return RedirectToAction("EditEmployee", id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       [HttpGet]      
        public ActionResult Delete(int id)
        {
            try
            {
                employeeObj.DeleteEmployee(id);
                return RedirectToAction("GetEmployees");
            }
            catch (Exception ex) {
                throw ex;
            }
        }        
    }
}
