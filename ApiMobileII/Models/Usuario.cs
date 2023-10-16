using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobileII.Models
{
    [Table("Usuario")]
    public partial class Usuario
    {

        public Usuario()
        {
            Enderecos = new HashSet<Endereco>();
            Revisaos = new HashSet<Revisao>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("senha")]
        public string? Senha { get; set; }

        [Column("dataNascimento", TypeName = "datetime")]
        public DateTime DataNascimento { get; set; }

        [Column("rg")]
        public string? Rg { get; set; }

        [Column("cpf")]
        public string? Cpf { get; set; }

        [Column("cnpj")]
        public bool Ativo { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<Endereco> Enderecos { get; set; }

        [InverseProperty("Usuario")]
        public virtual ICollection<Revisao> Revisaos { get; set; }
    }
}
