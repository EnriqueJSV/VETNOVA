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
    public class cls_Auditoria_BLL
    {
        public void ListarAuditoria(ref cls_Auditoria_DAL obj_Auditoria_DAL)
        {
            try
            {
                obj_Auditoria_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Auditoria"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Auditoria";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Auditoria_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Auditoria_DAL.dtDatos = null;
                }

                obj_Auditoria_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Auditoria_DAL.sMsjError = ex.ToString();
            }
        }
    }
}