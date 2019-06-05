namespace TerriDataServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http;
    using TerriDataServices.Helpers;
    using TerriDataServices.Models.Dto;

    /// <summary>
    /// Defines the <see cref="ServicesController" />
    /// </summary>
    public class ServicesController : ApiController
    {
        /// <summary>
        /// Obtiene la información de frontera agricola agrupada por Departamento.
        /// Esta informacion se obtiene del servicio Rest publicado en https://geoservicios.upra.gov.co/arcgis/rest/services/ordenamiento_productivo
        /// </summary>
        /// <returns>The <see cref="IHttpActionResult"/>Retrona una coleccion con la infromación de Hectáreas de frontera Agrícola por Departamento</returns>
        [HttpGet]
        [ActionName("FronteraAgricola")]
        public IHttpActionResult GetFronteraAgricola()
        {
            IList<FronteraAgricolaDto> respuesta = new List<FronteraAgricolaDto>();
            try
            {
                respuesta = UpraHelper.ObtenerFronteraAgricola();
                if (respuesta == null || respuesta.Count == 0)
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(respuesta);
        }
    }
}
