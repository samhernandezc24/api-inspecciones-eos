using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using API.Inspecciones.ViewModels;
using API.Inspecciones.ViewModels.Reports;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Security.Claims;
using Workcube.Interfaces;
using Workcube.Libraries;
using Workcube.ViewModels;

namespace API.Inspecciones.Services
{    
    public class UnidadesService : IGlobal<Unidad>
    {
        private readonly Context _context;
        private readonly IMapper _mapper;

        public UnidadesService(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction  = _context.Database.BeginTransaction();

            string numeroEconomico = Globals.ToUpper(data.numeroEconomico);

            bool findUnidad = await _context.Unidades.AnyAsync(x => x.NumeroEconomico.ToUpper() == numeroEconomico && !x.Deleted);
            if (findUnidad) { throw new ArgumentException("El número económico que intentas registrar ya existe en la base de datos"); }

            // CREAR UNIDAD TEMPORAL
            Unidad objModel = new Unidad();

            objModel.IdUnidad               = Guid.NewGuid().ToString();
            objModel.NumeroEconomico        = numeroEconomico;
            objModel.Descripcion            = Globals.ToUpper(data.descripcion);    
            objModel.IdUnidadTipo           = Globals.ParseGuid(data.idUnidadTipo);
            objModel.UnidadTipoName         = Globals.ToUpper(data.unidadTipoName);
            objModel.IdUnidadMarca          = Globals.ParseGuid(data.idUnidadMarca);
            objModel.UnidadMarcaName        = Globals.ToUpper(data.unidadMarcaName);
            objModel.NumeroSerie            = Globals.ToUpper(data.numeroSerie);
            objModel.AnioEquipo             = Globals.ToUpper(data.anioEquipo);
            objModel.Modelo                 = Globals.ToUpper(data.modelo);
            objModel.Capacidad              = Globals.ToUpper(data.capacidad);

            objModel.SetCreated(Globals.GetUser(user));

            _context.Unidades.Add(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            if (!await HttpReq.GetPrivilegio("UNIDADES_TEMPORALES_LIST", user)) { throw new AppException(ExceptionMessage.SESSION_003); }

            IQueryable<UnidadViewModel> lstItems = DataSourceExpression(data);

            DataSourceBuilder<UnidadViewModel> objDataTableBuilder = new DataSourceBuilder<UnidadViewModel>(data, lstItems);

            var objDataTableResult = await objDataTableBuilder.build();

            List<UnidadViewModel> lstOriginal   = objDataTableResult.rows;
            List<dynamic> lstRows               = new List<dynamic>();

            int length  = (int)data.length;
            int page    = (int)data.page;
            int index   = ((page - 1) * length) + 1;

            lstOriginal.ForEach(item =>
            {
                lstRows.Add(new
                {
                    index               = index,
                    IdUnidad            = item.IdUnidad,
                    NumeroEconomico     = item.NumeroEconomico,
                    Descripcion         = item.Descripcion,
                    IdUnidadTipo        = item.IdUnidadTipo,
                    UnidadTipoName      = item.UnidadTipoName,
                    IdUnidadMarca       = item.IdUnidadMarca,
                    UnidadMarcaName     = item.UnidadMarcaName,
                    NumeroSerie         = item.NumeroSerie,
                    AnioEquipo          = item.AnioEquipo,
                    Modelo              = item.Modelo,
                    Capacidad           = item.Capacidad,
                    CreatedUserName     = item.CreatedUserName,
                    CreatedFecha        = item.CreatedFechaNatural,
                    UpdatedUserName     = item.UpdatedUserName,
                    UpdatedFecha        = item.UpdatedFechaNatural,
                });
                index++;
            });

            var objReturn = new
            {
                rows    = lstRows,
                count   = objDataTableResult.count,
                length  = objDataTableResult.length,
                pages   = objDataTableResult.pages,
                page    = objDataTableResult.page,
            };

            return objReturn;
        }

        public IQueryable<UnidadViewModel> DataSourceExpression(dynamic data)
        {
            // INCLUDES
            IQueryable<UnidadViewModel> lstItems;

            // APLICAR FILTROS DINAMICOS
            // FILTROS
            var filters = new Dictionary<string, Func<string, Expression<Func<Unidad, bool>>>>
            {
                {"IdCreatedUser",       (strValue) => item => item.IdCreatedUser    == strValue},
                {"IdUpdatedUser",       (strValue) => item => item.IdUpdatedUser    == strValue},
            };

            // FILTROS MULTIPLE
            var filtersMultiple = new Dictionary<string, Func<string, Expression<Func<Unidad, bool>>>> 
            {
                {"IdUnidadMarca",       (strValue) => item => item.IdUnidadMarca        == strValue},
                {"IdUnidadTipo",        (strValue) => item => item.IdUnidadTipo         == strValue},
            };

            // FILTROS FECHAS
            DateTime? dateFrom  = SourceExpression<Unidad>.Date((string)data.dateFrom);
            DateTime? dateTo    = SourceExpression<Unidad>.Date((string)data.dateTo);

            var dates = new Dictionary<string, DateExpression<Unidad>>()
            {
                { "CreatedFecha",   new DateExpression<Unidad>{ dateFrom = item => item.CreatedFecha.Date   >= dateFrom, dateTo = item => item.CreatedFecha.Date    <= dateTo } },
                { "UpdatedFecha",   new DateExpression<Unidad>{ dateFrom = item => item.UpdatedFecha.Date   >= dateFrom, dateTo = item => item.UpdatedFecha.Date    <= dateTo } },
            };

            Expression<Func<Unidad, bool>> ExpFullWhere = SourceExpression<Unidad>.GetExpression(data, filters, dates, filtersMultiple);

            // ORDER BY
            var orderColumn     = Globals.ToString(data.sort.column);
            var orderDirection  = Globals.ToString(data.sort.direction);

            Expression<Func<Unidad, object>> sortExpression;
            switch (orderColumn)
            {
                case "numeroEconomico"      : sortExpression = (x => x.NumeroEconomico);        break;
                case "descripcion"          : sortExpression = (x => x.Descripcion);            break;
                case "unidadTipoName"       : sortExpression = (x => x.UnidadTipoName);         break;
                case "unidadMarcaName"      : sortExpression = (x => x.UnidadMarcaName);        break;
                case "numeroSerie"          : sortExpression = (x => x.NumeroSerie);            break;
                case "anioEquipo"           : sortExpression = (x => x.AnioEquipo);             break;
                case "modelo"               : sortExpression = (x => x.Modelo);                 break;
                case "capacidad"            : sortExpression = (x => x.Capacidad);              break;
                case "createdUserName"      : sortExpression = (x => x.CreatedUserName);        break;
                case "createdFechaNatural"  : sortExpression = (x => x.CreatedFecha);           break;
                case "updatedUserName"      : sortExpression = (x => x.UpdatedUserName);        break;
                case "updatedFechaNatural"  : sortExpression = (x => x.UpdatedFecha);           break;
                default                     : sortExpression = (x => x.CreatedFecha);           break;
            }

            // MAPEAR DATOS
            List<string> columns = new List<string>();

            columns = Globals.GetArrayColumns(data);

            columns.Add("IdUnidad");
            columns.Add("NumeroEconomico");
            columns.Add("Descripcion");
            columns.Add("IdUnidadTipo");
            columns.Add("UnidadTipoName");
            columns.Add("IdUnidadMarca");
            columns.Add("UnidadMarcaName");
            columns.Add("NumeroSerie");
            columns.Add("AnioEquipo");
            columns.Add("Modelo");
            columns.Add("Capacidad");
            columns.Add("CreatedUserName");
            columns.Add("CreatedFecha");
            columns.Add("UpdatedUserName");
            columns.Add("UpdatedFecha");

            string strColumns = Globals.GetStringColumns(columns);

            // COMPLETE
            IQueryable<Unidad> lstRows = _context.Unidades.AsNoTracking();

            lstRows = (orderDirection == "asc") ? lstRows.OrderBy(sortExpression) : lstRows.OrderByDescending(sortExpression);

            lstItems = lstRows
                        .Where(x => !x.Deleted)
                        .Where(ExpFullWhere)
                        .Select(Globals.BuildSelector<Unidad, Unidad>(strColumns))
                        .ProjectTo<UnidadViewModel>(_mapper.ConfigurationProvider);

            return lstItems;
        }

        public async Task Delete(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            // ELIMINAR UNIDAD TEMPORAL
            string idUnidad = Globals.ParseGuid(data.idUnidad);
            var objModel    = await Find(idUnidad);

            if (objModel == null) { throw new ArgumentException("No se ha encontrado la unidad"); }
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
                                IdUnidadMarca   = x.IdUnidadMarca,
                                UnidadMarcaName = x.UnidadMarcaName,
                                NumeroSerie     = x.NumeroSerie,
                                Modelo          = x.Modelo,
                            })
                            .ToListAsync<dynamic>();
        }

