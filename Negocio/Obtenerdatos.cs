

namespace Negocio
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Globalization;
    using AccesoDatos;


    public class Obtenerdatos
    {
        string _sp;

        public DataSet ObtenerDatosConsulta(string nomprod, string[] parametro)
        {
            _sp = nomprod;
            var conn = new Conectabd();
            var command = new SqlCommand
            {
                CommandTimeout = 0,
                Connection = conn.OpenDb(),
                CommandType = CommandType.StoredProcedure,
                CommandText = _sp
            };
            switch (_sp)
            {

                #region "apartados_x_entregas"
                case "PA_Obtener_Apartados_X_Entregar":
                    command.Parameters.Add("@fechaActual", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@status", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@tiempo", SqlDbType.VarChar).Value = parametro[2];
                    break;
                case "PA_Obtener_configuracion_Img_apart":
                    break;
                case "PA_Obtener_configuracion_colores":
                    break;
                case "PA_Obtener_Indicadores_Apartados_Bodega":
                    command.Parameters.Add("@fechaActual", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@status", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@tiempo", SqlDbType.VarChar).Value = parametro[2];
                    break;

                #endregion

                #region "Clasificacion Equipos"

                case "PA_Obtener_Grilla_Clasificacion_Tipo_Equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaClasificacionEquipos":
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_tipo_clasificacion", SqlDbType.VarChar).Value = parametro[1];
                    break;
                case "PA_EliminaClasificacionEquipo":
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[0];
                    break;

                case "PA_Obtener_Clasificacion_tipo_equipos":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                #endregion

                #region "Tipo de Equipos"
                case "PA_Obtener_Tipo_Equipos":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;

                case "PA_Obtener_Grilla_Tipo_equipos":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaTipoEquipo":
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_tipo_equipo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    break;
                case "PA_EliminaTipoEquipo":
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[0];
                    break;
                #endregion

                #region "Proveedores"
                case "PA_Obtener_Grilla_Proveedores":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaProveedores":
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_proveedor", SqlDbType.VarChar).Value = parametro[1];
                    break;
                case "PA_EliminaProveedores":
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[0];
                    break;
                #endregion

                #region "Marca"
                case "PA_Obtener_Marcas":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;

                case "PA_Obtener_Grilla_Marcas":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaMarca":
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_marca", SqlDbType.VarChar).Value = parametro[1];
                    break;
                case "PA_EliminaMarca":
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[0];
                    break;
                #endregion

                #region Modelos
                case "PA_Obtener_Grilla_Modelos":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaModelo":
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_modelo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    break;
                case "PA_EliminaModelo":
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[0];
                    break;

                #endregion

                #region "Estatus"
                case "PA_Obtener_Grilla_Estatus":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaEstatu":
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_estatus", SqlDbType.VarChar).Value = parametro[1];
                    break;
                case "PA_EliminaEstatu":
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[0];
                    break;
                #endregion

                #region "Dispobilidades"

                case "PA_Obtener_Grilla_Disponibilidades":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaDisponibilidad":
                    command.Parameters.Add("@id_disponibilidad", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_disponibilidad", SqlDbType.VarChar).Value = parametro[1];
                    break;
                case "PA_EliminaDisponibilidad":
                    command.Parameters.Add("@id_disponibilidad", SqlDbType.VarChar).Value = parametro[0];
                    break;
                #endregion

                #region "PerteneceA"

                case "PA_Obtener_Grilla_perteneceA":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "PA_InsertaOModificaPerteneceA":
                    command.Parameters.Add("@id_pertence", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@descripcion_pertenece", SqlDbType.VarChar).Value = parametro[1];
                    break;
                case "PA_EliminaPerteneceA":
                    command.Parameters.Add("@id_pertence", SqlDbType.VarChar).Value = parametro[0];
                    break;
                #endregion

                #region "Censo Equipo"
                case "PA_Obtener_localizacion":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;

                case "PA_Obtener_Centro_Trabajos":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    break;

                case "PA_Obtener_Responsables":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    break;

                case "PA_Obtener_Clasificacion_tipo_equipos_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    break;
                case "PA_Obtener_tipo_equipos_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    break;
                case "PA_Obtener_proveedores_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    break;
                case "PA_Obtener_marcas_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    break;
                case "PA_Obtener_modelo_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[5];
                    break;
                case "PA_Obtener_estatus_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[6];
                    break;
                case "PA_Obtener_disponibilidad_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[6];
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[7];
                    break;
                case "PA_Obtener_fecha_adquision_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[6];
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[7];
                    command.Parameters.Add("@id_disponibilidad", SqlDbType.VarChar).Value = parametro[8];
                    break;
                case "PA_Obtener_perteneceA_censo_equipo":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[6];
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[7];
                    command.Parameters.Add("@id_disponibilidad", SqlDbType.VarChar).Value = parametro[8];
                    command.Parameters.Add("@fecha_adquisicion", SqlDbType.VarChar).Value = parametro[9];
                    break;


                case "PA_Obtener_Grilla_Censo_Equipos":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[6];
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[7];
                    command.Parameters.Add("@id_disponibilidad", SqlDbType.VarChar).Value = parametro[8];
                    command.Parameters.Add("@fecha_adquisicion", SqlDbType.VarChar).Value = parametro[9];
                    command.Parameters.Add("@id_pertence", SqlDbType.VarChar).Value = parametro[10];
                    break;
                case "PA_InsertaOModificaEquipo":
                    command.Parameters.Add("@id_equipo", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[6];
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[7];
                    command.Parameters.Add("@id_localizacion", SqlDbType.VarChar).Value = parametro[8];
                    command.Parameters.Add("@id_disponibilidad", SqlDbType.VarChar).Value = parametro[9];
                    command.Parameters.Add("@n_serie", SqlDbType.VarChar).Value = parametro[10];
                    command.Parameters.Add("@fecha_baja_ipn", SqlDbType.VarChar).Value = parametro[11];
                    command.Parameters.Add("@fecha_adquisicion", SqlDbType.VarChar).Value = parametro[12];
                    command.Parameters.Add("@num_inventario", SqlDbType.VarChar).Value = parametro[13];
                    command.Parameters.Add("@inv_coordinacion", SqlDbType.VarChar).Value = parametro[14];
                    command.Parameters.Add("@num_factura", SqlDbType.VarChar).Value = parametro[15];
                    command.Parameters.Add("@id_pertence", SqlDbType.VarChar).Value = parametro[16];
                    command.Parameters.Add("@ruta_oficio_baja", SqlDbType.VarChar).Value = parametro[17];
                    break;
                case "PA_EliminaEquipoCenso":
                    command.Parameters.Add("@id_equipo", SqlDbType.VarChar).Value = parametro[0];
                    break;

                case "Pa_obtener_numero_serie_autocompletar":
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@n_serie", SqlDbType.VarChar).Value = parametro[6];
                    break;
                case "Pa_obtener_datos_equipo":
                    command.Parameters.Add("@id_equipo", SqlDbType.VarChar).Value = parametro[0];
                    break;
                case "Pa_inserta_evidencia_factura":
                    command.Parameters.Add("@id_equipo", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@fecha_factura", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@numero_factura", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@ruta_archivo", SqlDbType.VarChar).Value = parametro[3];
                    break;
                case "PA_Obtener_rutas_facturas":
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[5];
                    break;

                #endregion

                #region Indicadores
                case "PA_OBTENER_DATOS_GRAFICO":
                    command.Parameters.Add("@bandera", SqlDbType.VarChar).Value = parametro[0];
                    command.Parameters.Add("@id_centro_trabajo", SqlDbType.VarChar).Value = parametro[1];
                    command.Parameters.Add("@id_clasificacion_tipo_equipo", SqlDbType.VarChar).Value = parametro[2];
                    command.Parameters.Add("@id_tipo_equipo", SqlDbType.VarChar).Value = parametro[3];
                    command.Parameters.Add("@id_proveedor", SqlDbType.VarChar).Value = parametro[4];
                    command.Parameters.Add("@id_marca", SqlDbType.VarChar).Value = parametro[5];
                    command.Parameters.Add("@id_modelo", SqlDbType.VarChar).Value = parametro[6];
                    command.Parameters.Add("@id_estatus", SqlDbType.VarChar).Value = parametro[7];
                    command.Parameters.Add("@id_disponibilidad", SqlDbType.VarChar).Value = parametro[8];
                    command.Parameters.Add("@fecha_adquisicion", SqlDbType.VarChar).Value = parametro[9];
                    command.Parameters.Add("@id_pertence", SqlDbType.VarChar).Value = parametro[10];
                    command.Parameters.Add("@tipo_grafico", SqlDbType.VarChar).Value = parametro[11];
                    command.Parameters.Add("@fila", SqlDbType.VarChar).Value = parametro[12];
                    command.Parameters.Add("@columna", SqlDbType.VarChar).Value = parametro[13];

                    break;


                    #endregion
            }
            var dAdapter = new SqlDataAdapter(command) { SelectCommand = command };
            var dset = new DataSet();
            dAdapter.Fill(dset);
            conn.CloseDb();
            return dset;
        }
    }
}
