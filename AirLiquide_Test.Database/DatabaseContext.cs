using AirLiquide_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirLiquide_Test.Database
{
    // dotnet tool install --global dotnet-ef
    public class DatabaseContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
    }
}