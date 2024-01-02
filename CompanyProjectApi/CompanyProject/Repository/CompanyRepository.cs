
using CompanyProject.Data;
using CompanyProject.Interface;
using CompanyProject.Models;

namespace CompanyProject.Repository
{
    public class CompanyRepository :ICompanyRepository
    {
        private ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context= context;
        }
        public Company GetCompany(int id)
        {
            return _context.Companies.Where(c => c.Id == id).FirstOrDefault();
        }
        public List<Company> GetCompanies()
        {
            return _context.Companies.OrderBy(c => c.Id).ToList();
        }

        public bool CompanyExists(int companyId)
        {
            return _context.Companies.Any(c => c.Id == companyId);
        }

        public bool CreateCompany(Company company)
        {
            var c = new Company()
            {
               Name = company.Name,
               Exchange= company.Exchange,
               Ticker= company.Ticker,
               ISIN= company.ISIN,
               Website = company.Website,
            };
            _context.Companies.Add(c);
            return save();
        }

        public bool save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool CompanyExistsByISIN(string iSIN)
        {
            return _context.Companies.Any(c => c.ISIN ==  iSIN);
        }
    }
}
