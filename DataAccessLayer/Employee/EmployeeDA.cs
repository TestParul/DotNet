using System;
using System.Collections.Generic;
using System.Linq;
using DataTransferObject;

namespace DataAccessLayer
{
    public class EmployeeDA: IEmployee
    {
        public readonly EmployeeContext employeeContext;
        public EmployeeDA(EmployeeContext employeeContext)

        {
            this.employeeContext = employeeContext;
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            employeeContext.Add(employee);
            employeeContext.SaveChanges();           
        }

        public void DeleteEmployee(int id)
        {
            var employeeData = employeeContext.Employee.SingleOrDefault(m => m.ID == id);
            employeeContext.Remove(employeeData);
            employeeContext.SaveChanges();
        }

        public List<EmployeeDTO> GetAllEmployees()
        {
            var empList = employeeContext.Employee.ToList();
            return empList;
        }

        public EmployeeDTO GetEmployeeDetails(int? id)
        {
            var empData = employeeContext.Employee.SingleOrDefault(context => context.ID == id);

            return empData;
        }

        public void UpdateEmployee(int id, EmployeeDTO employee)
        {
            try
            {
               employeeContext.Update(employee);
                employeeContext.SaveChanges();
            }
            catch (Exception ex) {
                throw ex;
            }
        }


    }
}
