using API.Inspecciones.Interfaces;
using API.Inspecciones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Workcube.Libraries;

namespace API.Inspecciones.Controllers
{
    [Route("api/inspecciones/categorias")]
    [ApiController]
    public class InspeccionesCategoriasController : ControllerBase
    {
        private readonly InspeccionesCategoriasService _inspeccionesCategoriasService;

        public InspeccionesCategoriasController(InspeccionesCategoriasService inspeccionesCategoriasService)
        {
            _inspeccionesCategoriasService = inspeccionesCategoriasService;
        }

        [HttpPost("Index")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Index()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
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

        [HttpPost("Create")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Create()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
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
                objReturn.Result = await _inspeccionesCategoriasService.Create(Globals.JsonData(data), User);

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
                await _inspeccionesCategoriasService.Update(Globals.JsonData(data), User);

                objReturn.Title     = "Actualización";
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
    }
}
