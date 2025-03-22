using NUnit.Framework;
using Moq;
using Microsoft.AspNetCore.Mvc;
using CAERP.Api.Controllers;
using CAERP.Domains.Entities;
using CAERP.Application.Interfaces;
using System.Threading.Tasks;

namespace CAERP.Tests.Controllers
{
    [TestFixture]
    public class EmpresaControllerTests
    {
        private Mock<IEmpresaService> _mockEmpresaService;
        private EmpresaController _empresaController;

        [SetUp]
        public void SetUp()
        {
            _mockEmpresaService = new Mock<IEmpresaService>();
            _empresaController = new EmpresaController(_mockEmpresaService.Object);
        }

        [Test]
        public async Task AddAsync_Returns_Ok_And_Empresa_When_Valid_Empresa()
        {
            var empresa = new Empresa
            {
                Id = 1,
                Codigo = 123,
                NomeFantasia = "Empresa Teste",
                RazaoSocial = "Razao Social Teste",
                Cnpj = "12345678000123"
            };

            // Setup para simular a criação de uma empresa
            _mockEmpresaService.Setup(service => service.AddAsync(It.IsAny<Empresa>())).ReturnsAsync(empresa.Id);

            // Chamada do método AddAsync
            var result = await _empresaController.AddAsync(empresa);

            // Verifica se o resultado é do tipo OkObjectResult (200 OK)
            Assert.That(result.Result, Is.InstanceOf<OkObjectResult>());
            var okResult = (OkObjectResult)result.Result;

            // Verifica o status code
            Assert.AreEqual(200, okResult.StatusCode);

            // Verifica se o corpo da resposta é a empresa adicionada
            Assert.AreEqual(empresa, okResult.Value);
        }
    }
}
