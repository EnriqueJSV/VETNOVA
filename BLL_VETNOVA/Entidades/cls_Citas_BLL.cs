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
    public class cls_Citas_BLL
    {
        public void ContarCitasHoy(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                /*MENSAJE DE CONTROL DE ERRORES*/
                obj_Citas_DAL.sMsjError = string.Empty;

                /*DEFINIMOS LOS OBJETOS QUE NOS COMUNICAN CON LA BASE DE DATOS*/
                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                /*
                 * DEFINIMOS EL NOMBRE DEL PROCEDIMIENTO ALMACENADO A EJECUTAR EN BASE DE DATOS
                 * EL NOMBRE DEL PROCEDIMIENTO SE BUSCA Y OBTIENE DEL ARCHIVO DE CONFIGURACION DE LA APLICACION
                 */
                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_CONTAR_Citas"].ToString();

                /*SP_CONTAR_CITAS NO RECIBE PARAMETROS, PERO IGUAL CREAMOS
                  LA ESTRUCTURA DEL DATATABLE PARA MANTENER EL MISMO PATRON*/
                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                /*EJECUTAR EN BASE DE DATOS LA INSTRUCCION*/
                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                /*RECUPERAMOS LA INFORMACION IMPORTANTE DEL RESULTADO DE LA EJECUCION EN BASE DE DATOS*/
                obj_Citas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Citas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Citas_DAL.sMsjError = ex.ToString();
            }

        }

        public void ListarCitasHoy(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                obj_Citas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_CitasHoy"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.sNomTabla = "CitasHoy";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Citas_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Citas_DAL.dtDatos = null;
                }

                obj_Citas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Citas_DAL.sMsjError = ex.ToString();
            }
        }

        public void ListarFiltrarCitas(string sFiltro, ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                obj_Citas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                if (string.IsNullOrEmpty(sFiltro))
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_LISTAR_Citas"].ToString();
                }
                else
                {
                    obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_FILTRAR_Citas"].ToString();

                    obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);
                    obj_BD_DAL.DT_Param.Rows.Add("@Filtro", "6", sFiltro);
                }

                obj_BD_DAL.sNomTabla = "Citas";
                obj_BD_BLL.ExecuteDataAdapter(ref obj_BD_DAL);

                if (obj_BD_DAL.sMsjError == string.Empty)
                {
                    obj_Citas_DAL.dtDatos = obj_BD_DAL.DS.Tables[0];
                }
                else
                {
                    obj_Citas_DAL.dtDatos = null;
                }

                obj_Citas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Citas_DAL.sMsjError = ex.ToString();
            }
        }

        public void InsertaCita(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                obj_Citas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_Citas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Mascota", "1", obj_Citas_DAL.iId_Mascota);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Veterinario", "1", obj_Citas_DAL.iId_Veterinario);
                obj_BD_DAL.DT_Param.Rows.Add("@Fecha", "6", obj_Citas_DAL.dtFecha.ToString("yyyy-MM-dd"));
                obj_BD_DAL.DT_Param.Rows.Add("@Hora", "6", obj_Citas_DAL.dtHora.ToString("HH:mm"));
                obj_BD_DAL.DT_Param.Rows.Add("@Motivo", "6", obj_Citas_DAL.sMotivo);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado_Cita", "6", obj_Citas_DAL.sEstado_Cita);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Citas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Citas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Citas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Citas_DAL.sMsjError = ex.ToString();
            }
        }

        public void ActualizaCita(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                obj_Citas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ACTUALIZA_Citas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Cita", "1", obj_Citas_DAL.iId_Cita);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Mascota", "1", obj_Citas_DAL.iId_Mascota);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Veterinario", "1", obj_Citas_DAL.iId_Veterinario);
                obj_BD_DAL.DT_Param.Rows.Add("@Fecha", "6", obj_Citas_DAL.dtFecha.ToString("yyyy-MM-dd"));
                obj_BD_DAL.DT_Param.Rows.Add("@Hora", "6", obj_Citas_DAL.dtHora.ToString("HH:mm"));
                obj_BD_DAL.DT_Param.Rows.Add("@Motivo", "6", obj_Citas_DAL.sMotivo);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado_Cita", "6", obj_Citas_DAL.sEstado_Cita);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Citas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Citas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Citas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Citas_DAL.sMsjError = ex.ToString();
            }
        }

        public void EliminaCita(ref cls_Citas_DAL obj_Citas_DAL)
        {
            try
            {
                obj_Citas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ELIMINA_Citas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Cita", "1", obj_Citas_DAL.iId_Cita);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Citas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Citas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Citas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Citas_DAL.sMsjError = ex.ToString();
            }
        }

    }


}