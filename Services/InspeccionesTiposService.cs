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

        public InspeccionesTiposService(Context context) { _context = context; }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            string inspeccionTipoDisplayName    = Globals.ToUpper($"Check List {data.name}");
            string inspeccionTipoFolio          = Globals.ToUpper(data.folio);
            string inspeccionTipoName           = Globals.ToUpper(data.name);

            bool findInspeccionTipoFolio = await _context.InspeccionesTipos.AnyAsync(x => x.Folio.ToUpper() == inspeccionTipoFolio && !x.Deleted);
            bool findInspeccionTipoName  = await _context.InspeccionesTipos.AnyAsync(x => x.Name.ToUpper() == inspeccionTipoName && !x.Deleted);

            if (findInspeccionTipoFolio) { throw new ArgumentException("Ya existe un tipo de inspección con este folio."); }
            if (findInspeccionTipoName) { throw new ArgumentException("Ya existe un tipo de inspección con este nombre."); }

            // GUARDAR TIPO DE INSPECCION
            InspeccionTipo objModel = new InspeccionTipo();
            objModel.IdInspeccionTipo   = Guid.NewGuid().ToString();
            objModel.Folio              = inspeccionTipoFolio;
            objModel.Name               = inspeccionTipoName;    
            objModel.DisplayName        = inspeccionTipoDisplayName;
            objModel.Correo             = Globals.ToString(data.correo) ?? "";
            objModel.Orden              = Globals.ParseInt(data.orden);
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
            string idInspeccionTipo = Globals.ParseGuid(data.idInspeccionTipo);

            InspeccionTipo objModel = await Find(idInspeccionTipo);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado el tipo de inspección solicitado."); }
            if (objModel.Deleted) { throw new ArgumentException("El tipo de inspección ya fue eliminado anteriormente."); }

            objModel.Deleted    = true;
            objModel.Orden      = 0;
            objModel.SetUpdated(Globals.GetUser(user));
            _context.SaveChanges();

            var lstInspeccionesTipos = _context.InspeccionesTipos.OrderBy(x => x.Orden).Where(x => !x.Deleted).ToList();

            int orden = 1;
            foreach (var item in lstInspeccionesTipos)
            {
                item.Orden = orden;
                orden++;
            }

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
            return await _context.InspeccionesTipos.AsNoTracking().Where(x => x.IdInspeccionTipo == id)
                            .Select(Globals.BuildSelector<InspeccionTipo, InspeccionTipo>(fields)).FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.InspeccionesTipos
                                 .AsNoTracking()
                                 .Where(x => !x.Deleted)
                                 .OrderBy(x => x.Orden)
                                 .Select(x => new
                                 {
                                     IdInspeccionTipo   = x.IdInspeccionTipo,
                                     Folio              = x.Folio,
                                     Name               = x.Name,
                                     Correo             = x.Correo,
                                     Orden              = x.Orden,
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

            // ACTUALIZAR TIPO DE INSPECCION
            string idInspeccionTipo      = Globals.ParseGuid(data.idInspeccionTipo);
            string inspeccionTipoFolio   = Globals.ToUpper(data.folio);
            string inspeccionTipoName    = Globals.ToUpper(data.name);
            string inspeccionDisplayName = Globals.ToUpper($"Check List {inspeccionTipoName}");

            InspeccionTipo objModel = await Find(idInspeccionTipo);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado el tipo de inspección solicitado."); }
            if (objModel.Deleted) { throw new ArgumentException("El tipo de inspección ya fue eliminado anteriormente."); }

            bool isFolioModified    = !string.Equals(objModel.Folio, inspeccionTipoFolio, StringComparison.OrdinalIgnoreCase);
            bool isNameModified     = !string.Equals(objModel.Name, inspeccionTipoName, StringComparison.OrdinalIgnoreCase);

            if (isFolioModified || isNameModified )
            {
                bool findInspeccionTipoFolio = await _context.InspeccionesTipos
                    .AnyAsync(x => x.Folio.ToUpper() == inspeccionTipoFolio && x.IdInspeccionTipo != idInspeccionTipo && !x.Deleted);

                bool findInspeccionTipoName  = await _context.InspeccionesTipos
                   .AnyAsync(x => x.Name.ToUpper() == inspeccionTipoName && x.IdInspeccionTipo != idInspeccionTipo && !x.Deleted);

                if (findInspeccionTipoFolio) { throw new ArgumentException("Ya existe un tipo de inspección con el mismo folio."); }
                if (findInspeccionTipoName) { throw new ArgumentException("Ya existe un tipo de inspección con el mismo nombre."); }
            }                                                     

            objModel.Folio          = inspeccionTipoFolio;
            objModel.Name           = inspeccionTipoName;
            objModel.DisplayName    = inspeccionDisplayName;
            objModel.Correo         = Globals.ToString(data.correo) ?? "";
            objModel.SetUpdated(Globals.GetUser(user));

            _context.InspeccionesTipos.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task UpdateOrden(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            // ACTUALIZAR ORDENAMIENTO DE INSPECCIONES TIPOS
            var lstInspeccionesTipos = _context.InspeccionesTipos.ToList();

            List<InspeccionTipo> updateData = new List<InspeccionTipo>();
            int orden = 1;
            foreach (var item in data.inspeccionesTipos)
            {
                string idInspeccionTipo = Globals.ParseGuid(item.idInspeccionTipo);
                var objInspeccionTipo   = lstInspeccionesTipos.Find(x => x.IdInspeccionTipo == idInspeccionTipo);

                if (objInspeccionTipo != null)
                {
                    objInspeccionTipo.Orden = orden;
                    updateData.Add(objInspeccionTipo);
                }
                orden++;
            }

            _context.InspeccionesTipos.UpdateRange(updateData);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
