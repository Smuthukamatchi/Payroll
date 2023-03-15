using PayrollApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace PayrollApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Admin = Set<Models.Admin>();
        }
        public DbSet<Admin> Admin {get; set; }
        
    }
}