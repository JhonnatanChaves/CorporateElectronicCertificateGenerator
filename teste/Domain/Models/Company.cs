using CorporateElectronicCertificateGenerator.Domain.Models;
using CorporateElectronicCertificateGenerator.Services;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Org.BouncyCastle.Crypto.Operators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System.Text.Json.Serialization;

namespace teste.Domain.Models
{
    public class Company
    {
        public string? Name { get; set; }

        public RSAService? InfoKeys { get; private set; }
        public Company(string? name)
        {            
            Name = name;
            InfoKeys = new RSAService();
        }

        #region Em análise
        //public void BuildKey(PrivateKeyCompany? privateKeyCompany)
        //{
        //    PrivateKeyCompany privateKeyResult = new PrivateKeyCompany();

        //    privateKeyResult.Modulus = privateKeyCompany?.Modulus;
        //    privateKeyResult.Exponent = privateKeyCompany?.Exponent;
        //    privateKeyResult.PublicExponent = privateKeyCompany?.PublicExponent;
        //    privateKeyResult.PrivateExponent = privateKeyCompany?.PrivateExponent;
        //    privateKeyResult.P = privateKeyCompany?.P;
        //    privateKeyResult.Q = privateKeyCompany?.Q;
        //    privateKeyResult.Dp = privateKeyCompany?.Dp;
        //    privateKeyResult.Dq = privateKeyCompany?.Dq;
        //    privateKeyResult.QInv = privateKeyCompany?.QInv;

        //    PrivateKeyCompany = privateKeyResult;
        //}

        //public RsaPrivateCrtKeyParameters Signature()
        //{
        //    var modulos = new BigInteger(PrivateKeyCompany?.Modulus);
        //    var exponent = new BigInteger(PrivateKeyCompany?.Exponent);
        //    var publicExponent = new BigInteger(PrivateKeyCompany?.PublicExponent);
        //    var privateExponent = new BigInteger(PrivateKeyCompany?.PrivateExponent);
        //    var p = new BigInteger(PrivateKeyCompany?.P);
        //    var q = new BigInteger(PrivateKeyCompany?.Q);
        //    var dp = new BigInteger(PrivateKeyCompany?.Dp);
        //    var dq = new BigInteger(PrivateKeyCompany?.Dq);
        //    var qinv = new BigInteger(PrivateKeyCompany?.QInv);

        //    RsaPrivateCrtKeyParameters rsaPrivateCrtKeyParameters =
        //        new RsaPrivateCrtKeyParameters(modulos, publicExponent, privateExponent, p, q, dp, dq, qinv);

        //    return rsaPrivateCrtKeyParameters;
        //}

        #endregion
    }
}
