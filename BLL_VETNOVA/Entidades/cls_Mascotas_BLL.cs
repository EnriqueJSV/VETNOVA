using BLL_VETNOVA.BD;
using DAL_VETNOVA.BD;
using DAL_VETNOVA.Entidades;
using System;
using System.Configuration;

namespace BLL_VETNOVA.Entidades
{
    public class cls_Mascotas_BLL
    {
        // SELECT sin filtro -> SP_LISTAR_MASCOTAS
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

        // COUNT de mascotas activas -> SP_CONTAR_MASCOTAS
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

        // INSERT -> SP_INSERTA_MASCOTAS
        // sValorScalar regresa: nuevo Id_Mascota (@@IDENTITY), o "0" si el CATCH del SP se disparo
        public void InsertarMascota(ref cls_Mascotas_DAL obj_Mascotas_DAL)
        {
            try
            {
                obj_Mascotas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_INSERTA_Mascotas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Propietario", "1", obj_Mascotas_DAL.iId_Propietario);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Raza", "1", obj_Mascotas_DAL.iId_Raza);
                obj_BD_DAL.DT_Param.Rows.Add("@Nombre", "6", obj_Mascotas_DAL.sNombre);
                obj_BD_DAL.DT_Param.Rows.Add("@Sexo", "6", obj_Mascotas_DAL.sSexo);
                obj_BD_DAL.DT_Param.Rows.Add("@Fecha_Nacimiento", "8", obj_Mascotas_DAL.dtFecha_Nacimiento.ToString("yyyy-MM-dd"));
                obj_BD_DAL.DT_Param.Rows.Add("@Peso", "6", obj_Mascotas_DAL.iPeso.ToString());
                obj_BD_DAL.DT_Param.Rows.Add("@Color", "6", obj_Mascotas_DAL.sColor);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Mascotas_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Mascotas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Mascotas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Mascotas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Mascotas_DAL.sMsjError = ex.ToString();
            }
        }

        // UPDATE -> SP_ACTUALIZA_MASCOTAS
        // sValorScalar regresa: Id_Mascota actualizado, -2 = registro ya no existe
        public void ActualizarMascota(ref cls_Mascotas_DAL obj_Mascotas_DAL)
        {
            try
            {
                obj_Mascotas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ACTUALIZA_Mascotas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Mascota", "1", obj_Mascotas_DAL.iId_Mascota);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Propietario", "1", obj_Mascotas_DAL.iId_Propietario);
                obj_BD_DAL.DT_Param.Rows.Add("@Id_Raza", "1", obj_Mascotas_DAL.iId_Raza);
                obj_BD_DAL.DT_Param.Rows.Add("@Nombre", "6", obj_Mascotas_DAL.sNombre);
                obj_BD_DAL.DT_Param.Rows.Add("@Sexo", "6", obj_Mascotas_DAL.sSexo);
                obj_BD_DAL.DT_Param.Rows.Add("@Fecha_Nacimiento", "8", obj_Mascotas_DAL.dtFecha_Nacimiento.ToString("yyyy-MM-dd"));
                obj_BD_DAL.DT_Param.Rows.Add("@Peso", "6", obj_Mascotas_DAL.iPeso.ToString());
                obj_BD_DAL.DT_Param.Rows.Add("@Color", "6", obj_Mascotas_DAL.sColor);
                obj_BD_DAL.DT_Param.Rows.Add("@Estado", "4", obj_Mascotas_DAL.sEstado);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Mascotas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Mascotas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Mascotas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Mascotas_DAL.sMsjError = ex.ToString();
            }
        }

        // DELETE -> SP_ELIMINA_MASCOTAS
        // sValorScalar regresa: Id_Mascota eliminado, -1 = tiene citas asociadas, -2 = registro ya no existe
        public void EliminarMascota(ref cls_Mascotas_DAL obj_Mascotas_DAL)
        {
            try
            {
                obj_Mascotas_DAL.sMsjError = string.Empty;

                cls_BDVETNOVA_DAL obj_BD_DAL = new cls_BDVETNOVA_DAL();
                cls_BDVETNOVA_BLL obj_BD_BLL = new cls_BDVETNOVA_BLL();

                obj_BD_DAL.sNomSP = ConfigurationManager.AppSettings["SP_ELIMINA_Mascotas"].ToString();

                obj_BD_BLL.CrearDatatable(ref obj_BD_DAL);

                obj_BD_DAL.DT_Param.Rows.Add("@Id_Mascota", "1", obj_Mascotas_DAL.iId_Mascota);
                obj_BD_DAL.DT_Param.Rows.Add("@IdUsuarioGlobal", "1", obj_Mascotas_DAL.iId_UsuarioGlobal);

                obj_BD_BLL.ExecuteScalar(ref obj_BD_DAL);

                obj_Mascotas_DAL.sValorScalar = obj_BD_DAL.sValorScalar.ToString();
                obj_Mascotas_DAL.sMsjError = obj_BD_DAL.sMsjError.ToString();
            }
            catch (Exception ex)
            {
                obj_Mascotas_DAL.sMsjError = ex.ToString();
            }
        }
    }
}