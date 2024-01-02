using CompanyProject.Data;
using CompanyProject.Interface;
using CompanyProject.Models;
using CompanyProject.Repository;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CompanyProject.Controllers
{
    [Route("api/company")]
    [ApiController]
    public class CompanyController : Controller
    {
        protected readonly ICompanyRepository _companyreopsitory;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyreopsitory= companyRepository;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies= _companyreopsitory.GetCompanies();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(companies);
        }

        [HttpGet("{companyId}")]
        public IActionResult GetCompany(int companyId)
        {
            if (!_companyreopsitory.CompanyExists(companyId))
                return NotFound();

            var company = _companyreopsitory.GetCompany(companyId);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(company);
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody]Company company)
        {

            if (company == null)
                return BadRequest(ModelState);

            bool validationFails = _companyreopsitory.CompanyExistsByISIN(company.ISIN);


            if (!validationFails)
            {
                var comp = _companyreopsitory.CreateCompany(company);

                //return CreatedAtAction(nameof(GetCompany), new {controller = "company"}, comp);
                return Ok(comp);
            }
            else
            {
                return Ok("Company already exists");
            }
        }
    }
}
