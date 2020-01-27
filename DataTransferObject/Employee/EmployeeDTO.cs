using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObject
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }

        public List<EmployeeDTO> employeeList = new List<EmployeeDTO>();


    }
}
