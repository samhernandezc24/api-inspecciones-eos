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
            var objTransaction  = _context.Database.BeginTransaction();
            var displayName     = Globals.ToUpper($"Check List {data.name}");

            // GUARDAR INSPECCION
            Inspeccion objModel = new Inspeccion();


            objModel.IdInspeccion   = Guid.NewGuid().ToString();
            objModel.Folio          = Globals.ToUpper(data.folio);
            objModel.Name           = Globals.ToUpper(data.name);    
            objModel.DisplayName    = displayName;
            //objModel.Correo         = Globals.ToString(data.correo);
            objModel.SetCreated(Globals.GetUser(user));

            _context.Inspecciones.Add(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            // ELIMINAR INSPECCION
            string idInspeccion = Globals.ParseGuid(data.idInspeccion);
            Inspeccion objModel = await Find(idInspeccion);

            if (objModel.Deleted) { throw new ArgumentException("La inspección ya fue eliminada anteriormente"); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Inspecciones.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Inspeccion> Find(string id)
        {
            return await _context.Inspecciones.FindAsync(id);
        }

        public async Task<Inspeccion> FindSelectorById(string id, string fields)
        {
            return await _context.Inspecciones.AsNoTracking().Where(x => x.IdInspeccion == id)
                            .Select(Globals.BuildSelector<Inspeccion, Inspeccion>(fields)).FirstOrDefaultAsync();
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
            var objTransaction  = _context.Database.BeginTransaction();
            var displayName     = Globals.ToUpper($"Check List {data.name}");

            // ACTUALIZAR INSPECCION
            string idInspeccion = Globals.ParseGuid(data.idInspeccion);

            Inspeccion objModel = await Find(idInspeccion);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la inspección."); }

            objModel.Folio          = Globals.ToUpper(data.folio);
            objModel.Name           = Globals.ToUpper(data.name);
            objModel.DisplayName    = displayName;
            //objModel.Correo         = Globals.ToString(data.correo);

            _context.Inspecciones.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
