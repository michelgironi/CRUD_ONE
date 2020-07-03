using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ONE.Models.Interface
{
    public interface ICliente
    {
        int IdCliente { get; set; }
        string Nome { get; set; }
        string Cpf { get; set; }
        DateTime DataNascimento { get; set; }
    }
}
