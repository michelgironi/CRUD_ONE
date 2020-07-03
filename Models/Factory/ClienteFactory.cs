using CRUD_ONE.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ONE.Models.Factory
{
    public static class ClienteFactory
    {
        public static ICliente Criar(int idcliente = 0, string nome = "", string cpf = "", DateTime? datanascimento = null)
        {
            return new Cliente() {
                IdCliente = idcliente,
                Nome = nome,
                Cpf = cpf,
                DataNascimento = datanascimento ?? DateTime.MinValue
            };
        }

        public static ICliente Criar(Cliente cliente)
        {
            return new Cliente()
            {
                IdCliente = cliente.IdCliente,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                DataNascimento = cliente.DataNascimento
            };
        }
    }
}
