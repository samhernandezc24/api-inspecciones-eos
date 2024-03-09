using API.Inspecciones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Workcube.Libraries;

namespace API.Inspecciones.Controllers
{
    [Route("api/Inspecciones/Unidades")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {
        private readonly UnidadesService _unidadesService;

        public UnidadesController(UnidadesService unidadesService)
        {
            _unidadesService = unidadesService;
        }

        [HttpPost("Index")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Index()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var dataSourcePersistence = await HttpReq.Post("account", "DataSourcePersistence/find", Globals.TableDataSource("InspeccionesUnidades", User));

                var lstMarcas   = await HttpReq.Post("unidades", "unidadesmarcas/list");
                var lstTipos    = await HttpReq.Post("unidades", "unidades/tipos/list");
                var lstUsuarios = await _unidadesService.ListUsuarios();

                objReturn.Result = new
                {
                    dataSourcePersistence   = dataSourcePersistence,
                    Usuarios                = lstUsuarios,
                    Marcas                  = lstMarcas,
                    Tipos                   = lstTipos,
                };

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException appException)
            {
                objReturn.Exception(appException);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("DataSource")]
        [Authorize]
        public async Task<ActionResult<dynamic>> DataSource(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                objReturn.Result = await _unidadesService.DataSource(Globals.JsonData(data), User);

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Create()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var lstMarcas           = await HttpReq.Post("unidades", "unidadesmarcas/list");
                var lstUnidadesTipos    = await HttpReq.Post("unidades", "unidades/tipos/list");

                objReturn.Result = new
                {
                    UnidadesTipos = lstUnidadesTipos,
                    UnidadesMarcas = lstMarcas,
                };

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException appException)
            {

                objReturn.Exception(appException);
            }
            catch (Exception exception)
            {

                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Store")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Store(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _unidadesService.Create(Globals.JsonData(data), User);

                objReturn.Title     = "Nueva unidad temporal";
                objReturn.Message   = "Unidad temporal creada exitosamente";
            }
            catch (AppException appException)
            {

                objReturn.Exception(appException);
            }
            catch (Exception exception)
            {

                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("PredictiveEOS")]
        [Authorize]
        public async Task<ActionResult<dynamic>> PredictiveEOS(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var objData = Globals.JsonData(data);

                objReturn.Result = await _unidadesService.Predictive(objData);

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException appException)
            {
                objReturn.Exception(appException);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Edit")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Edit(JsonObject data)
        {
            var objReturn = new JsonReturn();

            try
            {
                string id   = Globals.ParseGuid(Globals.JsonData(data).idUnidad);
                var objRaw  = await _unidadesService.Find(id);

                var objModel = new
                {
                    objRaw.IdUnidad, objRaw.NumeroEconomico, objRaw.IdUnidadMarca, objRaw.UnidadMarcaName, objRaw.IdUnidadTipo, objRaw.UnidadTipoName,
                    objRaw.AnioEquipo, objRaw.Modelo, objRaw.NumeroSerie, objRaw.Descripcion
                };
                
                var lstUnidadesTipos    = await HttpReq.Post("unidades", "unidades/tipos/list");
                var lstUnidadesMarcas   = await HttpReq.Post("unidades", "unidadesmarcas/list");

                objReturn.Result = new
                {
                    Unidad         = objModel,
                    UnidadesTipos  = lstUnidadesTipos,
                    UnidadesMarcas = lstUnidadesMarcas,
                };

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Update")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Update(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _unidadesService.Update(Globals.JsonData(data), User);

                objReturn.Title     = "Actualización";
                objReturn.Message   = "Unidad temporal actualizada exitosamente";
            }
            catch (AppException appException)
            {

                objReturn.Exception(appException);
            }
            catch (Exception exception)
            {

                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Delete")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Delete(JsonObject data)
        {
            var objReturn = new JsonReturn();

            try
            {
                await _unidadesService.Delete(Globals.JsonData(data), User);

                objReturn.Title     = "Eliminado";
                objReturn.Message   = "La unidad temporal ha sido eliminada exitosamente";
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }

        [HttpPost("Reporte")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Reporte(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                byte[] file = await _unidadesService.Reporte(Globals.JsonData(data));
                objReturn.Result = Globals.GetBase64(file);

                objReturn.Success(SuccessMessage.REQUEST);
            }
            catch (AppException exception)
            {
                objReturn.Exception(exception);
            }
            catch (Exception exception)
            {
                objReturn.Exception(ExceptionMessage.RawException(exception));
            }

            return objReturn.build();
        }
    }
}
