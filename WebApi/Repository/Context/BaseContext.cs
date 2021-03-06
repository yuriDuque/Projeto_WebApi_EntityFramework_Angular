﻿using Repository.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Repository.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext() : base("name=TesteEntity")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a plularização padrão da nomeclatura das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Configura o formato que um decimal será criado em uma tabela 
            modelBuilder.Properties<decimal>().Configure(x => x.HasPrecision(16, 4));
            modelBuilder.Properties<decimal?>().Configure(x => x.HasPrecision(16, 4));

            base.OnModelCreating(modelBuilder);

            Aluno.Map(modelBuilder);
        }

        public DbSet<Aluno> alunos{ get; set; }
    }
}
