using CRUD_ONE.DAL.Interface;
using CRUD_ONE.Models;
using CRUD_ONE.Models.Factory;
using CRUD_ONE.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_ONE.DAL
{
        public class ClienteDal : IClienteDAL
        {
        string connectionString = @"Data Source=DESKTOP-KADK7IS;Initial Catalog=Cadastro;Integrated Security=True;";

        public IEnumerable<Cliente> GetAllClientes()
        {
            var lstCliente = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT idCliente, Nome, Cpf, dataNascimento FROM dbo.Clientes", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente cliente = (Cliente)ClienteFactory.Criar(Convert.ToInt32(rdr["idCliente"]), rdr["Nome"].ToString(), rdr["Cpf"].ToString(), Convert.ToDateTime(rdr["dataNascimento"]));
                 
                    lstCliente.Add(cliente);
                }
                con.Close();
            }
            return lstCliente;
        }

        public void AddCliente(ICliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "INSERT INTO dbo.Clientes (Nome,Cpf,dataNascimento) VALUES (@Nome, @Cpf, @dataNascimento)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@dataNascimento", cliente.dataNascimento);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCliente(ICliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "UPDATE dbo.Clientes SET Nome = @Nome, Cpf = @Cpf, dataNascimento = @dataNascimento WHERE idCliente = @idCliente";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idCliente", cliente.idCliente);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@Cpf", cliente.Cpf);
                cmd.Parameters.AddWithValue("@dataNascimento", cliente.dataNascimento);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ICliente GetCliente(int? id)
        {
            ICliente cliente = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM dbo.Clientes WHERE idCliente = " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cliente = ClienteFactory.Criar(Convert.ToInt32(rdr["idCliente"]), rdr["Nome"].ToString(), rdr["Cpf"].ToString(), Convert.ToDateTime(rdr["dataNascimento"]));
                }
            }
            return cliente;
        }

        public void DeleteCliente(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "DELETE FROM dbo.Clientes WHERE idCliente = @idCliente";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@idCliente", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
