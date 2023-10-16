﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMobileII.Models
{
    [Table("Revisao")]
    public partial class Revisao
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao")]
        public string? Descricao { get; set; }
        [Column("dataRevisao", TypeName = "datetime")]
        public DateTime DataRevisao { get; set; }
        [Column("carro_id")]
        public int? CarroId { get; set; }
        [Column("usuario_id")]
        public int? UsuarioId { get; set; }
        [Column("status")]
        [StringLength(100)]
        public string Status { get; set; } = null!;

        [ForeignKey("CarroId")]
        [InverseProperty("Revisaos")]
        public virtual Carro? Carro { get; set; }
        [ForeignKey("UsuarioId")]
        [InverseProperty("Revisaos")]
        public virtual Usuario? Usuario { get; set; }
    }
}
