using CorporateElectronicCertificateGenerator.Dtos;
using CorporateElectronicCertificateGenerator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using teste.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teste.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateGeneratorController : ControllerBase
    {
        // GET: api/<CertificateGeneratorController>

        [HttpPost]
        public IActionResult RequestCertificateGeneration([FromBody] RequestsCorporateCertificateDto requestsCorporateCertificateDto)
        {
            X509Generete x509Generete = new X509Generete();              
            CertificateGenerator certificateGenerator = new CertificateGenerator();

            certificateGenerator.BuildFields(requestsCorporateCertificateDto);

            if(certificateGenerator?.Company == null || certificateGenerator?.Employee == null)
                return BadRequest("Preencha todos os dados de Company e Employee");

            var checker = x509Generete.GerarCertificado(certificateGenerator);
            if (checker == false) 
                return BadRequest("Certificado não gerado");
            else
                return Ok("Certificado gerado com sucesso");

        }

        #region outrosMetodos
        //[HttpPost]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CertificateGeneratorController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<CertificateGeneratorController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CertificateGeneratorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CertificateGeneratorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
        #endregion
    }
}
