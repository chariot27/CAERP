using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAERP.Application.Interfaces;
using CAERP.Domains.Entities;
using CAERP.Domains.Interfaces;

namespace CAERP.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        public async Task<int> AddAsync(Empresa empresa)
        {
            if (empresa == null) throw new ArgumentNullException(nameof(empresa));

            // Validações de dados
            if (string.IsNullOrEmpty(empresa.Cnpj))
            {
                throw new ArgumentException("CNPJ é obrigatório.");
            }

            return await _empresaRepository.AddAsync(empresa);
        }

        public async Task<Empresa> GetByIdAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("ID inválido.", nameof(id));

            var empresa = await _empresaRepository.GetByIdAsync(id);
            if (empresa == null)
            {
                throw new KeyNotFoundException($"Empresa com o ID {id} não foi encontrada.");
            }

            return empresa;
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            return await _empresaRepository.GetAllAsync();
        }

        public async Task<bool> UpdateAsync(Empresa empresa)
        {
            if (empresa == null) throw new ArgumentNullException(nameof(empresa));

            // Validações de dados
            if (empresa.Id <= 0)
            {
                throw new ArgumentException("ID da empresa é inválido.");
            }

            return await _empresaRepository.UpdateAsync(empresa);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0) throw new ArgumentException("ID inválido.", nameof(id));

            return await _empresaRepository.DeleteAsync(id);
        }
    }
}
