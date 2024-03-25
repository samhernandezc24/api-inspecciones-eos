using API.Inspecciones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Workcube.Libraries;

namespace API.Inspecciones.Controllers
{
    [Route("api/Inspecciones/Tipos/Categorias/Items")]
    [ApiController]
    public class CategoriasItemsController : ControllerBase
    {
        private readonly CategoriasItemsService _categoriasItemsService;
        private readonly FormulariosTiposService _formulariosTiposService;

        public CategoriasItemsController(CategoriasItemsService categoriasItemsService, FormulariosTiposService formulariosTiposService)
        {
            _categoriasItemsService     = categoriasItemsService;
            _formulariosTiposService    = formulariosTiposService;
        }

        [HttpPost("List")]
        [Authorize]
        public async Task<ActionResult<dynamic>> List(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var objData             = Globals.JsonData(data);
                var idCategoria         = Globals.ParseGuid(objData.idCategoria);
                var lstCategoriasItems  = await _categoriasItemsService.List(idCategoria);
                var lstFormulariosTipos = await _formulariosTiposService.List();

                objReturn.Result = new
                {
                    CategoriasItems     = lstCategoriasItems,
                    FormulariosTipos    = lstFormulariosTipos,
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
                await _categoriasItemsService.Create(Globals.JsonData(data), User);

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
                await _categoriasItemsService.Update(Globals.JsonData(data), User);

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

        [HttpPost("UpdateOrden")]
        [Authorize]
        public async Task<ActionResult<dynamic>> UpdateOrden(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _categoriasItemsService.UpdateOrden(Globals.JsonData(data), User);

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

        [HttpPost("Delete")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Delete(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _categoriasItemsService.Delete(Globals.JsonData(data), User);

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
    }
}
