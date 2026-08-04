using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Usuarios_BLL
    {
        public void IniciarSesion(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /*MENSAJE DE CONTROL DE ERRORES*/
                obj_Usuarios_DAL.sMsjError = string.Empty;

                /*DEFINIMOS LOS OBJETOS QUE NOS COMUNICAN CON LA BASE DE DATOS*/
                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                /*
                 * DEFINIMOS EL NOMBRE DEL PROCEDIMIENTO ALMACENADO A EJECUTAR EN BASE DE DATOS
                 * EL NOMBRE DEL PROCEDIMIENTO SE BUSCA Y OBTIENE DEL ARCHIVO DE CONFIGURACION DE LA APLICACION
                 */
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LOGIN_Usuarios"].ToString();

                obj_BD_DAL.sNomTabla = "Login"; // ExecuteDataAdapter lo necesita para nombrar la tabla del DataSet

                /*DEFINIMOS LA ESTRUCTURA QUE VA A TENER EL DATATABLE DE PARAMETROS QUE ENVIAREMOS AL PROCEDIMIENTO ALMACENADO
                 */
                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL); /*Crea la estructura del datatable que contiene la lista de parametros que requiere el sp*/

                /*AGREGAMOS AL DATATABLE LA LISTA DE PARAMETROS QUE REQUIERE EL PROCEDIMIENTO ALMACENADO*/
                /*
                 Orden: (0) Nombre del parámetro (nombre del parámetro del procedimiento almacenado)
                        (1) Código del tipo de dato del parámetro a enviar (varchar, nvarchar, char: 6 | int: 1 | float, decimal, numeric: 2 | datetime: 8 | boolean: 9)
                        (2) Valor del parámetro (valor real que vamos a enviar al procedimiento almacenado)
                 */
                obj_BD_DAL.DT_Param.Rows.Add("@Nombre_Usuario", "6", obj_Usuarios_DAL.sNombre_Usuario);
                obj_BD_DAL.DT_Param.Rows.Add("@Contrasena", "6", obj_Usuarios_DAL.sContrasena);

                /*EJECUTAR EN BASE DE DATOS LA INSTRUCCION*/
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);


                /*RECUPERAMOS LA INFORMACION IMPORTANTE DEL RESULTADO DE LA EJECUCION EN BASE DE DATOS*/
                obj_Usuarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();

                //---------------------------------------

                if (string.IsNullOrEmpty(obj_Usuarios_DAL.sMsjError))
                {
                    DataTable dt = obj_BD_DAL.DS.Tables["Login"];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Columns.Count >= 2)
                        {
                            // Login exitoso: el SP devolvio Id_Usuario e Id_Rol
                            obj_Usuarios_DAL.iId_Usuario = Convert.ToInt32(dt.Rows[0][0]);
                            obj_Usuarios_DAL.iId_Rol = Convert.ToInt32(dt.Rows[0][1]);
                            obj_Usuarios_DAL.sValorScalar = obj_Usuarios_DAL.iId_Usuario.ToString();
                        }
                        else
                        {
                            // -1 (credenciales incorrectas) o 0 (error del CATCH), una sola columna
                            obj_Usuarios_DAL.sValorScalar = dt.Rows[0][0].ToString();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                obj_Usuarios_DAL.sMsjError = ex.ToString();
            }
        }

        public void CerrarSesion(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                obj_Usuarios_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CERRAR_Sesion"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Usuario", "1", obj_Usuarios_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteNonQuery(ref obj_BD_DAL);

                obj_Usuarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Usuarios_DAL.sMsjError = ex.ToString();
            }
        }

        public void CargaDatosUsuario(ref cls_Usuarios_DAL obj_Usuarios_DAL)
        {
            try
            {
                /*MENSAJE DE CONTROL DE ERRORES*/
                obj_Usuarios_DAL.sMsjError = string.Empty;

                /*DEFINIMOS LOS OBJETOS QUE NOS COMUNICAN CON LA BASE DE DATOS*/
                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                /*
                 * DEFINIMOS EL NOMBRE DEL PROCEDIMIENTO ALMACENADO A EJECUTAR EN BASE DE DATOS
                 * EL NOMBRE DEL PROCEDIMIENTO SE BUSCA Y OBTIENE DEL ARCHIVO DE CONFIGURACION DE LA APLICACION
                 */

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INFO_Usuarios"].ToString();

                /*DEFINIMOS LA ESTRUCTURA QUE VA A TENER EL DATATABLE DE PARAMETROS QUE ENVIAREMOS AL PROCEDIMIENTO ALMACENADO
                 */
                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL); /*Crea la estructura del datatable que contiene la lista de parametros que requiere el sp*/

                /*AGREGAMOS AL DATATABLE LA LISTA DE PARAMETROS QUE REQUIERE EL PROCEDIMIENTO ALMACENADO*/
                /*
                 Orden: (0) Nombre del parámetro (nombre del parámetro del procedimiento almacenado)
                        (1) Código del tipo de dato del parámetro a enviar (varchar, nvarchar, char: 6 | int: 1 | float, decimal, numeric: 2 | datetime: 8 | boolean: 9)
                        (2) Valor del parámetro (valor real que vamos a enviar al procedimiento almacenado)
                 */
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Usuario", "1", obj_Usuarios_DAL.iId_UsuarioGlobal);

                /*EJECUTAR EN BASE DE DATOS LA INSTRUCCION*/
                obj_BD_DAL.sNomTabla = "Usuarios";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                /*RECUPERAMOS LA INFORMACION IMPORTANTE DEL RESULTADO DE LA EJECUCION EN BASE DE DATOS*/
                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Usuarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Usuarios_DAL.dtDatos = null;
                }

                obj_Usuarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Usuarios_DAL.sMsjError = ex.ToString();
            }
        }
    }


}
