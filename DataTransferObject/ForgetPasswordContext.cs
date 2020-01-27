using System;
using System.Collections.Generic;
using System.Text;
using DataTransferObject.ForgetPassword;
using Microsoft.EntityFrameworkCore;

namespace DataTransferObject
{
    public class ForgetPasswordContext : DbContext
    {
        public object loginDTO;

        public ForgetPasswordContext(DbContextOptions<ForgetPasswordContext> options) : base(options)
        {

        }
        
        public DbSet<ForgetPasswordDTO> forgetPassContext { get; set; }

    }
}
