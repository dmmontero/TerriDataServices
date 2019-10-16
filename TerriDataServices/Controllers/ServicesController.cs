namespace TerriDataServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
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

        /// <summary>
        /// Obtiene la información (de manera asincrona) de frontera agricola agrupada por Departamento.
        /// Esta informacion se obtiene del servicio Rest publicado en https://geoservicios.upra.gov.co/arcgis/rest/services/ordenamiento_productivo
        /// </summary>
        /// <returns>Retrona una coleccion con la infromación de Hectáreas de frontera Agrícola por Departamento</returns>
        [HttpGet]
        [ActionName("FronteraAgricolaAsync")]
        public async Task<IHttpActionResult> GetFronteraAgricolaAsync()
        {
            IList<FronteraAgricolaDto> respuesta = new List<FronteraAgricolaDto>();
            try
            {
                respuesta = await Task.Run(() => UpraHelper.ObtenerFronteraAgricola());

                if (respuesta == null || respuesta.Count == 0)
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(respuesta);
        }

        /// <summary>
        /// Obtiene informacion de Áreas potenciales para Adecuación de Tierras con fines de irrigación
        /// Esta información se obtiene del servicio Rest publicado en https://geoservicios.upra.gov.co/arcgis/rest/services/adecuacion_tierras_rurales/apadt_irrigacion_2018/MapServer/0
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("HectareasAdecuadasIrrigacion")]
        public IHttpActionResult GetHectareasAdecuadasIrrigacion()
        {
            IList<APADTDto> respuesta = new List<APADTDto>();
            try
            {
                respuesta = UpraHelper.ObtenerAPADT();
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
