using API.Inspecciones.Interfaces;
using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Workcube.Libraries;

namespace API.Inspecciones.Services
{
    public class InspeccionesService : IInspeccionesService
    {
        private readonly Context _context;

        public InspeccionesService(Context context)
        {
            _context = context;
        }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            if (!await HttpReq.GetPrivilegio("INSPECCIONES_CREATE", user)) { throw new AppException(ExceptionMessage.SESSION_003); };

            var objTransaction  = _context.Database.BeginTransaction();

            Inspeccion objModel = new Inspeccion();

            objModel.IdInspeccion   = Guid.NewGuid().ToString();
            objModel.Folio          = Globals.ToString(data.folio);
            objModel.Name           = Globals.ToString(data.name);    
            objModel.DisplayName    = Globals.ToString(data.displayName);
            objModel.Correo         = Globals.ToString(data.correo);

            _context.Inspecciones.Add(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task<Inspeccion> Find(string id)
        {
            return await _context.Inspecciones.FindAsync(id);
        }

        public async Task<Inspeccion> FindSelectorById(string id, string fields)
        {
            return await _context.Inspecciones.Where(x => x.IdInspeccion == id).Select(Globals.BuildSelector<Inspeccion, Inspeccion>(fields)).FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Inspecciones.AsNoTracking()
                            .Where(x => !x.Deleted)
                            .OrderBy(x => x.CreatedFecha)
                            .Select(x => new
                            {
                                IdInspeccion    = x.IdInspeccion,
                                Folio           = x.Folio,
                                Name            = x.Name
                            })
                            .ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            if (!await HttpReq.GetPrivilegio("INSPECCIONES_UPDATE", user)) { throw new AppException(ExceptionMessage.SESSION_003); };

            var objTransaction = _context.Database.BeginTransaction();

            // ACTUALIZAR INSPECCION
            string idInspeccion = Globals.ParseGuid(data.idInspeccion);

            Inspeccion objModel = await Find(idInspeccion);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la inspección."); }

            objModel.Folio          = Globals.ToString(data.folio);
            objModel.Name           = Globals.ToString(data.name);
            objModel.DisplayName    = Globals.ToString(data.displayName);
            objModel.Correo         = Globals.ToString(data.correo);

            _context.Inspecciones.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
