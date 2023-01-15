using System.ComponentModel.DataAnnotations;

namespace ArtsofteDbModel.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Surname { get; set; }


        [StringLength(50)]
        public string? Gender { get; set; }
        public int Age { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int ProgrammingLanguageId { get; set; }

        [ScaffoldColumn(false)]
        public Department? Department { get; set; }

        [ScaffoldColumn(false)]
        public ProgrammingLanguage? ProgrammingLanguage { get; set; }
    }
}
