using CorporateElectronicCertificateGenerator.Domain.Models;
using CorporateElectronicCertificateGenerator.Dtos;
using System.Reflection;
using teste.Domain.Models;

namespace CorporateElectronicCertificateGenerator.Services
{
    public class CertificateGenerator
    {
        public Company? Company { get; set; }
        public Employee? Employee { get; set; }
        public CertificateGenerator(){}

        public void BuildFields(RequestsCorporateCertificateDto requestsCorporateCertificateDto)
        {
            #region Em análise
            //PrivateKeyCompany privateKeyCompany = new PrivateKeyCompany
            //{
            //    Modulus = requestsCorporateCertificateDto.Modulus,
            //    Exponent = requestsCorporateCertificateDto.Exponent,
            //    PublicExponent = requestsCorporateCertificateDto.PublicExponent,
            //    PrivateExponent = requestsCorporateCertificateDto.PrivateExponent,
            //    P = requestsCorporateCertificateDto.P,
            //    Q = requestsCorporateCertificateDto.Q,
            //    Dp = requestsCorporateCertificateDto.Dp,
            //    Dq = requestsCorporateCertificateDto.Dq,
            //    QInv = requestsCorporateCertificateDto.QInv
            //};
            #endregion
            
            Company company = new Company(requestsCorporateCertificateDto.CompanyName);
            company?.InfoKeys?.GerarParDeChaves();


            Employee employee = new Employee(
                    requestsCorporateCertificateDto.EnrollmentEmployee,
                    requestsCorporateCertificateDto.EmployeeFullName,
                    requestsCorporateCertificateDto.SocialSecurityNumberEmployee
                );

            Company = company;
            Employee = employee;
        }
    }
}
