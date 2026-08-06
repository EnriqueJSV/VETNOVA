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
    public class cls_Consultas_BLL
    {
        // Trae TODAS las consultas (sin filtro). El historial por mascota se
        // arma en memoria en el PL, cruzando esto contra el DataTable de citas
        // que ya trae frmConsultas, para no crear un SP nuevo solo para eso.
        public void ListarConsultas(ref cls_Consultas_DAL obj_Consultas_DAL)
        {
            try
            {
                obj_Consultas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Consultas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "Consultas";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Consultas_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Consultas_DAL.dtDatos = null;
                }

                obj_Consultas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Consultas_DAL.sMsjError = ex.ToString();
            }
        }

        public void InsertaConsulta(ref cls_Consultas_DAL obj_Consultas_DAL)
        {
            try
            {
                obj_Consultas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_Consultas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Cita", "1", obj_Consultas_DAL.iId_Cita);
                obj_BD_DAL.DT_Param.Rows.Add("@Diagnostico", "6", obj_Consultas_DAL.sDiagnostico);
                obj_BD_DAL.DT_Param.Rows.Add("@Tratamiento", "6", obj_Consultas_DAL.sTratamiento);
                obj_BD_DAL.DT_Param.Rows.Add("@Observaciones", "6", obj_Consultas_DAL.sObservaciones);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Consultas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Consultas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Consultas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Consultas_DAL.sMsjError = ex.ToString();
            }
        }
    }
}