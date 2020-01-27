using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject.Login;
using Microsoft.EntityFrameworkCore;

namespace DataTransferObject
{
    public class EmployeeContext : DbContext
    {
      

        public EmployeeContext(DbContextOptions<EmployeeContext> options): base(options)
        {

        }
        public DbSet<EmployeeDTO> Employee { get; set; }

        public DbSet<LoginDTO> Login { get; set; }
    }
}
