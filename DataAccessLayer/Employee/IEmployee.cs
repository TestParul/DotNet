using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IEmployee
    {
        void AddEmployee(EmployeeDTO employee);
        void UpdateEmployee(int id, EmployeeDTO employee);
        void DeleteEmployee(int ID);
        List<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeDetails(int? id);
    }
}