        public async Task<List<dynamic>> ListUsuarios()
        {
            var lstUsuarios = await _context.Unidades
                                    .AsNoTracking()
                                    .Select(x => new
                                    {
                                        IdCreatedUser   = x.IdCreatedUser,
                                        CreatedUserName = x.CreatedUserName,
                                        IdUpdatedUser   = x.IdUpdatedUser,
                                        UpdatedUserName = x.UpdatedUserName,
                                    })
                                    .Distinct()
                                    .ToListAsync();

            var rows = lstUsuarios.SelectMany(x => new[]
            {
                new { Id = x.IdCreatedUser, NombreCompleto = x.CreatedUserName },
                new { Id = x.IdUpdatedUser, NombreCompleto = x.UpdatedUserName },
            })
            .OrderBy(x => x.NombreCompleto)
            .GroupBy(x => x.Id)
            .Select(x => x.First())
            .ToList<dynamic>();

            return rows;
        }

        public async Task<byte[]> Reporte(dynamic data)
        {
            IQueryable<UnidadViewModel> lstItems = DataSourceExpression(data);

            string strColumns = JsonConvert.SerializeObject(data.columns);

            List<ModelExcelColumn> columnsDataTable = JsonConvert.DeserializeObject<List<ModelExcelColumn>>(strColumns);

            var lstRows = _mapper.Map<List<RepUnidad>>(lstItems);

            return await ExcelManager<RepUnidad>.GetFile(columnsDataTable, lstRows);
        }

