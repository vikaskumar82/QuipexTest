
using CompanyProject.Models;

namespace CompanyProject.Interface
{
    public interface ICompanyRepository
    {
        List<Company> GetCompanies();

       Company GetCompany(int companyId);

        bool CompanyExists (int companyId);

        bool CreateCompany(Company company);

        bool save();

        bool CompanyExistsByISIN(string iSIN);
    }
}
