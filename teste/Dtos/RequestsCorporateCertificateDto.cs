using CorporateElectronicCertificateGenerator.Domain.Models;

namespace CorporateElectronicCertificateGenerator.Dtos
{
    public class RequestsCorporateCertificateDto
    {
        public string? CompanyName { get; set; }
        //public byte[]? Modulus { get; set; }
        //public byte[]? Exponent { get; set; }
        //public string? PublicExponent { get; set; }
        //public string? PrivateExponent { get; set; }
        //public string? P { get; set; }
        //public string? Q { get; set; }
        //public string? Dp { get; set; }
        //public string? Dq { get; set; }
        //public string? QInv { get; set; }
        public int? EnrollmentEmployee { get; set; }
        public string? EmployeeFullName { get; set; }
        public string? SocialSecurityNumberEmployee { get; set; }
    }
}
