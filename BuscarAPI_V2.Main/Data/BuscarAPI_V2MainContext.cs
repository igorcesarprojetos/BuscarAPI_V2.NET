using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuscarAPI_V2.Domain.Models;

namespace BuscarAPI_V2.Main.Data
{
    public class BuscarAPI_V2MainContext : DbContext
    {
        public BuscarAPI_V2MainContext (DbContextOptions<BuscarAPI_V2MainContext> options)
            : base(options)
        {
        }

        public DbSet<BuscarAPI_V2.Domain.Models.Perfil> Perfil { get; set; } = default!;
    }
}
