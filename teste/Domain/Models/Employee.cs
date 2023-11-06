using System.Text.Json.Serialization;

namespace teste.Domain.Models
{
    public class Employee
    {
        #region Attributes
        public int? Enrollment { get; set; }
        public string? FullName { get; set; }
        public string? SocialSecurityNumber { get; set; }
        #endregion

        #region Ctor
        public Employee(int? enrollment, string? fullName, string? socialSecurityNumber)
        {
            Enrollment = enrollment;
            FullName = fullName;
            SocialSecurityNumber = socialSecurityNumber;
        }
        #endregion
    }
}
