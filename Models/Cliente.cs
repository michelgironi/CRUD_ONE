using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRUD_ONE.Models.Interface;

namespace CRUD_ONE.Models
{
    [Table("Clientes")]
    public class Cliente : ICliente
    {
    [Key]
    [Display(Name = "ID")]
    public int IdCliente { get; set; }
    [Required]
    [Display(Name = "Nome")]
    public string Nome { get; set; }
    [Required]
    [StringLength (14, ErrorMessage = "CPF há somente 11 dígitos")]
    [Display(Name = "CPF")]
    public string Cpf { get; set; }
    [Required]
    [Display(Name = "Data de Nascimento")]
    [DisplayFormat (DataFormatString = "{0:dd/MM/yyyy}")]
    public DateTime DataNascimento { get; set; }
    }
}
