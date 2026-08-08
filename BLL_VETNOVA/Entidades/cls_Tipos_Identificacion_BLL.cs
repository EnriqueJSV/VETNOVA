using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Tipos_Identificacion_BLL
    {

        public void ListarTipos_Identificacion(ref cls_Tipos_Identificacion_DAL obj_Tipos_Identificacion_DAL)
        {
            try
            {
                obj_Tipos_Identificacion_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Tipos_Identificacion"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Tipos_Identificacion";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_TiposIdentificacion_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_TiposIdentificacion_DAL.dtDatos = null;
                }

                obj_TiposIdentificacion_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_TiposIdentificacion_DAL.sMsjError = ex.ToString();
            }
        }

        // INSERT -> SP_INSERTA_TIPOS_IDENTIFICACION
        // sValorScalar regresa: nuevo Id_Tipo_Identificacion (@@IDENTITY), -1 = nombre duplicado
        public void InsertarTipoIdentificacion(ref cls_Tipos_Identificacion_DAL obj_TiposIdentificacion_DAL)
        {
            try
            {
                obj_TiposIdentificacion_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_TiposIdentificacion"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Tipo_Identificacion", "6", obj_TiposIdentificacion_DAL.sTipo_Identificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_TiposIdentificacion_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_TiposIdentificacion_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_TiposIdentificacion_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_TiposIdentificacion_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_TiposIdentificacion_DAL.sMsjError = ex.ToString();
            }
        }

        // UPDATE -> SP_ACTUALIZA_TIPOS_IDENTIFICACION
        // sValorScalar regresa: Id_Tipo_Identificacion actualizado, -1 = nombre duplicado, -2 = registro ya no existe
        public void ActualizarTipoIdentificacion(ref cls_Tipos_Identificacion_DAL obj_TiposIdentificacion_DAL)
        {
            try
            {
                obj_TiposIdentificacion_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ACTUALIZA_TiposIdentificacion"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Tipo_Identificacion", "1", obj_TiposIdentificacion_DAL.iId_Tipo_Identificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@Tipo_Identificacion", "6", obj_TiposIdentificacion_DAL.sTipo_Identificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_TiposIdentificacion_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_TiposIdentificacion_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_TiposIdentificacion_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_TiposIdentificacion_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_TiposIdentificacion_DAL.sMsjError = ex.ToString();
            }
        }

        // DELETE -> SP_ELIMINA_TIPOS_IDENTIFICACION
        // sValorScalar regresa: Id_Tipo_Identificacion eliminado, -1 = tiene propietarios o veterinarios asociados, -2 = registro ya no existe
        public void EliminarTipoIdentificacion(ref cls_Tipos_Identificacion_DAL obj_TiposIdentificacion_DAL)
        {
            try
            {
                obj_TiposIdentificacion_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ELIMINA_TiposIdentificacion"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Tipo_Identificacion", "1", obj_TiposIdentificacion_DAL.iId_Tipo_Identificacion);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_TiposIdentificacion_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_TiposIdentificacion_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_TiposIdentificacion_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_TiposIdentificacion_DAL.sMsjError = ex.ToString();
            }
        }
    }
}
