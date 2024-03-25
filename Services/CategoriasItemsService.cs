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

            string idCategoria          = Globals.ParseGuid(data.idCategoria);
            string categoriaItemName    = Globals.ToUpper(data.name);

            bool findCategoriaItem = await _context.CategoriasItems.AnyAsync(x => x.Name.ToUpper() == categoriaItemName && x.IdCategoria == idCategoria && !x.Deleted);
            if (findCategoriaItem) { throw new ArgumentException("Ya existe una pregunta con este nombre. Por favor, elige otro nombre."); }

            // GUARDAR CATEGORIA ITEM
            CategoriaItem objModel = new CategoriaItem();
            objModel.IdCategoriaItem        = Guid.NewGuid().ToString();
            objModel.Name                   = categoriaItemName;
            objModel.Orden                  = Globals.ParseInt(data.orden);
            objModel.IdInspeccionTipo       = Globals.ParseGuid(data.idInspeccionTipo);
            objModel.InspeccionTipoName     = Globals.ToUpper(data.inspeccionTipoName);
            objModel.IdCategoria            = idCategoria;
            objModel.CategoriaName          = Globals.ToUpper(data.categoriaName);
            objModel.IdFormularioTipo       = Globals.ParseGuid(data.idFormularioTipo);
            objModel.FormularioTipoName     = Globals.ToUpper(data.formularioTipoName);
            objModel.FormularioValor        = "";
            objModel.SetCreated(Globals.GetUser(user));

            _context.CategoriasItems.Add(objModel);
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

            // ELIMINAR FORMULARIO DE PREGUNTAS
            string idCategoria      = Globals.ParseGuid(data.idCategoria);
            string idCategoriaItem  = Globals.ParseGuid(data.idCategoriaItem);

            CategoriaItem objModel = await Find(idCategoriaItem);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la pregunta solicitada."); }
            if (objModel.Deleted) { throw new ArgumentException("La pregunta ya fue eliminada anteriormente."); }

            objModel.Deleted    = true;
            objModel.Orden      = 0;
            objModel.SetUpdated(Globals.GetUser(user));
            _context.SaveChanges();

            var lstCategoriasItems = _context.CategoriasItems.OrderBy(x => x.Orden).Where(x => x.IdCategoria == idCategoria && !x.Deleted).ToList();

            int orden = 1;
            foreach (var item in lstCategoriasItems)
            {
                item.Orden = orden;
                orden++;
            }

            _context.CategoriasItems.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<CategoriaItem> Find(string id)
        {
            return await _context.CategoriasItems.FindAsync(id);
        }

        public async Task<CategoriaItem> FindSelectorById(string id, string fields)
        {
            return await _context.CategoriasItems.AsNoTracking().Where(x => x.IdCategoriaItem == id)
                            .Select(Globals.BuildSelector<CategoriaItem, CategoriaItem>(fields)).FirstOrDefaultAsync();
        }

        public Task<List<dynamic>> List()
        {
            throw new NotImplementedException();
        }

        public async Task<List<dynamic>> List(string idCategoria)
        {
            return await _context.CategoriasItems
                                 .AsNoTracking()
                                 .Where(x => x.IdCategoria == idCategoria && !x.Deleted)
                                 .OrderBy(x => x.Orden)
                                 .Select(x => new
                                 {
                                     IdCategoriaItem        = x.IdCategoriaItem,
                                     Name                   = x.Name,
                                     IdFormularioTipo       = x.IdFormularioTipo ?? null,
                                     FormularioTipoName     = x.FormularioTipoName,
                                 })
                                 .ToListAsync<dynamic>();
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

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la pregunta solicitada."); }
            if (objModel.Deleted) { throw new ArgumentException("La pregunta ya fue eliminada anteriormente."); }

            objModel.Name               = Globals.ToString(data.name);
            objModel.IdFormularioTipo   = Globals.ParseGuid(data.idFormularioTipo);
            objModel.FormularioTipoName = Globals.ToUpper(data.formularioTipoName);
            objModel.FormularioValor    = "";

            string formularioValor = "";

            objModel.FormularioValor    = formularioValor;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.CategoriasItems.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task UpdateOrden(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            // ACTUALIZAR EL ORDEN DEL FORMULARIO DE PREGUNTAS
            string idCategoria = Globals.ParseGuid(data.idCategoria);

            var lstCategoriasItems = _context.CategoriasItems.Where(x => x.IdCategoria == idCategoria).ToList();

            List<CategoriaItem> updateData = new List<CategoriaItem>();
            int orden = 1;
            foreach (var item in data.categoriasItems)
            {
                string idCategoriaItem = Globals.ParseGuid(item.idCategoriaItem);
                var objCategoriaItem = lstCategoriasItems.Find(x => x.IdCategoriaItem == idCategoriaItem);

                if (objCategoriaItem != null)
                {
                    objCategoriaItem.Orden = orden;
                    updateData.Add(objCategoriaItem);
                }

                orden++;
            }

            _context.CategoriasItems.UpdateRange(updateData);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
