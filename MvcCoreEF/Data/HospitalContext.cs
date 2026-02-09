using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Models;

namespace MvcCoreEF.Data
{
    public class HospitalContext:DbContext
    {
        //EL CONSTRUCTOR RECIBIRA SIEMPRE LAS OPCIONES PARA ESTE CONTEXTO
        //LA CLASE QUE RECIBE ES DbContextOptions<Context>
        //ESTAS option DEBEMOS ENVIARLAS A LA CLASE SUPER/BASE DEL DbContext
        public HospitalContext(DbContextOptions<HospitalContext> options):base(options)
        {}
        //DEBEMOS TENE UNA COLECCION POR CADA MODEL
        //DICHA COLECCION DEBE SER DE TIPO DbSet<T>
        public DbSet<Hospital> Hospitales { get; set; }
    }
}
