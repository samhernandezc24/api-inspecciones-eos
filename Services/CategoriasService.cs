using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Workcube.Interfaces;
using Workcube.Libraries;

namespace API.Inspecciones.Services
{
    public class CategoriasService : IGlobal<Categoria>
    {
        private readonly Context _context;

        public CategoriasService(Context context)
        {
            _context = context;
        }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction  = _context.Database.BeginTransaction();

            string categoriaName    = Globals.ToUpper(data.name);
            bool isAlreadyExist = await _context.Categorias.AnyAsync(x => x.Name == categoriaName && !x.Deleted);
            if (isAlreadyExist) { throw new ArgumentException("Lo siento, ya existe una categoría con este nombre. Por favor, elige otro nombre."); }

            // TODO(samhernandezc24): AGREGAR VALIDACIÓN EN CASO DE QUE EL IDINSPECCIONTIPO NO EXISTA O ESTE ELIMINADO.

            // GUARDAR CATEGORIA
            Categoria objModel = new Categoria();
            objModel.IdCategoria            = Guid.NewGuid().ToString();
            objModel.Name                   = categoriaName;
            objModel.IdInspeccionTipo       = Globals.ParseGuid(data.idInspeccionTipo);
            objModel.InspeccionTipoFolio    = Globals.ToUpper(data.inspeccionTipoFolio);
            objModel.InspeccionTipoName     = Globals.ToUpper(data.inspeccionTipoName);
            objModel.SetCreated(Globals.GetUser(user));

            _context.Categorias.Add(objModel);
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

            // ELIMINAR CATEGORIA
            string idCategoria = Globals.ParseGuid(data.idCategoria);
            Categoria objModel = await Find(idCategoria);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la categoría solicitada."); }
            if (objModel.Deleted) { throw new ArgumentException("La categoría ya fue eliminada anteriormente."); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Categorias.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Categoria> Find(string id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> FindSelectorById(string id, string fields)
        {
            return await _context.Categorias.AsNoTracking().Where(x => x.IdCategoria == id).Select(Globals.BuildSelector<Categoria, Categoria>(fields)).FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Categorias
                                 .AsNoTracking()
                                 .Where(x => !x.Deleted)
                                 .OrderByDescending(x => x.CreatedFecha)
                                 .Select(x => new
                                 {
                                     IdCategoria            = x.IdCategoria,
                                     Name                   = x.Name,
                                     IdInspeccionTipo       = x.IdInspeccionTipo,
                                     InspeccionTipoName     = x.InspeccionTipoName,
                                     InspeccionTipoFolio    = x.InspeccionTipoFolio,
                                 })
                                 .ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListByIdInspeccionTipo(string idInspeccionTipo)
        {
            return await _context.Categorias
                                 .AsNoTracking()
                                 .Where(x => x.IdInspeccionTipo == idInspeccionTipo && !x.Deleted)
                                 .OrderByDescending(x => x.CreatedFecha)
                                 .Select(x => new
                                 {
                                     IdCategoria            = x.IdCategoria,
                                     Name                   = x.Name,
                                     IdInspeccionTipo       = x.IdInspeccionTipo,
                                     InspeccionTipoName     = x.InspeccionTipoName,
                                     InspeccionTipoFolio    = x.InspeccionTipoFolio,
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

            // ACTUALIZAR CATEGORIA
            string idCategoria = Globals.ParseGuid(data.idCategoria);

            Categoria objModel = await Find(idCategoria);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la categoría solicitada."); }
            if (objModel.Deleted) { throw new ArgumentException("La categoría ya fue eliminada anteriormente."); }

            objModel.Name = Globals.ToUpper(data.name);
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Categorias.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
