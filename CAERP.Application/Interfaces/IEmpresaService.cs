using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CAERP.Domains.Entities;

namespace CAERP.Application.Interfaces
{
    public interface IEmpresaService
    {
        Task<int> AddAsync(Empresa empresa);
        Task<Empresa> GetByIdAsync(int id);
        Task<IEnumerable<Empresa>> GetAllAsync();
        Task<bool> UpdateAsync(Empresa empresa);
        Task<bool> DeleteAsync(int id);
    }
}
