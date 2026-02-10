using Microsoft.EntityFrameworkCore;
using MvcCoreEF.Data;
using MvcCoreEF.Models;

namespace MvcCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }
        public async Task< List<Hospital>> GetHospitalesAsync()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return await consulta.ToListAsync();
        }
        public async Task<Hospital> FindHospitalAsync(int idHospital)
        {
            var consulta= from datos in this.context.Hospitales
                          where datos.IdHospital == idHospital
                          select datos;
            //CUANDO BUSCAMOS, SI NO ENCUENTRA ALGO DEBEMOS DEVOLVER NULL
            return await consulta.FirstOrDefaultAsync();
        }
        public async Task CreateHospitalAsync
            (int idHospital, string nombre, string direccion
            ,string telefono, int camas)
        {
            //CREAMOS UN NUEVO MODEL
            Hospital hospital = new Hospital();
            //ASIGNAMOS SUS PROPIEDADES
            hospital.IdHospital = idHospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            //AÑADIMOS NUESTRO OBJETO AL DBSET
            await this.context.Hospitales.AddAsync(hospital);
            //GUARDAMOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }
        public async Task DeleteHospitalAsync(int idHospital)
        {
            //BUSCAMOS EL HOSPITAL A ELIMINAR
            Hospital hospital = await this.FindHospitalAsync(idHospital);
            this.context.Hospitales.Remove(hospital);
            //GUARDAMOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }
        public async Task UpdateHospitalAsync
            (int idHospital, string nombre, string direccion
            , string telefono, int camas)
        {

            //BUSCAMOS EL OBJETO A MODIFICAR
            Hospital hospital= await this.FindHospitalAsync (idHospital);
            //MODIFICAMOS TODAS SUS PROPIEDADES, EXCEPTO SU [Key]
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            //NO TENEMOS NINGUN METODO PARA REALIZAR UPDATE
            //DENTRO DE LAS COLECCIONES
            //GUARDAMOS EN LA BASE DE DATOS
            await this.context.SaveChangesAsync();
        }
    }
}
