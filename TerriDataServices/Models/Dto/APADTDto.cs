using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerriDataServices.Models.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class APADTDto
    {
        /// <summary>
        /// Código del Departamento
        /// </summary>
        public string CodDepartamento { get; set; }

        /// <summary>
        /// Nombre del Departamento
        /// </summary>
        public string Departamento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CodMunicipio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Municipio { get; set; }

        /// <summary>
        /// Area de fontera agricola (Miles de Hectáreas)
        /// </summary>
        public double Area { get; set; }
    }
}