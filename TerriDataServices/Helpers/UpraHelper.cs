using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TerriDataServices.Models.Dto;

namespace TerriDataServices.Helpers
{
    public static class UpraHelper
    {
        public static IList<FronteraAgricolaDto> ObtenerFronteraAgricola()
        {
            //Crear cliente
            var client = new RestClient("https://geoservicios.upra.gov.co/arcgis/rest/services");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);
            var request = new RestRequest("ordenamiento_productivo/frontera_agricola_abril_2018/MapServer/0/query", Method.GET) { RequestFormat = DataFormat.Json };

            //Parámetros servicio
            request.AddParameter("f", "json"); // adds to POST or URL querystring based on Method
            request.AddParameter("outFields", "cod_depart,departamen,area_ha,elemento"); // adds to POST or URL querystring based on Method
            request.AddParameter("outSr", 4326); // adds to POST or URL querystring based on Method
            request.AddParameter("returnGeometry", false); // adds to POST or URL querystring based on Method
            request.AddParameter("where", "elemento = 'Frontera agrícola nacional'"); // adds to POST or URL querystring based on Method


            // Ejecutar solicitud
            IRestResponse response = client.Execute(request);
            var content = @response.Content; // raw content as string


            var obj = JToken.Parse(content);
            JObject features = JObject.Parse(obj.ToString());

            //Crear lista de Attributes
            var attrList = features["features"].Select(c => c["attributes"]).Select(attr => new AtributosDto
            {
                CodDepartamento = (string)attr["cod_depart"],
                Departamento = (string)attr["departamen"],
                AreaHa = (double)attr["area_ha"],
                Elemento = (string)attr["elemento"]
            }).ToList();

            //Query agreupado con los datos
            var data = (from at in attrList
                        group at by new { at.CodDepartamento, at.Departamento }
                        into grp
                        orderby grp.Key.CodDepartamento
                        select new FronteraAgricolaDto
                        {
                            CodDepartamento = grp.Key.CodDepartamento,
                            Departamento = grp.Key.Departamento,
                            Area = grp.Sum(a => a.AreaHa)
                        }
                         ).ToList();

            return data;
        }
    }
}