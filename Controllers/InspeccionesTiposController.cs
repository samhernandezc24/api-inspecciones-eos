﻿using API.Inspecciones.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using Workcube.Libraries;

namespace API.Inspecciones.Controllers
{
    [Route("api/Inspecciones/Tipos")]
    [ApiController]
    public class InspeccionesTiposController : ControllerBase
    {
        private readonly InspeccionesTiposService _inspeccionesTiposService;

        public InspeccionesTiposController(InspeccionesTiposService inspeccionesTiposService)
        {
            _inspeccionesTiposService = inspeccionesTiposService;
        }        

        [HttpPost("List")]
        [Authorize]
        public async Task<ActionResult<dynamic>> List()
        {
            JsonReturn objReturn = new JsonReturn();

            try
            {
                List<dynamic> lstInspeccionesTipos = await _inspeccionesTiposService.List();

                objReturn.Result = new
                {
                    inspeccionesTipos = lstInspeccionesTipos,
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
                await _inspeccionesTiposService.Create(Globals.JsonData(data), User);

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
                await _inspeccionesTiposService.Update(Globals.JsonData(data), User);

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
                await _inspeccionesTiposService.UpdateOrden(Globals.JsonData(data), User);

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
                await _inspeccionesTiposService.Delete(Globals.JsonData(data), User);

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

        // APIS EXTERNAS
        [HttpPost("ListRequerimientos")]
        public async Task<ActionResult<dynamic>> ListRequerimientos()
        {
            try
            {
                return await _inspeccionesTiposService.List();
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
