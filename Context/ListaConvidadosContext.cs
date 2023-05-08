using ListaConvidados.Controllers;
using Microsoft.EntityFrameworkCore;
using ListaConvidados.Models;
using ListaConvidados.Enumerators;

namespace ListaConvidados.Context
{
    public class ListaConvidadosContext : DbContext
    {
        public ListaConvidadosContext(DbContextOptions<ListaConvidadosContext> options) : base(options)
        {

        }

        public DbSet<ConvidadosModel> TodosConvidados { get; set; }       
    }
}
