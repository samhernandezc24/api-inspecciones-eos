using API.Inspecciones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Workcube.Libraries;

namespace API.Inspecciones.Controllers
{
    [Route("api/Inspecciones/Tipos/Categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriasService _categoriasService;

        public CategoriasController(CategoriasService categoriasService)
        {
            _categoriasService = categoriasService;
        }
        
        [HttpPost("List")]
        [Authorize]
        public async Task<ActionResult<dynamic>> List()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var lstCategorias = await _categoriasService.List();

                objReturn.Result = new
                {
                    Categorias = lstCategorias,
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

        [HttpPost("ListByIdInspeccionTipo")]
        [Authorize]
        public async Task<ActionResult<dynamic>> ListByIdInspeccionTipo(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                var objData                     = Globals.JsonData(data);
                var idInspeccionTipo            = Globals.ParseGuid(objData.idInspeccionTipo);
                var lstCategorias               = await _categoriasService.ListByIdInspeccionTipo(idInspeccionTipo);

                objReturn.Result = new
                {
                    Categorias = lstCategorias,
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
                await _categoriasService.Create(Globals.JsonData(data), User);

                objReturn.Title     = "Nueva categoría";
                objReturn.Message   = "Categoría creada exitosamente";
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
                await _categoriasService.Update(Globals.JsonData(data), User);

                objReturn.Title     = "Actualizado";
                objReturn.Message   = "Categoría actualizada exitosamente";
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
                await _categoriasService.Delete(Globals.JsonData(data), User);

                objReturn.Title     = "Eliminado";
                objReturn.Message   = "Categoría eliminada exitosamente";
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
