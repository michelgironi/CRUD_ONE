using CRUD_ONE.DAL.Interface;
using CRUD_ONE.Models;
using CRUD_ONE.Models.Factory;
using CRUD_ONE.Models.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CRUD_ONE.Context;

namespace CRUD_ONE.DAL
{
    public class ClienteDal :  IClienteDAL  
        {
        //string connectionString = @"Data Source=DESKTOP-KADK7IS;Initial Catalog=Cadastro;Integrated Security=True;";

        private ConnectionStrings ConnectionStrings { get; set; }
        

        public ClienteDal(IOptions<ConnectionStrings> connectionStrings) 
        {
            ConnectionStrings = connectionStrings.Value;
        }


        public IEnumerable<ICliente> GetAllClientes()
        {
            var lstCliente = new List<ICliente>();

            using (var db = new ClienteContext(ConnectionStrings))
            {
                lstCliente = db.Clientes.ToList().ConvertAll(new Converter<Cliente, ICliente>(ClienteFactory.Criar));
            }

            return lstCliente.ToList();
        }

        public void AddCliente(ICliente cliente)
        {
            using (var db = new ClienteContext(ConnectionStrings))
            {
                db.Clientes.Add((Cliente)cliente);
                db.SaveChanges();
            }
        }

        public void UpdateCliente(ICliente cliente)
        {
            
            using (var db = new ClienteContext(ConnectionStrings))
            {
                var clientedb = db.Clientes.Where(b => b.IdCliente == cliente.IdCliente).FirstOrDefault();
                if (clientedb != null)
                {
                    clientedb.Nome = cliente.Nome;
                    clientedb.Cpf = cliente.Cpf;
                    clientedb.DataNascimento = cliente.DataNascimento;
                    db.SaveChanges();
                }
            }
        }

        public ICliente GetCliente(int? id)
        {
            ICliente cliente = null;

            using (var db = new ClienteContext(ConnectionStrings))
            {
                cliente = db.Clientes.Where(b => b.IdCliente == id).FirstOrDefault();
            }
            return cliente;
        }

        public void DeleteCliente(int? id)
        {
            var cliente = GetCliente(id);
            using (var db = new ClienteContext(ConnectionStrings))
            {
                db.Clientes.Remove((Cliente)cliente);
                db.SaveChanges();
            }
        }
    }
}
