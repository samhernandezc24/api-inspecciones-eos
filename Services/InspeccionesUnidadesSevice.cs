using System.Security.Claims;
using API.Inspecciones.Interfaces;
using API.Inspecciones.Models;
using API.Inspecciones.Persistence;
using Microsoft.EntityFrameworkCore;
using Workcube.Libraries;

namespace API.Inspecciones.Services
{
    public class InspeccionesUnidadesService : IInspeccionesUnidadesService
    {
        private readonly Context _context;

        public InspeccionesUnidadesService(Context context)
        {
            _context = context;
        }

        public async Task Create(dynamic data, ClaimsPrincipal user)
        {
            var objUser = Globals.GetUser(user);
            var objTransaction  = _context.Database.BeginTransaction();

            // GUARDAR INSPECCION DE LA UNIDAD
            InspeccionUnidad objModel = new InspeccionUnidad();

            objModel.IdInspeccionUnidad             = Guid.NewGuid().ToString();
            objModel.IdBase                         = Globals.ParseGuid(data.idBase);
            objModel.BaseName                       = Globals.ToUpper(data.baseName);
            objModel.IdUnidad                       = Globals.ParseGuid(data.idUnidad);
            objModel.UnidadNumeroEconomico          = Globals.ToUpper(data.unidadNumeroEconomico);
            objModel.IsUnidadTemporal               = Globals.ParseBool(data.isUnidadTemporal);
            objModel.IdUnidadMarca                  = Globals.ParseGuid(data.idUnidadMarca);
            objModel.UnidadMarcaName                = Globals.ToUpper(data.unidadMarcaName);
            objModel.Fecha                          = DateTime.Now;
            objModel.IdInspeccion                   = Globals.ParseGuid(data.idInspeccion);
            objModel.InspeccionFolio                = Globals.ToUpper(data.inspeccionFolio);
            objModel.InspeccionName                 = Globals.ToUpper(data.inspeccionName);
            objModel.FechaInspeccionInicial         = DateTime.Now;
            objModel.FechaInspeccionInicialUpdate   = DateTime.Now;
            objModel.IdUserInspeccionInicial        = objUser.Id;
            objModel.UserInspeccionInicialName      = objUser.Nombre;
            objModel.FechaInspeccionFinal           = Globals.DateTime(data.fechaInspeccionFinal);
            objModel.FechaInspeccionFinalUpdate     = Globals.DateTime(data.fechaInspeccionFinal);
            objModel.IdUserInspeccionFinal          = objUser.Id;
            objModel.UserInspeccionFinalName        = objUser.Nombre;
            objModel.IdRequerimiento                = Globals.ParseGuid(data.idRequerimiento);
            objModel.RequerimientoFolio             = Globals.ToUpper(data.requerimientoFolio);
            objModel.IdUnidadPlacaTipo              = Globals.ParseGuid(data.idUnidadPlacaTipo);
            objModel.UnidadPlacaTipoName            = Globals.ToUpper(data.unidadPlacaTipoName);
            objModel.Placa                          = Globals.ToUpper(data.placa);
            objModel.NumeroSerie                    = Globals.ToUpper(data.numeroSerie);
            objModel.AnioEquipo                     = Globals.ToUpper(data.anioEquipo);
            objModel.Modelo                         = Globals.ToUpper(data.modelo);
            objModel.Capacidad                      = Globals.ParseDecimal(data.capacidad);
            objModel.Observaciones                  = Globals.ToUpper(data.observaciones);
            objModel.Odometro                       = Globals.ParseInt(data.odometro);
            objModel.Horometro                      = Globals.ParseInt(data.horometro);
            objModel.TipoPlataforma                 = Globals.ToUpper(data.tipoPlataforma);
            objModel.Locacion                       = Globals.ToUpper(data.locacion);
            objModel.FirmaOperador                  = Globals.ToUpper(data.firmaOperador);
            objModel.FirmaVerificador               = Globals.ToUpper(data.firmaVerificador);

            objModel.IdInspeccionUnidadEstatus      = "ea52bdfd-8af6-4f5a-b182-2b99e554eb31";
            objModel.InspeccionUnidadEstatusName    = "PENDIENTE";

            NextFolio(ref objModel);
            objModel.SetCreated(Globals.GetUser(user));

            _context.InspeccionesUnidades.Add(objModel);
            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task CreateFromRequerimientos(dynamic data, ClaimsPrincipal user)
        {
            var objUser = Globals.GetUser(user);
            InspeccionUnidad objModel = new InspeccionUnidad();

            objModel.IdInspeccionUnidad             = Guid.NewGuid().ToString();
            objModel.IdBase                         = Globals.ParseGuid(data.idBase);
            objModel.BaseName                       = Globals.ToUpper(data.baseName);
            objModel.IdUnidad                       = Globals.ParseGuid(data.idUnidad);
            objModel.UnidadNumeroEconomico          = Globals.ToUpper(data.unidadNumeroEconomico);
            objModel.IsUnidadTemporal               = Globals.ParseBool(data.isUnidadTemporal);
            objModel.Fecha                          = DateTime.Now;
            objModel.IdInspeccion                   = Globals.ParseGuid(data.idInspeccion);
            objModel.InspeccionFolio                = Globals.ToUpper(data.inspeccionFolio);
            objModel.InspeccionName                 = Globals.ToUpper(data.inspeccionName);
            objModel.FechaInspeccionInicial         = DateTime.Now;
            objModel.FechaInspeccionInicialUpdate   = DateTime.Now;
            objModel.IdUserInspeccionInicial        = objUser.Id;
            objModel.UserInspeccionInicialName      = objUser.Nombre;
            objModel.IdRequerimiento                = Globals.ParseGuid(data.idRequerimiento);
            objModel.RequerimientoFolio             = Globals.ToString(data.requerimientoFolio);
            objModel.IdUnidadPlacaTipo              = Globals.ParseGuid(data.idUnidadPlacaTipo);
            objModel.UnidadPlacaTipoName            = Globals.ToUpper(data.unidadPlacaTipoName);
            objModel.Placa                          = Globals.ToUpper(data.placa);
            objModel.NumeroSerie                    = Globals.ToUpper(data.numeroSerie);
            objModel.AnioEquipo                     = Globals.ToUpper(data.anioEquipo);
            objModel.Modelo                         = Globals.ToUpper(data.modelo);
            objModel.Capacidad                      = Globals.ParseDecimal(data.capacidad);
            objModel.Odometro                       = Globals.ParseInt(data.odometro);
            objModel.Horometro                      = Globals.ParseInt(data.horometro);
            objModel.Locacion                       = Globals.ToUpper(data.locacion);

            objModel.IdInspeccionUnidadEstatus      = "ea52bdfd-8af6-4f5a-b182-2b99e554eb31";
            objModel.InspeccionUnidadEstatusName    = "PENDIENTE";

            NextFolio(ref objModel);
            objModel.SetCreated(Globals.GetUser(user));

            _context.InspeccionesUnidades.Add(objModel);
            await _context.SaveChangesAsync();
        }

        private void NextFolio(ref InspeccionUnidad objInspeccionUnidad)
        {
            var anio        = DateTime.Now.Year.ToString().Substring(2, 2);
            var contains    = "INS" + anio + "-VH";

            int indexKey = NextIndexKey(contains);

            string folio = contains + "-" + indexKey.ToString().PadLeft(6, '0');
            objInspeccionUnidad.Folio = folio;
        }

        public int NextIndexKey(string contains)
        {
            return _context.InspeccionesUnidades.Where(item => item.Folio.Contains(contains)).Count() + 1;
        }

        public Task<dynamic> DataSource(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(dynamic data, ClaimsPrincipal user)
        {
            throw new NotImplementedException();
        }

        public async Task Finalizar(dynamic data, ClaimsPrincipal user)
        {
            var objTransaction = _context.Database.BeginTransaction();

            string idInspeccionUnidad = Globals.ParseGuid(data.idInspeccionUnidad);

            InspeccionUnidad objModel = await Find(idInspeccionUnidad);

            switch (objModel.IdInspeccionUnidadEstatus)
            {
                case "ea52bdfd-8af6-4f5a-b182-2b99e554eb34":
                    throw new ArgumentException("La inspección de la unidad ya había sido finalizada anteriormente");
                case "ea52bdfd-8af6-4f5a-b182-2b99e554eb35":
                    throw new ArgumentException("La inspección de la unidad ya había sido cancelada anteriormente");
            }

            objModel.IdInspeccionUnidadEstatus      = "ea52bdfd-8af6-4f5a-b182-2b99e554eb34";
            objModel.InspeccionUnidadEstatusName    = "FINALIZADO";
            objModel.SetUpdated(Globals.GetUser(user));

            await _context.SaveChangesAsync();
            objTransaction.Commit();
        }

        public async Task<InspeccionUnidad> Find(string id)
        {
            return await _context.InspeccionesUnidades.FindAsync(id);
        }

        public async Task<InspeccionUnidad> FindSelectorById(string id, string fields)
        {
            return await _context.InspeccionesUnidades.AsNoTracking().Where(x => x.IdInspeccionUnidad == id)
                            .Select(Globals.BuildSelector<InspeccionUnidad, InspeccionUnidad>(fields)).FirstOrDefaultAsync();
        }

        public async Task<List<dynamic>> FindLastInspeccionByIds(List<string> lstIds)
        {
            var lstResult = await _context.InspeccionesUnidades
                                .AsNoTracking()
                                .Where(x => lstIds.Contains(x.IdUnidad) && !x.Deleted)
                                .OrderByDescending(x => x.Fecha.Date)
                                .ToListAsync();

            var lstGroup = lstResult.GroupBy(x => x.IdUnidad, x => x, (key, data) => new
            {
                key     = key,
                data    = data,
            }).Select(x => new
            {
                IdUnidad    = x.key,
                Inspeccion  = x.data.FirstOrDefault() ?? null,
                IsValid     = x.data.FirstOrDefault()?.IsValid ?? false,
            }).ToList<dynamic>();

            return lstGroup;
        }
        public async Task<List<dynamic>> List()
        {
            return await _context.InspeccionesUnidades.AsNoTracking().Where(x => !x.Deleted).OrderBy(x => x.Fecha).ToListAsync<dynamic>();
        }
        
        public async Task<List<dynamic>> ListSelector(string id, string fields)
        {
            return await _context.InspeccionesUnidades
                            .AsNoTracking()
                            .Where(x => x.IdInspeccionUnidad == id && !x.Deleted)
                            .OrderBy(x => x.Fecha)
                            .Select(Globals.BuildSelector<InspeccionUnidad, InspeccionUnidad>(fields))
                            .ToListAsync<dynamic>();
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
