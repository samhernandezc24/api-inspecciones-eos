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

        public CategoriasItemsController(CategoriasItemsService categoriasItemsService)
        {
            _categoriasItemsService = categoriasItemsService;
        }

        [HttpPost("List")]
        [Authorize]
        public async Task<ActionResult<dynamic>> List()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                List<dynamic> lstCategoriasItems = await _categoriasItemsService.List();

                objReturn.Result = new
                {
                    CategoriasItems = lstCategoriasItems,
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

        [HttpPost("ListByIdCategoria")]
        [Authorize]
        public async Task<ActionResult<dynamic>> ListByIdCategoria(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var objData             = Globals.JsonData(data);
                var idCategoria         = Globals.ParseGuid(objData.idCategoria);
                var lstCategoriasItems  = await _categoriasItemsService.ListByIdCategoria(idCategoria);

                objReturn.Result = new
                {
                    CategoriasItems = lstCategoriasItems,
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

                objReturn.Title     = "Nuevo formulario de preguntas";
                objReturn.Message   = "Formulario de preguntas creado exitosamente";
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

                objReturn.Title     = "Actualizado";
                objReturn.Message   = "Formulario de preguntas actualizado exitosamente";
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

                objReturn.Title     = "Eliminado";
                objReturn.Message   = "Formulario de preguntas eliminado exitosamente";
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
