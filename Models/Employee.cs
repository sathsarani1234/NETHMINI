using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI.Models
{
    public class Employee
    {
        /// <summary>
        /// Primary Key - EF Core will automatically recognize this as the primary key
        /// due to the naming convention (Id suffix) and will make it auto-generated
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }

        /// <summary>
        /// Full name of the employee
        /// </summary>
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        /// <summary>
        /// Email address of the employee
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Job position/title of the employee
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Position { get; set; } = string.Empty;

        /// <summary>
        /// Department where the employee works
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Phone number of the employee
        /// </summary>
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; } = string.Empty;

        /// <summary>
        /// Date when the employee was hired
        /// </summary>
        [Required]
        public DateTime HireDate { get; set; }
    }
}
