using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAERP.Domains.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string? InscricaoMunicipal { get; set; }
        public string? NomeFantasia { get; set; }
        public string? RazaoSocial { get; set; }
        public string? Cnpj { get; set; }

    }
}
