using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using System.IO;

namespace CorporateElectronicCertificateGenerator.Services
{
    public class X509Generete
    {//Company company, Employee employee
        public bool GerarCertificado(CertificateGenerator certificateGenerator)
        {
            try
            {
                RSAService rsaService = new RSAService();
            
                string certificatePath = @"C:\Users\Jhonnatan\Desktop\teste\teste\Certificates\" + certificateGenerator?.Employee?.Enrollment + ".cer";

                // Crie um certificado X.509 usando a chave pública
                rsaService.GerarParDeChaves();
                X509Certificate certificate = GenerateX509Certificate(rsaService.PublicKey, certificateGenerator);

                // Salve o certificado em um arquivo
                SaveCertificateToFile(certificate, certificatePath);

                Console.WriteLine("Certificado X.509 gerado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
                return false;
            }
        }

        static X509Certificate GenerateX509Certificate(RsaKeyParameters? publicKey, CertificateGenerator certificateGenerator)
        {
            // Crie um gerador de certificado X.509
            X509V3CertificateGenerator certGenerator = new X509V3CertificateGenerator();

            // Configure as informações do titular (pode ser personalizado)
            X509Name subjectName = new X509Name($"CN={certificateGenerator?.Employee?.FullName}");
            certGenerator.SetSubjectDN(subjectName);

            // Configure as informações do emissor (pode ser personalizado)
            X509Name issuerName = new X509Name($"CN={certificateGenerator?.Company?.Name}");
            certGenerator.SetIssuerDN(issuerName);

            // Configure o número de série do certificado
            BigInteger serialNumber = BigInteger.ProbablePrime(120, new SecureRandom());
            certGenerator.SetSerialNumber(serialNumber);

            // Configure a data de início e de expiração do certificado
            DateTime startDate = DateTime.UtcNow;
            certGenerator.SetNotBefore(startDate);
            DateTime endDate = startDate.AddYears(1); // Certificado válido por 1 ano
            certGenerator.SetNotAfter(endDate);

            // Configure a chave pública no certificado
            certGenerator.SetPublicKey(publicKey);


            // Crie e retorne o certificado X.509
            //Essa assinatura deve ser mudada para a da empresa emissora              
            RsaPrivateCrtKeyParameters? rsaPrivateCrtKeyParameters = certificateGenerator?.Company?.InfoKeys?.PrivateKey;
            Asn1SignatureFactory signatureFactory = new Asn1SignatureFactory("SHA256WithRSA", rsaPrivateCrtKeyParameters);
            X509Certificate certificate = certGenerator.Generate(signatureFactory);

            return certificate;
        }

        private static void SaveCertificateToFile(X509Certificate certificate, string fileName)
        {
            // Salve o certificado em um arquivo no formato DER
            File.WriteAllBytes(fileName, certificate.GetEncoded());
        }
    }
}
