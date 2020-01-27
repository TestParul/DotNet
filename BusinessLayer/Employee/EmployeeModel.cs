using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class EmployeeModel
    {
        private readonly IEmployee _employeeContext;
        public EmployeeModel()
        {

        }
        public EmployeeModel(IEmployee employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public void AddEmployee(EmployeeDTO employee) {
            _employeeContext.AddEmployee(employee);
        }

        public void AddEmployee()
        {
            Console.WriteLine("Test");
        }

        public void DeleteEmployee(int ID)
        {
            _employeeContext.DeleteEmployee(ID);
        }   

        public List<EmployeeDTO> GetAllEmployees()
        {
            var empList =  _employeeContext.GetAllEmployees();
            return empList;
        }

        public EmployeeDTO GetEmployeeDetails(int? id)
        {
            try
            {
                if (id != null)
                {
                    var empData = _employeeContext.GetEmployeeDetails(id);
                    return empData;
                }
                else {
                    return NotFound();
                     }
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }

        private EmployeeDTO NotFound()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(int id, EmployeeDTO employee)
        {
            _employeeContext.UpdateEmployee(id,employee);
        }
    }
}
