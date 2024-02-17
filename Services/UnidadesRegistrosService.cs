using API.Inspecciones.Interfaces;
using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using System.Security.Claims;

namespace API.Inspecciones.Services
{
    public class UnidadesRegistrosService : IUnidadesRegistrosService
    {
        private readonly Context _context;

        public UnidadesRegistrosService(Context context)
        {
            _context = context;
        }

        public Task Create(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task<UnidadRegistro> Find(string id)
        {
            throw new NotImplementedException();
        }

        public Task<UnidadRegistro> FindSelectorById(string id, string fields)
        {
            throw new NotImplementedException();
        }

        public Task<List<dynamic>> List()
        {
            throw new NotImplementedException();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public Task Update(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }
    }
}
