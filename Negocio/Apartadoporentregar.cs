namespace Negocio
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using Negocio.Model;

    public class Apartadoporentregar
    {
        Obtenerdatos obtenerdatos = new Obtenerdatos();

        public List<ConfiguracionTiempo> GetConfiguracion()
        {

            var datos = obtenerdatos.ObtenerDatosConsulta("PA_Obtener_configuracion_Img_apart", null);

            return (from DataRow row in datos.Tables[0].Rows
                    select new ConfiguracionTiempo
                    {
                        TiempoPantalla = row["MinPantalla"].ToString(),
                        TiempoImagen = row["MinImagen"].ToString(),
                        TiempoTranscurrido = row["MinTrancurridos"].ToString(),
                    }).ToList();
        }

        public List<ApartadoPorEntrega> GetApartadosEntregar(string[] parametros)
        {
            var datos = obtenerdatos.ObtenerDatosConsulta("PA_Obtener_Apartados_X_Entregar", parametros);

            return (from DataRow row in datos.Tables[0].Rows
                    select new ApartadoPorEntrega
                    {
                        NumApartado = row["NumApartado"].ToString(),
                        Nombrecliente = row["NombreCliente"].ToString(),
                        MinTranscurrido = row["MinTranscurrido"].ToString(),
                        NumOperador = row["NumOperador"].ToString(),

                    }).ToList();
        }

        public List<CriterioColores> getcriteriosColor()
        {
            var datos = obtenerdatos.ObtenerDatosConsulta("PA_Obtener_configuracion_colores", null);

            return (from DataRow row in datos.Tables[0].Rows
                    select new CriterioColores
                    {
                        ValMinimo = row["ValMinimo"].ToString(),
                        ValMax = row["ValMax"].ToString(),
                        ColorFondo = row["ColorFondo"].ToString(),
                        ColorLetra = row["ColorLetra"].ToString(),

                    }).ToList();
        }

        public List<Indicador> GetIndicadores(string[] parametros)
        {
            var datos = obtenerdatos.ObtenerDatosConsulta("PA_Obtener_Indicadores_Apartados_Bodega", parametros);

            return (from DataRow row in datos.Tables[0].Rows
                    select new Indicador
                    {
                        TiemPromEnt = row["TiemPromEnt"].ToString(),
                        AparLiqEntr = row["AparLiqEntr"].ToString(),
                        OperadoresActivos = row["OperadoresActivos"].ToString(),
                        Aparta_Oper = row["Aparta_Oper"].ToString(),

                    }).ToList();
        }





    }
}
