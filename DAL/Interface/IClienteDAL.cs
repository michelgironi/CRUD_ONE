using CRUD_ONE.Models;
using CRUD_ONE.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ONE.DAL.Interface
{
    public interface IClienteDAL 
    {
        IEnumerable<ICliente> GetAllClientes();
        void AddCliente(ICliente cliente);
        void UpdateCliente(ICliente cliente);
        ICliente GetCliente(int? id);
        void DeleteCliente(int? id);
    }
}
