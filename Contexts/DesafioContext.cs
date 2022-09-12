using Desafio_EF.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Desafio_EF.Contexts
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options)
        {
        }
        // Acesso ao banco de dados
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Consulta> Consulta { get; set; } // Classe de relacionamento entre Médico e Paciente

        ///// <summary>
        ///// Converter o Enum para String e salvar o nome do enum no banco
        ///// </summary>
        ///// <param name="modelBuilder"></param>
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<TipoUsuario>()
        //        .Property(e => e.Tipo)
        //        .HasConversion<string>();
        //}
    }
}
