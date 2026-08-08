using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Especialidades_BLL
    {
        // SELECT sin filtro -> SP_LISTAR_ESPECIALIDADES
        public void ListarEspecialidades(ref cls_Especialidades_DAL obj_Especialidades_DAL)
        {
            try
            {
                obj_Especialidades_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Especialidades"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Especialidades";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Especialidades_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Especialidades_DAL.dtDatos = null;
                }

                obj_Especialidades_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especialidades_DAL.sMsjError = ex.ToString();
            }
        }

        // INSERT -> SP_INSERTA_ESPECIALIDADES
        // sValorScalar regresa: nuevo Id_Especialidad (@@IDENTITY), -1 = nombre duplicado
        public void InsertarEspecialidad(ref cls_Especialidades_DAL obj_Especialidades_DAL)
        {
            try
            {
                obj_Especialidades_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_Especialidades"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Especialidad", "6", obj_Especialidades_DAL.sEspecialidad);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Especialidades_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Especialidades_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Especialidades_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Especialidades_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especialidades_DAL.sMsjError = ex.ToString();
            }
        }

        // UPDATE -> SP_ACTUALIZA_ESPECIALIDADES
        // sValorScalar regresa: Id_Especialidad actualizado, -1 = nombre duplicado, -2 = registro ya no existe
        public void ActualizarEspecialidad(ref cls_Especialidades_DAL obj_Especialidades_DAL)
        {
            try
            {
                obj_Especialidades_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ACTUALIZA_Especialidades"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especialidad", "1", obj_Especialidades_DAL.iId_Especialidad);
                obj_BD_DAL.DT_Param.Rows.Add("@Especialidad", "6", obj_Especialidades_DAL.sEspecialidad);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Especialidades_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Especialidades_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Especialidades_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Especialidades_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especialidades_DAL.sMsjError = ex.ToString();
            }
        }

        // DELETE -> SP_ELIMINA_ESPECIALIDADES
        // sValorScalar regresa: Id_Especialidad eliminado, -1 = tiene veterinarios asociados, -2 = registro ya no existe
        public void EliminarEspecialidad(ref cls_Especialidades_DAL obj_Especialidades_DAL)
        {
            try
            {
                obj_Especialidades_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ELIMINA_Especialidades"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Especialidad", "1", obj_Especialidades_DAL.iId_Especialidad);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Especialidades_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Especialidades_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Especialidades_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Especialidades_DAL.sMsjError = ex.ToString();
            }
        }
    }
}
