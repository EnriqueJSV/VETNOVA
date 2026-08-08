using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Especies_BLL
    {
        // SELECT sin filtro -> SP_LISTAR_ESPECIES
        public void ListarEspecies(ref cls_Especies_DAL obj_Especies_DAL)
        {
            try
            {
                obj_Especies_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Especies"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Especies";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Especies_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Especies_DAL.dtDatos = null;
                }

                obj_Especies_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especies_DAL.sMsjError = ex.ToString();
            }
        }

        // INSERT -> SP_INSERTA_ESPECIES
        // sValorScalar regresa: nuevo Id_Especie (@@IDENTITY), -1 = nombre duplicado
        public void InsertarEspecie(ref cls_Especies_DAL obj_Especies_DAL)
        {
            try
            {
                obj_Especies_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_Especies"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Especie", "6", obj_Especies_DAL.sEspecie);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Especies_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Especies_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Especies_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Especies_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especies_DAL.sMsjError = ex.ToString();
            }
        }

        // UPDATE -> SP_ACTUALIZA_ESPECIES
        // sValorScalar regresa: Id_Especie actualizado, -1 = nombre duplicado, -2 = registro ya no existe
        public void ActualizarEspecie(ref cls_Especies_DAL obj_Especies_DAL)
        {
            try
            {
                obj_Especies_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ACTUALIZA_Especies"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especie", "1", obj_Especies_DAL.iId_Especie);
                obj_BD_DAL.DT_Param.Rows.Add("@Especie", "6", obj_Especies_DAL.sEspecie);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Especies_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Especies_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Especies_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Especies_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especies_DAL.sMsjError = ex.ToString();
            }
        }

        // DELETE -> SP_ELIMINA_ESPECIES
        // sValorScalar regresa: Id_Especie eliminado, -1 = tiene razas asociadas, -2 = registro ya no existe
        public void EliminarEspecie(ref cls_Especies_DAL obj_Especies_DAL)
        {
            try
            {
                obj_Especies_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ELIMINA_Especies"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especie", "1", obj_Especies_DAL.iId_Especie);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Especies_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Especies_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Especies_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especies_DAL.sMsjError = ex.ToString();
            }
        }
    }
}