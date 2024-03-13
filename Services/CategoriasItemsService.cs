using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Workcube.Interfaces;
using Workcube.Libraries;

namespace API.Inspecciones.Services
{
    public class CategoriasItemsService : IGlobal<CategoriaItem>
    {
        private readonly Context _context;

        public CategoriasItemsService(Context context)
        {
            _context = context;
        }
        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            CategoriaItem objModel = new CategoriaItem();

            objModel.IdCategoriaItem        = Guid.NewGuid().ToString();
            objModel.Name                   = Globals.ToString(data.name);
            objModel.FormularioTipo         = Globals.ToString(data.formularioTipo);
            objModel.FormularioValor        = Globals.ToString(data.formularioValor);
            objModel.IdInspeccionTipo       = Globals.ParseGuid(data.idInspeccionTipo);
            objModel.InspeccionTipoName     = Globals.ToString(data.inspeccionTipoName);
            objModel.IdCategoria            = Globals.ParseGuid(data.idCategoria);
            objModel.CategoriaName          = Globals.ToString(data.categoriaName);

            _context.CategoriasItems.Add(objModel);
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

        public async Task<CategoriaItem> Find(string id)
        {
            return await _context.CategoriasItems.FindAsync(id);
        }

        public async Task<CategoriaItem> FindSelectorById(string id, string fields)
        {
            return await _context.CategoriasItems.Where(x => x.IdCategoriaItem == id).Select(Globals.BuildSelector<CategoriaItem, CategoriaItem>(fields)).FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.CategoriasItems.AsNoTracking().Where(x => !x.Deleted).ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListByIdCategoria(string idCategoria)
        {
            return await _context.CategoriasItems.AsNoTracking().Where(x => x.IdCategoria == idCategoria && !x.Deleted).OrderByDescending(x => x.CreatedFecha).ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            // ACTUALIZAR FORMULARIO DE PREGUNTAS
            string idCategoriaItem = Globals.ParseGuid(data.idCategoriaItem);

            CategoriaItem objModel = await Find(idCategoriaItem);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado el formulario de preguntas solicitada."); }
            if (objModel.Deleted) { throw new ArgumentException("El formulario de preguntas ya fue eliminado anteriormente."); }

            objModel.Name               = Globals.ToString(data.name);
            objModel.FormularioTipo     = Globals.ToString(data.formularioTipo);
            objModel.FormularioValor    = Globals.ToString(data.formularioValor);
            objModel.SetUpdated(Globals.GetUser(user));

            _context.CategoriasItems.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
