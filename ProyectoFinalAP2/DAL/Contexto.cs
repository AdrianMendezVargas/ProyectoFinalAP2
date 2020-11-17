using Microsoft.EntityFrameworkCore;
using ProyectoFinalAP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAP2.DAL
{
    public class Contexto :DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContext)
        {
            dbContext.UseSqlite(@"Data Source = Data\ProyectoFinalAP2.db");
        }
    }
}
