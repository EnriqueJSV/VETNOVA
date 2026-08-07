using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Razas_BLL
    {
        // SELECT (con JOIN a Especies) -> SP_LISTAR_RAZAS
        public void ListarRazas(ref cls_Razas_DAL obj_Razas_DAL)
        {
            try
            {
                obj_Razas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Razas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Razas";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Razas_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Razas_DAL.dtDatos = null;
                }

                obj_Razas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Razas_DAL.sMsjError = ex.ToString();
            }
        }

        // INSERT -> SP_INSERTA_RAZAS
        // sValorScalar regresa: nuevo Id_Raza (@@IDENTITY), -1 = nombre duplicado dentro de la misma especie
        public void InsertarRaza(ref cls_Razas_DAL obj_Razas_DAL)
        {
            try
            {
                obj_Razas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_Razas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Raza", "6", obj_Razas_DAL.sRaza);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especie", "1", obj_Razas_DAL.iId_Especie);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Razas_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Razas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Razas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Razas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Razas_DAL.sMsjError = ex.ToString();
            }
        }

        // UPDATE -> SP_ACTUALIZA_RAZAS
        // sValorScalar regresa: Id_Raza actualizado, -1 = nombre duplicado, -2 = registro ya no existe
        public void ActualizarRaza(ref cls_Razas_DAL obj_Razas_DAL)
        {
            try
            {
                obj_Razas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ACTUALIZA_Razas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Raza", "1", obj_Razas_DAL.iId_Raza);
                obj_BD_DAL.DT_Param.Rows.Add("@Raza", "6", obj_Razas_DAL.sRaza);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especie", "1", obj_Razas_DAL.iId_Especie);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Razas_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Razas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Razas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Razas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Razas_DAL.sMsjError = ex.ToString();
            }
        }

        // DELETE -> SP_ELIMINA_RAZAS
        // sValorScalar regresa: Id_Raza eliminado, -1 = tiene mascotas asociadas, -2 = registro ya no existe
        public void EliminarRaza(ref cls_Razas_DAL obj_Razas_DAL)
        {
            try
            {
                obj_Razas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ELIMINA_Razas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Raza", "1", obj_Razas_DAL.iId_Raza);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Razas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Razas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Razas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Razas_DAL.sMsjError = ex.ToString();
            }
        }
    }
}