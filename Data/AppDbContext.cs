using Microsoft.EntityFrameworkCore;
using BarberTech.Models;

namespace BarberTech.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}