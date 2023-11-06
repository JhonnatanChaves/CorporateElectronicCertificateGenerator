namespace CorporateElectronicCertificateGenerator.Domain.Models
{
    public class PrivateKeyCompany
    {
        public string? Modulus { get; set; }
        public string? Exponent { get; set; }
        public string? PublicExponent { get; set; }
        public string? PrivateExponent { get; set; }
        public string? P { get; set; }
        public string? Q { get; set; }
        public string? Dp { get; set; }
        public string? Dq { get; set; }
        public string? QInv { get; set; }
    }
}
