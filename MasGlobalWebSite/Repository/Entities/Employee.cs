using System.ComponentModel.DataAnnotations;

namespace MasGlobalWebSite.Repository.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        [MaxLength(200)]
        public string RoleName { get; set; }

        [MaxLength(200)]
        public string RoleDescription { get; set; }

        public int HourlySalary { get; set; }

        public int MonthlySalary { get; set; }

    }
}
