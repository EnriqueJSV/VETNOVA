using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Mascotas_BLL
    {
        public void ContarMascotas(ref cls_Mascotas_DAL obj_Mascotas_DAL)
        {
            try
            {
                obj_Mascotas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CONTAR_Mascotas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Mascotas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Mascotas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Mascotas_DAL.sMsjError = ex.ToString();
            }
        }

        public void ListarMascotas(ref cls_Mascotas_DAL obj_Mascotas_DAL)
        {
            try
            {
                obj_Mascotas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Mascotas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Mascotas";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Mascotas_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Mascotas_DAL.dtDatos = null;
                }

                obj_Mascotas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Mascotas_DAL.sMsjError = ex.ToString();
            }
        }
    }
}