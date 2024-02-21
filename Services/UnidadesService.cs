using API.Inspecciones.Interfaces;
using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Security.Claims;
using Workcube.Libraries;

namespace API.Inspecciones.Services
{    
    public class UnidadesService : IUnidadesService
    {
        private readonly Context _context;

        public UnidadesService(Context context)
        {
            _context = context;
        }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction  = _context.Database.BeginTransaction();

            // CREAR UNIDAD TEMPORAL
            Unidad objModel = new Unidad();

            objModel.IdUnidad           = Guid.NewGuid().ToString();
            objModel.NumeroEconomico    = Globals.ToUpper(data.numeroEconomico);
            objModel.Descripcion        = Globals.ToUpper(data.descripcion);    
            objModel.IdUnidadTipo       = Globals.ParseGuid(data.idUnidadTipo);
            objModel.UnidadTipoName     = Globals.ToUpper(data.unidadTipoName);

            objModel.SetCreated(Globals.GetUser(user));

            var findUnidad = _context.Unidades.Where(x => x.NumeroEconomico.ToUpper() == objModel.NumeroEconomico.ToUpper() && !x.Deleted).Any();

            if (findUnidad) { throw new ArgumentException("El número económico que intenta registrar ya existe en la base de datos"); }

            _context.Unidades.Add(objModel);
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

            // ELIMINAR UNIDAD TEMPORAL
            string idUnidad = Globals.ParseGuid(data.idUnidad);
            var objModel    = await Find(idUnidad);    

            if (objModel.Deleted) { throw new ArgumentException("La unidad temporal ya había sido eliminada anteriormente"); }

            objModel.Deleted = true;
            objModel.SetUpdated(Globals.GetUser(user));

            _context.Unidades.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<Unidad> Find(string id)
        {
            return await _context.Unidades.FindAsync(id);
        }

        public async Task<Unidad> FindSelectorById(string id, string fields)
        {
            return await _context.Unidades.Where(x => x.IdUnidad == id).Select(Globals.BuildSelector<Unidad, Unidad>(fields)).FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> List()
        {
            return await _context.Unidades.AsNoTracking()
                            .Where(x => !x.Deleted)
                            .OrderBy(x => x.CreatedFecha)
                            .Select(x => new
                            {
                                IdUnidad        = x.IdUnidad,
                                Descripcion     = x.Descripcion,
                                NumeroEconomico = x.NumeroEconomico,
                                IdUnidadTipo    = x.IdUnidadTipo,
                                UnidadTipoName  = x.UnidadTipoName,
                            })
                            .ToListAsync<dynamic>();
        }

        public Task<byte[]> Reporte(dynamic data)
        {
            throw new NotImplementedException();
        }

        public async Task<List<dynamic>> Predictive(dynamic data)
        {
            // INCLUDES
            string fields = "IdUnidad,NumeroEconomico,Descripcion,IdUnidadTipo,UnidadTipoName";

            // QUERY
            var lstItems = _context.Unidades
                               .AsNoTracking()
                               .OrderBy(w => w.NumeroEconomico)
                               .Where(x => !x.Deleted)
                               .Select(Globals.BuildSelector<Unidad, Unidad>(fields));

            // INITIALIZATION            
            DataSourceBuilder<Unidad> objDataSourceBuilder = new DataSourceBuilder<Unidad>();
            objDataSourceBuilder.Source = lstItems;
            objDataSourceBuilder.Arguments = data;

            // SEARCH FILTERS
            Func<Expression<Func<Unidad, bool>>, string, string, Expression<Func<Unidad, bool>>> argSwitchFilters = (argExpression, argField, search) =>
            {
                return argExpression;
            };

            objDataSourceBuilder.SearchFilters(argSwitchFilters);

            // TAKE
            lstItems = objDataSourceBuilder.Take();

            // DATA MAPPING
            var lstOriginal = await lstItems.ToListAsync();
            var lstRows = new List<dynamic>();

            if (lstOriginal != null)
            {
                lstOriginal.ForEach(item =>
                {
                    lstRows.Add(new
                    {
                        IdUnidad            = item.IdUnidad,
                        NumeroEconomico     = item.NumeroEconomico,
                        Descripcion         = item.Descripcion,
                        IdUnidadTipo        = item.IdUnidadTipo,
                        UnidadTipoName      = item.UnidadTipoName,
                        IsUnidadTemporal    = true,
                    });
                });
            }

            return lstRows;
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction  = _context.Database.BeginTransaction();

            // ACTUALIZAR UNIDAD TEMPORAL
            string idUnidad = Globals.ParseGuid(data.idUnidad);
            Unidad objModel = await Find(idUnidad);

            objModel.NumeroEconomico    = Globals.ToUpper(data.numeroEconomico);
            objModel.Descripcion        = Globals.ToUpper(data.descripcion);    
            objModel.IdUnidadTipo       = Globals.ParseGuid(data.idUnidadTipo);
            objModel.UnidadTipoName     = Globals.ToUpper(data.unidadTipoName);
            objModel.SetUpdated(Globals.GetUser(user));

            var findUnidad = _context.Unidades.Where(x => x.NumeroEconomico.ToUpper() == objModel.NumeroEconomico.ToUpper() && !x.Deleted && x.IdUnidad != idUnidad).Any();

            if (findUnidad) { throw new ArgumentException("El número económico que intenta registrar ya existe en la base de datos"); }           

            _context.Unidades.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
