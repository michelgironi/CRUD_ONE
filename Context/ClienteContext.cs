using CRUD_ONE.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ONE.Context
{
    public class ClienteContext : DbContext
    {
        private ConnectionStrings ConnectionStrings { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public ClienteContext(ConnectionStrings connectionStrings)
        {
            ConnectionStrings = connectionStrings;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionStrings.Cadastro);
        }


    }
}
