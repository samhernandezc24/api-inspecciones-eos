using API.Inspecciones.Models;
using API.Inspecciones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Workcube.Libraries;

namespace API.Inspecciones.Controllers
{
    [Route("api/Inspecciones/Ficheros")]
    [ApiController]
    public class InspeccionesFicherosController : ControllerBase
    {
        private readonly InspeccionesService _inspeccionesService;
        private readonly InspeccionesFicherosService _inspeccionesFicherosService;

        public InspeccionesFicherosController(InspeccionesService inspeccionesService, InspeccionesFicherosService inspeccionesFicherosService)
        {
            _inspeccionesService            = inspeccionesService;
            _inspeccionesFicherosService    = inspeccionesFicherosService;
        }

        [HttpPost("List")]
        [Authorize]
        public async Task<ActionResult<dynamic>> List(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var objData           = Globals.JsonData(data);
                string idInspeccion   = Globals.ParseGuid(objData.idInspeccion);

                Inspeccion objModel = await _inspeccionesService.FindSelectorById(idInspeccion, "Folio,UnidadNumeroEconomico");

                var objInspeccion = new
                {
                    Folio                   = objModel.Folio,
                    UnidadNumeroEconomico   = objModel.UnidadNumeroEconomico,
                };

                var objFotos = await _inspeccionesFicherosService.List(idInspeccion);

                objReturn.Result = new
                {
                    Inspeccion      = objInspeccion,
                    FotosGenerales  = objFotos,
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
                await _inspeccionesFicherosService.Create(Globals.JsonData(data), User);

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

        [HttpPost("Update")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Update(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _inspeccionesFicherosService.Update(Globals.JsonData(data), User);

                objReturn.Title     = "Actualizado";
                objReturn.Message   = "Foto actualizada exitosamente";
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
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _inspeccionesService.Delete(Globals.JsonData(data), User);

                objReturn.Title     = "Eliminado";
                objReturn.Message   = "Foto eliminada exitosamente";
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
    }
}
