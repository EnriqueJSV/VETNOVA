using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    obj_Tipos_Identificacion_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Tipos_Identificacion_DAL.dtDatos = null;
                }

                obj_Tipos_Identificacion_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Tipos_Identificacion_DAL.sMsjError = ex.ToString();
            }
        }

    }
}
