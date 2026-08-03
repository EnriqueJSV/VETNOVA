using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Propietarios_BLL
    {
        public void ContarPropietarios(ref cls_Propietarios_DAL obj_Propietarios_DAL)
        {
            try
            {
                obj_Propietarios_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CONTAR_Propietarios"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Propietarios_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Propietarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Propietarios_DAL.sMsjError = ex.ToString();
            }
        }

        public void ListarPropietarios(ref cls_Propietarios_DAL obj_Propietarios_DAL)
        {
            try
            {
                obj_Propietarios_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Propietarios"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Propietarios";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Propietarios_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Propietarios_DAL.dtDatos = null;
                }

                obj_Propietarios_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Propietarios_DAL.sMsjError = ex.ToString();
            }
        }
    }
}