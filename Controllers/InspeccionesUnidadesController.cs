using API.Inspecciones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Workcube.Libraries;

namespace API.Inspecciones.Controllers
{
    [Route("api/Inspecciones")]
    [ApiController]
    public class InspeccionesUnidadesController : ControllerBase
    {
        private readonly InspeccionesUnidadesService _inspeccionesUnidadesService;

        public InspeccionesUnidadesController(InspeccionesUnidadesService inspeccionesUnidadesService)
        {
            _inspeccionesUnidadesService = inspeccionesUnidadesService;
        }

        [HttpPost("Store")]
        [Authorize]
        public async Task<ActionResult<dynamic>> Store(JsonObject data)
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                await _inspeccionesUnidadesService.Create(Globals.JsonData(data), User);

                objReturn.Title     = "Nueva inspección";
                objReturn.Message   = "Inspección creada exitosamente";
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

        // ENDPOINT PARA APIS EXTERNAS
        [HttpPost("StoreFromRequerimientos")]
        public async Task<ActionResult<dynamic>> StoreFromRequerimientos(JsonObject data)
        {
            try
            {
                await _inspeccionesUnidadesService.CreateFromRequerimientos(Globals.JsonData(data), User);
                return true;
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("Find")]
        public async Task<ActionResult<dynamic>> Find(JsonObject data)
        {
            try
            {
                dynamic argData = Globals.JsonData(data);

                string id = Globals.ParseGuid(argData.idInspeccionUnidad);

                return await _inspeccionesUnidadesService.Find(id);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("FindSelector")]
        public async Task<ActionResult<dynamic>> FindSelector(JsonObject data)
        {
            try
            {
                dynamic argData = Globals.JsonData(data);

                string id       = Globals.ParseGuid(argData.idInspeccionUnidad);
                string fields   = Globals.ToString(argData.fields);

                return await _inspeccionesUnidadesService.FindSelectorById(id, fields);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPost("FindLastInspeccionByIds")]
        public async Task<ActionResult<List<dynamic>>> FindLastInspeccionByIds(JsonObject data)
        {
            try
            {
                var objData         = Globals.JsonData(data);
                List<string> lstIds = JsonConvert.DeserializeObject<List<string>>(Globals.ToString(objData.lstIds));

                return await _inspeccionesUnidadesService.FindLastInspeccionByIds(lstIds);
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }

        [HttpPost("List")]
        public async Task<ActionResult<List<dynamic>>> List()
        {
            try
            {
                return await _inspeccionesUnidadesService.List();
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }

        [HttpPost("ListSelector")]
        public async Task<ActionResult<List<dynamic>>> ListSelector(JsonObject data)
        {
            try
            {
                dynamic argData = Globals.JsonData(data);

                string id       = Globals.ParseGuid(argData.idInspeccionUnidad);
                string fields   = Globals.ToString(argData.fields);

                return await _inspeccionesUnidadesService.ListSelector(id, fields);
            }
            catch (Exception exception)
            {

                return BadRequest(exception.Message);
            }
        }
    }
}
