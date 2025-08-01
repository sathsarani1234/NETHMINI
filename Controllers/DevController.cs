using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Data;
using EmployeeAPI.Models;

namespace EmployeeAPI.Controllers
{
    /// <summary>
    /// Development controller for testing search and pagination features
    /// </summary>
    [Authorize]
    public class DevController : Controller
    {
        private readonly EmployeeDbContext _context;

        public DevController(EmployeeDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Seed sample data for testing search and pagination
        /// </summary>
        public async Task<IActionResult> SeedSampleData()
        {
            // Check if data already exists
            if (await _context.Employees.AnyAsync())
            {
                TempData["ErrorMessage"] = "Sample data already exists. Clear the database first if you want to reseed.";
                return RedirectToAction("Index", "Employee");
            }

            // Sample employees data
            var sampleEmployees = new List<Employee>
            {
                new Employee { FullName = "John Smith", Email = "john.smith@company.com", Position = "Software Engineer", Department = "IT", Phone = "+1-555-0101", HireDate = DateTime.Now.AddYears(-2) },
                new Employee { FullName = "Sarah Johnson", Email = "sarah.johnson@company.com", Position = "Project Manager", Department = "IT", Phone = "+1-555-0102", HireDate = DateTime.Now.AddYears(-1) },
                new Employee { FullName = "Michael Brown", Email = "michael.brown@company.com", Position = "HR Manager", Department = "HR", Phone = "+1-555-0103", HireDate = DateTime.Now.AddMonths(-8) },
                new Employee { FullName = "Emily Davis", Email = "emily.davis@company.com", Position = "Marketing Specialist", Department = "Marketing", Phone = "+1-555-0104", HireDate = DateTime.Now.AddMonths(-6) },
                new Employee { FullName = "David Wilson", Email = "david.wilson@company.com", Position = "Financial Analyst", Department = "Finance", Phone = "+1-555-0105", HireDate = DateTime.Now.AddMonths(-10) },
                new Employee { FullName = "Lisa Miller", Email = "lisa.miller@company.com", Position = "Sales Representative", Department = "Sales", Phone = "+1-555-0106", HireDate = DateTime.Now.AddMonths(-4) },
                new Employee { FullName = "Robert Garcia", Email = "robert.garcia@company.com", Position = "DevOps Engineer", Department = "IT", Phone = "+1-555-0107", HireDate = DateTime.Now.AddMonths(-7) },
                new Employee { FullName = "Jennifer Martinez", Email = "jennifer.martinez@company.com", Position = "UX Designer", Department = "IT", Phone = "+1-555-0108", HireDate = DateTime.Now.AddMonths(-3) },
                new Employee { FullName = "James Anderson", Email = "james.anderson@company.com", Position = "Operations Manager", Department = "Operations", Phone = "+1-555-0109", HireDate = DateTime.Now.AddYears(-1) },
                new Employee { FullName = "Maria Rodriguez", Email = "maria.rodriguez@company.com", Position = "Customer Support Lead", Department = "Customer Service", Phone = "+1-555-0110", HireDate = DateTime.Now.AddMonths(-5) },
                new Employee { FullName = "William Taylor", Email = "william.taylor@company.com", Position = "Research Scientist", Department = "Research & Development", Phone = "+1-555-0111", HireDate = DateTime.Now.AddMonths(-9) },
                new Employee { FullName = "Jessica Thomas", Email = "jessica.thomas@company.com", Position = "Content Writer", Department = "Marketing", Phone = "+1-555-0112", HireDate = DateTime.Now.AddMonths(-2) },
                new Employee { FullName = "Christopher Lee", Email = "christopher.lee@company.com", Position = "Database Administrator", Department = "IT", Phone = "+1-555-0113", HireDate = DateTime.Now.AddMonths(-11) },
                new Employee { FullName = "Amanda White", Email = "amanda.white@company.com", Position = "Recruitment Specialist", Department = "HR", Phone = "+1-555-0114", HireDate = DateTime.Now.AddMonths(-1) },
                new Employee { FullName = "Daniel Harris", Email = "daniel.harris@company.com", Position = "Sales Manager", Department = "Sales", Phone = "+1-555-0115", HireDate = DateTime.Now.AddYears(-3) },
                new Employee { FullName = "Michelle Clark", Email = "michelle.clark@company.com", Position = "Quality Assurance", Department = "IT", Phone = "+1-555-0116", HireDate = DateTime.Now.AddMonths(-6) },
                new Employee { FullName = "Kevin Lewis", Email = "kevin.lewis@company.com", Position = "Business Analyst", Department = "Finance", Phone = "+1-555-0117", HireDate = DateTime.Now.AddMonths(-8) },
                new Employee { FullName = "Stephanie Walker", Email = "stephanie.walker@company.com", Position = "Social Media Manager", Department = "Marketing", Phone = "+1-555-0118", HireDate = DateTime.Now.AddMonths(-4) },
                new Employee { FullName = "Ryan Hall", Email = "ryan.hall@company.com", Position = "System Administrator", Department = "IT", Phone = "+1-555-0119", HireDate = DateTime.Now.AddMonths(-7) },
                new Employee { FullName = "Nicole Young", Email = "nicole.young@company.com", Position = "Product Manager", Department = "Operations", Phone = "+1-555-0120", HireDate = DateTime.Now.AddMonths(-3) }
            };

            try
            {
                await _context.Employees.AddRangeAsync(sampleEmployees);
                await _context.SaveChangesAsync();
                
                TempData["SuccessMessage"] = $"Successfully added {sampleEmployees.Count} sample employees for testing search and pagination features.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error seeding sample data: {ex.Message}";
            }

            return RedirectToAction("Index", "Employee");
        }

        /// <summary>
        /// Clear all employee data (for development testing only)
        /// </summary>
        public async Task<IActionResult> ClearAllData()
        {
            try
            {
                var employees = await _context.Employees.ToListAsync();
                if (employees.Any())
                {
                    _context.Employees.RemoveRange(employees);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Successfully removed {employees.Count} employees from the database.";
                }
                else
                {
                    TempData["ErrorMessage"] = "No employees found to remove.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error clearing data: {ex.Message}";
            }

            return RedirectToAction("Index", "Employee");
        }
    }
}
