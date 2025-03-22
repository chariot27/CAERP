using CAERP.Application.Interfaces;
using CAERP.Domains.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CAERP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost]
        public async Task<ActionResult<Empresa>> AddAsync(Empresa empresa)
        {
            var empresaId = await _empresaService.AddAsync(empresa);

            if (empresaId <= 0)
            {
                return BadRequest("Falha ao criar a empresa.");
            }

            empresa.Id = empresaId; 
            return Ok(empresa); 
        }
    }
}
