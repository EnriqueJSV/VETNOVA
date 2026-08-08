using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Veterinarios_BLL
    {
        public void ContarVeterinarios(ref cls_Veterinarios_DAL obj_Veterinarios_DAL)
        {
            try
            {
                obj_Veterinarios_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CONTAR_Veterinarios"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Veterinarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Veterinarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Veterinarios_DAL.sMsjError = ex.ToString();
            }
        }

        public void ListarVeterinarios(ref cls_Veterinarios_DAL obj_Veterinarios_DAL)
        {
            try
            {
                obj_Veterinarios_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Veterinarios"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Veterinarios";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Veterinarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Veterinarios_DAL.dtDatos = null;
                }

                obj_Veterinarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Veterinarios_DAL.sMsjError = ex.ToString();
            }
        }

        public void NuevoVeterinario(ref cls_Veterinarios_DAL obj_Veterinarios_DAL)
        {
            try
            {
                // Mensaje control de errores
                obj_Veterinarios_DAL.sMsjError = string.Empty;

                //Definicion de objetos que comunican con la base de datos
                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                // Nombre del procedimiento almacenado, se obtiene desde el archivo de configuracion
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_Veterinarios"].ToString();

                // Definir la estructura del datatable de parametros
                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                // Se agrega al datatable la lista de parametros que requiere el procedimiento almacenado
                /* Orden: (0) Nombre del parametro(nombre del parametro del procedimiento almacenado)
                    (1) Codigo del tipo de dato del parametro a enviar(varchar, nvarchar, char: 6 | int: 1 | float, decimal,numeric: 2 |
                        datetime: 8 | boolean: 9)
                    (2) Valor del parametro a enviar
                    */
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Tipo_Identificacion", "1", obj_Veterinarios_DAL.iId_Tipo_Identificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@Identificacion", "6", obj_Veterinarios_DAL.sIdentificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@Nombre", "6", obj_Veterinarios_DAL.sNombre);
                obj_BD_DAL.DT_Param.Rows.Add("@Apellido1", "6", obj_Veterinarios_DAL.sApellido1);
                obj_BD_DAL.DT_Param.Rows.Add("@Apellido2", "6", obj_Veterinarios_DAL.sApellido2);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especialidad", "1", obj_Veterinarios_DAL.iId_Especialidad);
                obj_BD_DAL.DT_Param.Rows.Add("@Telefono", "6", obj_Veterinarios_DAL.sTelefono);
                obj_BD_DAL.DT_Param.Rows.Add("@Email", "6", obj_Veterinarios_DAL.sEmail);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "6", obj_Veterinarios_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Veterinarios_DAL.iId_UsuarioGlobal);

                // Ejecutar la instruccion en la base de datos
                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                // Recuperamos la info importante del resultado 
                obj_Veterinarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Veterinarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();

                /* Si el resultado de valorScalar es 0 o -1 significa que da error en base de datos */
                if (obj_Veterinarios_DAL.sValorScalar == "0" || obj_Veterinarios_DAL.sValorScalar == "-1")
                {
                    obj_Veterinarios_DAL.iId_Veterinario = 0;
                    obj_Veterinarios_DAL.sAxn = "I";
                    return;
                }

                if (obj_Veterinarios_DAL.sMsjError == string.Empty)
                {
                    obj_Veterinarios_DAL.sAxn = "U";
                    obj_Veterinarios_DAL.iId_Veterinario = Convert.ToInt32(obj_BD_DAL.sValorScalar);
                }
                else
                {
                    obj_Veterinarios_DAL.sAxn = "I";
                }

            }
            catch (Exception ex)
            {
                obj_Veterinarios_DAL.sMsjError = ex.ToString();
            }
        }

        public void ModificarVeterinario(ref cls_Veterinarios_DAL obj_Veterinarios_DAL)
        {
            try
            {
                // Mensaje control de errores
                obj_Veterinarios_DAL.sMsjError = string.Empty;

                //Definicion de objetos que comunican con la base de datos
                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                // Nombre del procedimiento almacenado, se obtiene desde el archivo de configuracion
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ACTUALIZA_Veterinarios"].ToString();

                // Definir la estructura del datatable de parametros
                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                // Se agrega al datatable la lista de parametros que requiere el procedimiento almacenado
                /* Orden: (0) Nombre del parametro(nombre del parametro del procedimiento almacenado)
                    (1) Codigo del tipo de dato del parametro a enviar(varchar, nvarchar, char: 6 | int: 1 | float, decimal,numeric: 2 |
                        datetime: 8 | boolean: 9)
                    (2) Valor del parametro a enviar
                    */
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Veterinario", "1", obj_Veterinarios_DAL.iId_Veterinario);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Tipo_Identificacion", "1", obj_Veterinarios_DAL.iId_Tipo_Identificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@Identificacion", "6", obj_Veterinarios_DAL.sIdentificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@Nombre", "6", obj_Veterinarios_DAL.sNombre);
                obj_BD_DAL.DT_Param.Rows.Add("@Apellido1", "6", obj_Veterinarios_DAL.sApellido1);
                obj_BD_DAL.DT_Param.Rows.Add("@Apellido2", "6", obj_Veterinarios_DAL.sApellido2);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especialidad", "1", obj_Veterinarios_DAL.iId_Especialidad);
                obj_BD_DAL.DT_Param.Rows.Add("@Telefono", "6", obj_Veterinarios_DAL.sTelefono);
                obj_BD_DAL.DT_Param.Rows.Add("@Email", "6", obj_Veterinarios_DAL.sEmail);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "6", obj_Veterinarios_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Veterinarios_DAL.iId_UsuarioGlobal);

                // Ejecutar la instruccion en la base de datos
                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                // Recuperamos la info importante del resultado 
                obj_Veterinarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Veterinarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();

            }
            catch (Exception ex)
            {
                obj_Veterinarios_DAL.sMsjError = ex.ToString();
            }
        }

        public void EliminarVeterinarios(ref cls_Veterinarios_DAL obj_Veterinarios_DAL)
        {
            try
            {
                // Mensaje control de errores
                obj_Veterinarios_DAL.sMsjError = string.Empty;

                //Definicion de objetos que comunican con la base de datos
                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                // Nombre del procedimiento almacenado, se obtiene desde el archivo de configuracion
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ELIMINA_Veterinarios"].ToString();

                // Definir la estructura del datatable de parametros
                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                // Se agrega al datatable la lista de parametros que requiere el procedimiento almacenado
                /* Orden: (0) Nombre del parametro(nombre del parametro del procedimiento almacenado)
                    (1) Codigo del tipo de dato del parametro a enviar(varchar, nvarchar, char: 6 | int: 1 | float, decimal,numeric: 2 |
                        datetime: 8 | boolean: 9)
                    (2) Valor del parametro a enviar
                    */
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Veterinario", "1", obj_Veterinarios_DAL.iId_Veterinario);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Veterinarios_DAL.iId_UsuarioGlobal);

                // Ejecutar la instruccion en la base de datos
                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                // Recuperamos la info importante del resultado 
                obj_Veterinarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Veterinarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();

            }
            catch (Exception ex)
            {
                obj_Veterinarios_DAL.sMsjError = ex.ToString();
            }
        }
    }
}