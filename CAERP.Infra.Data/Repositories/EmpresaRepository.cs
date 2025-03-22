using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using CAERP.Domains.Entities;
using CAERP.Domains.Interfaces;
using Dapper;

namespace CAERP.Infra.Data.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly IDatabaseConnection _databaseConnection;

        public EmpresaRepository(IDatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task<int> AddAsync(Empresa empresa)
        {
            const string query = @"
                INSERT INTO empresas (codigo, inscricao_municipal, nome_fantasia, razao_social, cnpj)
                VALUES (@Codigo, @InscricaoMunicipal, @NomeFantasia, @RazaoSocial, @Cnpj);
                SELECT LAST_INSERT_ID();";  // Retorna o ID da empresa inserida

            _databaseConnection.Open();
            return await _databaseConnection.Connection.QuerySingleAsync<int>(query, empresa);
        }

        public async Task<Empresa> GetByIdAsync(int id)
        {
            const string query = "SELECT * FROM empresas WHERE id = @Id;";

            _databaseConnection.Open();
            return await _databaseConnection.Connection.QueryFirstOrDefaultAsync<Empresa>(query, new { Id = id });
        }

        public async Task<IEnumerable<Empresa>> GetAllAsync()
        {
            const string query = "SELECT * FROM empresas;";

            _databaseConnection.Open();
            return await _databaseConnection.Connection.QueryAsync<Empresa>(query);
        }

        public async Task<bool> UpdateAsync(Empresa empresa)
        {
            const string query = @"
                UPDATE empresas
                SET codigo = @Codigo, inscricao_municipal = @InscricaoMunicipal, nome_fantasia = @NomeFantasia,
                    razao_social = @RazaoSocial, cnpj = @Cnpj
                WHERE id = @Id;";

            _databaseConnection.Open();
            var rowsAffected = await _databaseConnection.Connection.ExecuteAsync(query, empresa);
            return rowsAffected > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            const string query = "DELETE FROM empresas WHERE id = @Id;";

            _databaseConnection.Open();
            var rowsAffected = await _databaseConnection.Connection.ExecuteAsync(query, new { Id = id });
            return rowsAffected > 0;
        }
    }
}
