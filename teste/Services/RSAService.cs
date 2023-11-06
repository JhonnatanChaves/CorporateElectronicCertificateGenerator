using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace CorporateElectronicCertificateGenerator.Services
{
    public class RSAService
    {

        public RsaKeyParameters? PublicKey { get; private set; }
        public RsaPrivateCrtKeyParameters? PrivateKey { get; private set; }


        /// <summary>
        /// > Gera chaves pública e privada
        /// </summary>
        public void GerarParDeChaves()
        {
            try
            {
                // Crie um gerador de pares de chaves RSA
                RsaKeyPairGenerator generatePairOfKeys = (RsaKeyPairGenerator)GeneratorUtilities.GetKeyPairGenerator("RSA");

                // Inicialize o gerador com parâmetros, incluindo o tamanho da chave (2048 bits)
                generatePairOfKeys.Init(new KeyGenerationParameters(new SecureRandom(), 2048));

                // Gere o par de chaves RSA
                AsymmetricCipherKeyPair keys = generatePairOfKeys.GenerateKeyPair();

                // A chave pública
                RsaKeyParameters publicKey = (RsaKeyParameters) keys.Public;

                // A chave privada
                RsaPrivateCrtKeyParameters privateKey = (RsaPrivateCrtKeyParameters) keys.Private;


                PublicKey = publicKey;
                PrivateKey = privateKey;

                Console.WriteLine("Par de chaves RSA gerado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro: " + ex.Message);
            }
        }
    }
}
