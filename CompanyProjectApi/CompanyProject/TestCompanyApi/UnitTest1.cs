using CompanyProject.Data;
using CompanyProject.Interface;
using CompanyProject.Models;
using CompanyProject.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Xml;

namespace TestCompanyApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            //Arrange
            //Mocking (FAKING) - Moq

            //Mock<ICompanyRepository> repoMock = new Mock<ICompanyRepository>();
            var mockContext = new Mock<ApplicationDbContext>();
            var repository = new CompanyRepository(mockContext.Object);
            var testData = new Company {Id = 1, Exchange = "EX", ISIN = "1234", Name = "ABC Pharma", Website = "www"};

            //ACT
            repository.CreateCompany(testData);
            var result = repository.CompanyExistsByISIN("1234");

            Assert.IsTrue(result);

        }
    }
}