        public async Task<List<dynamic>> Predictive(dynamic data)
        {
            // INCLUDES
            string fields = "IdUnidad,NumeroEconomico,Descripcion,IdUnidadTipo,UnidadTipoName,IdUnidadMarca,UnidadMarcaName,NumeroSerie,Modelo";

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
                        IdUnidadMarca       = item.IdUnidadMarca,
                        UnidadMarcaName     = item.UnidadMarcaName,
                        NumeroSerie         = item.NumeroSerie,
                        Modelo              = item.Modelo,
                });
                });
            }

            return lstRows;
        }

        public async Task Update(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction  = _context.Database.BeginTransaction();

            // ACTUALIZAR UNIDAD TEMPORAL
            string idUnidad         = Globals.ParseGuid(data.idUnidad);
            string numeroEconomico  = Globals.ToUpper(data.numeroEconomico);

            bool findUnidad = await _context.Unidades.AnyAsync(x => x.NumeroEconomico.ToUpper() == numeroEconomico && !x.Deleted && x.IdUnidad != idUnidad);
            if (findUnidad) { throw new ArgumentException("El número económico que intenta registrar ya existe en la base de datos"); }

            Unidad objModel = await Find(idUnidad);
            if (objModel == null) { throw new ArgumentException("La unidad no ha sido encontrada"); }
            if (objModel.Deleted) { throw new ArgumentException("La unidad temporal ya ha sido eliminada"); }

            objModel.NumeroEconomico        = Globals.ToUpper(data.numeroEconomico);
            objModel.Descripcion            = Globals.ToUpper(data.descripcion);    
            objModel.IdUnidadTipo           = Globals.ParseGuid(data.idUnidadTipo);
            objModel.UnidadTipoName         = Globals.ToUpper(data.unidadTipoName);
            objModel.IdUnidadMarca          = Globals.ParseGuid(data.idUnidadMarca);
            objModel.UnidadMarcaName        = Globals.ToUpper(data.unidadMarcaName);
            objModel.NumeroSerie            = Globals.ToUpper(data.numeroSerie);
            objModel.AnioEquipo             = Globals.ToUpper(data.anioEquipo);
            objModel.Modelo                 = Globals.ToUpper(data.modelo);
            objModel.Capacidad              = Globals.ToUpper(data.capacidad);
            objModel.SetUpdated(Globals.GetUser(user));                      

            _context.Unidades.Update(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }
    }
}
