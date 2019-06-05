namespace TerriDataServices.Models.Dto
{
    /// <summary>
    /// Defines the <see cref="FronteraAgricolaDto" />
    /// Estructura que contiene la información de FDrontera Agrícola por Departamento
    /// </summary>
    public class FronteraAgricolaDto
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
        /// Area de fontera agricola (Miles de Hectáreas)
        /// </summary>
        public double Area { get; set; }
    }
}
