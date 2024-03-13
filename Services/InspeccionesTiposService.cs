using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Workcube.Interfaces;
using Workcube.Libraries;

namespace API.Inspecciones.Services
{
    public class InspeccionesTiposService : IGlobal<InspeccionTipo>
    {
        private readonly Context _context;

        public InspeccionesTiposService(Context context)
        {
            _context = context;
        }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction  = _context.Database.BeginTransaction();
            var displayName     = Globals.ToUpper($"Check List {data.name}");

            // GUARDAR TIPO DE INSPECCION
            InspeccionTipo objModel = new InspeccionTipo();
            objModel.IdInspeccionTipo   = Guid.NewGuid().ToString();
            objModel.Folio              = Globals.ToUpper(data.folio);
            objModel.Name               = Globals.ToUpper(data.name);    
            objModel.DisplayName        = displayName;
            objModel.Correo             = Globals.ToString(data.correo) ?? "";
            objModel.SetCreated(Globals.GetUser(user));

            _context.InspeccionesTipos.Add(objModel);
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

            // ELIMINAR TIPO DE INSPECCION
            string idInspeccionTipo     = Globals.ParseGuid(data.idInspeccionTipo);
            InspeccionTipo objModel     = await Find(idInspeccionTipo);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado el tipo de inspección solicitado."); }
            if (objModel.Deleted) { throw new ArgumentException("El tipo de inspección ya fue eliminado anteriormente."); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.InspeccionesTipos.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<InspeccionTipo> Find(string id)
        {
            return await _context.InspeccionesTipos.FindAsync(id);
        }

        public async Task<InspeccionTipo> FindSelectorById(string id, string fields)
        {
            return await _context.InspeccionesTipos.AsNoTracking().Where(x => x.IdInspeccionTipo == id).Select(Globals.BuildSelector<InspeccionTipo, InspeccionTipo>(fields)).FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.InspeccionesTipos.AsNoTracking().Where(x => !x.Deleted).OrderByDescending(x => x.CreatedFecha).ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction  = _context.Database.BeginTransaction();
            var displayName     = Globals.ToUpper($"Check List {data.name}");

            // ACTUALIZAR TIPO DE INSPECCION
            string idInspeccionTipo = Globals.ParseGuid(data.idInspeccionTipo);

            InspeccionTipo objModel = await Find(idInspeccionTipo);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado el tipo de inspección solicitado."); }
            if (objModel.Deleted) { throw new ArgumentException("El tipo de inspección ya fue eliminado anteriormente."); }

            objModel.Folio          = Globals.ToUpper(data.folio);
            objModel.Name           = Globals.ToUpper(data.name);
            objModel.DisplayName    = displayName;
            objModel.Correo         = Globals.ToString(data.correo) ?? "";
            objModel.SetUpdated(Globals.GetUser(user));

            _context.InspeccionesTipos.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
