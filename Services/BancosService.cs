using System.Security.Claims;
using API.Inspecciones.Models;
using Workcube.Interfaces;

namespace API.Inspecciones.Services
{
    public class BancosService : IGlobal<CategoriaItem>
    {
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

        public Task<CategoriaItem> Find(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoriaItem> FindSelectorById(string id, string fields)
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
