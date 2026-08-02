using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DAL_VETNOVA.BD;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_VETNOVA.BD
{
    public class cls_BDVETNOVA_BLL
    {

        //Para el insert a una tabla sin identity, delete o update
        public void ExecuteNonQuery(ref cls_BDVETNOVA_DAL obj_BD_DAL)
        {
            try
            {
                obj_BD_DAL.Obj_CNX = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_AUT"].ToString().Trim());

                if (obj_BD_DAL.Obj_CNX.State == ConnectionState.Closed)
                {
                    obj_BD_DAL.Obj_CNX.Open();
                }

                obj_BD_DAL.Obj_CMD = new SqlCommand(obj_BD_DAL.sNomSP, obj_BD_DAL.Obj_CNX);  // Instanciar el elemento SQLdata Adapter

                obj_BD_DAL.Obj_CMD.CommandType = CommandType.StoredProcedure; // Esta linea realiza SEGURIDAD, Al asignarle el comandType
                                                                              // le asigna nuevamente ya la variable asignada 


                #region AGREGAR PARÁMETROS

                if (obj_BD_DAL.DT_Param != null)
                {
                    SqlDbType TipoDatoSQL = SqlDbType.VarChar;

                    foreach (DataRow dr in obj_BD_DAL.DT_Param.Rows)
                    {
                        #region Definición de tipos de Datos del SQL

                        switch (dr[1])
                        {
                            case "1":
                                {
                                    TipoDatoSQL = SqlDbType.Int;
                                    break;
                                }
                            case "2":
                                {
                                    TipoDatoSQL = SqlDbType.Decimal;
                                    break;
                                }
                            case "3":
                                {
                                    TipoDatoSQL = SqlDbType.Float;
                                    break;
                                }
                            case "4":
                                {
                                    TipoDatoSQL = SqlDbType.Char;
                                    break;
                                }
                            case "5":
                                {
                                    TipoDatoSQL = SqlDbType.NChar;
                                    break;
                                }
                            case "6":
                                {
                                    TipoDatoSQL = SqlDbType.VarChar;
                                    break;
                                }
                            case "7":
                                {
                                    TipoDatoSQL = SqlDbType.NVarChar;
                                    break;
                                }
                            case "8":
                                {
                                    TipoDatoSQL = SqlDbType.DateTime;
                                    break;
                                }
                            case "9":
                                {
                                    TipoDatoSQL = SqlDbType.Bit;
                                    break;
                                }
                            case "10":
                                {
                                    TipoDatoSQL = SqlDbType.Money;
                                    break;
                                }
                            case "11":
                                {
                                    TipoDatoSQL = SqlDbType.TinyInt;
                                    break;
                                }
                            default:
                                break;
                        }

                        #endregion

                        obj_BD_DAL.Obj_CMD.Parameters.Add(dr[0].ToString(),             // nombre del parametro
                                                       TipoDatoSQL                  // el tipo de datos que entiende el sql - resultado del switch
                                                       ).Value = dr[2].ToString(); // el valor del parametro
                    }
                }

                #endregion


                obj_BD_DAL.Obj_CMD.ExecuteNonQuery();


                //Si todo sale bien, limpiamos el mensaje de error para que no exista ninguno.
                obj_BD_DAL.sMsjError = string.Empty;

            }
            catch (SqlException a)
            {
                obj_BD_DAL.sMsjError = a.Message.ToString();
            }
            finally
            {
                if (obj_BD_DAL.Obj_CNX.State == ConnectionState.Open)
                {
                    obj_BD_DAL.Obj_CNX.Close();
                }

                obj_BD_DAL.Obj_CNX.Dispose();
            }
        }
        //Para el insert a una tabla con identity
        public void ExecuteScalar(ref cls_BDVETNOVA_DAL obj_BD_DAL)
        {
            try
            {
                obj_BD_DAL.Obj_CNX = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_AUT"].ToString().Trim());

                if (obj_BD_DAL.Obj_CNX.State == ConnectionState.Closed)
                {
                    obj_BD_DAL.Obj_CNX.Open();
                }

                obj_BD_DAL.Obj_CMD = new SqlCommand(obj_BD_DAL.sNomSP, obj_BD_DAL.Obj_CNX);  // Instanciar el elemento SQLdata Adapter

                obj_BD_DAL.Obj_CMD.CommandType = CommandType.StoredProcedure; // Esta linea realiza SEGURIDAD, Al asignarle el comandType
                                                                              // le asigna nuevamente ya la variable asignada 


                #region AGREGAR PARÁMETROS

                if (obj_BD_DAL.DT_Param != null)
                {
                    SqlDbType TipoDatoSQL = SqlDbType.VarChar;

                    foreach (DataRow dr in obj_BD_DAL.DT_Param.Rows)
                    {
                        #region Definición de tipos de Datos del SQL

                        switch (dr[1])
                        {
                            case "1":
                                {
                                    TipoDatoSQL = SqlDbType.Int;
                                    break;
                                }
                            case "2":
                                {
                                    TipoDatoSQL = SqlDbType.Decimal;
                                    break;
                                }
                            case "3":
                                {
                                    TipoDatoSQL = SqlDbType.Float;
                                    break;
                                }
                            case "4":
                                {
                                    TipoDatoSQL = SqlDbType.Char;
                                    break;
                                }
                            case "5":
                                {
                                    TipoDatoSQL = SqlDbType.NChar;
                                    break;
                                }
                            case "6":
                                {
                                    TipoDatoSQL = SqlDbType.VarChar;
                                    break;
                                }
                            case "7":
                                {
                                    TipoDatoSQL = SqlDbType.NVarChar;
                                    break;
                                }
                            case "8":
                                {
                                    TipoDatoSQL = SqlDbType.DateTime;
                                    break;
                                }
                            case "9":
                                {
                                    TipoDatoSQL = SqlDbType.Bit;
                                    break;
                                }
                            case "10":
                                {
                                    TipoDatoSQL = SqlDbType.Money;
                                    break;
                                }
                            case "11":
                                {
                                    TipoDatoSQL = SqlDbType.TinyInt;
                                    break;
                                }
                            default:
                                break;
                        }

                        #endregion

                        obj_BD_DAL.Obj_CMD.Parameters.Add(dr[0].ToString(),             // nombre del parametro
                                                                        TipoDatoSQL                  // el tipo de datos que entiende el sql - resultado del switch
                                                                        ).Value = dr[2].ToString(); // el valor del parametro
                    }
                }

                #endregion

                obj_BD_DAL.sValorScalar = obj_BD_DAL.Obj_CMD.ExecuteScalar().ToString();

                //Si todo sale bien, limpiamos el mensaje de error para que no exista ninguno.
                obj_BD_DAL.sMsjError = string.Empty;

            }
            catch (SqlException a)
            {

                obj_BD_DAL.sMsjError = a.Message.ToString();
            }
            finally
            {
                if (obj_BD_DAL.Obj_CNX.State == ConnectionState.Open)
                {
                    obj_BD_DAL.Obj_CNX.Close();
                }

                obj_BD_DAL.Obj_CNX.Dispose();
            }
        }
        //Para los select con o sin where
        public void ExecuteDataAdapter(ref cls_BDVETNOVA_DAL obj_BD_DAL)
        {
            try
            {
                obj_BD_DAL.Obj_CNX = new SqlConnection(ConfigurationManager.ConnectionStrings["SQL_AUT"].ToString().Trim());

                if (obj_BD_DAL.Obj_CNX.State == ConnectionState.Closed)
                {
                    obj_BD_DAL.Obj_CNX.Open();
                }
                obj_BD_DAL.Obj_DAP = new SqlDataAdapter(obj_BD_DAL.sNomSP, obj_BD_DAL.Obj_CNX);
                obj_BD_DAL.Obj_DAP.SelectCommand.CommandType = CommandType.StoredProcedure;

                #region AGREGAR PARÁMETROS
                if (obj_BD_DAL.DT_Param != null)
                {
                    SqlDbType TipoDatoSQL = SqlDbType.VarChar;
                    foreach (DataRow dr in obj_BD_DAL.DT_Param.Rows)
                    {
                        #region Definición de tipos de Datos del SQL
                        switch (dr[1])
                        {
                            case "1":
                                {
                                    TipoDatoSQL = SqlDbType.Int;
                                    break;
                                }
                            case "2":
                                {
                                    TipoDatoSQL = SqlDbType.Decimal;
                                    break;
                                }
                            case "3":
                                {
                                    TipoDatoSQL = SqlDbType.Float;
                                    break;
                                }
                            case "4":
                                {
                                    TipoDatoSQL = SqlDbType.Char;
                                    break;
                                }
                            case "5":
                                {
                                    TipoDatoSQL = SqlDbType.NChar;
                                    break;
                                }
                            case "6":
                                {
                                    TipoDatoSQL = SqlDbType.VarChar;
                                    break;
                                }
                            case "7":
                                {
                                    TipoDatoSQL = SqlDbType.NVarChar;
                                    break;
                                }
                            case "8":
                                {
                                    TipoDatoSQL = SqlDbType.DateTime;
                                    break;
                                }
                            case "9":
                                {
                                    TipoDatoSQL = SqlDbType.Bit;
                                    break;
                                }
                            case "10":
                                {
                                    TipoDatoSQL = SqlDbType.Money;
                                    break;
                                }
                            case "11":
                                {
                                    TipoDatoSQL = SqlDbType.TinyInt;
                                    break;
                                }
                            default:
                                break;
                        }
                        #endregion
                        obj_BD_DAL.Obj_DAP.SelectCommand.Parameters.Add(dr[0].ToString(),             // nombre del parametro
                                                                        TipoDatoSQL                  // el tipo de datos que entiende el sql - resultado del switch
                                                                        ).Value = dr[2].ToString(); // el valor del parametro
                    }
                }
                #endregion

                obj_BD_DAL.DS = new DataSet();

                obj_BD_DAL.Obj_DAP.Fill(obj_BD_DAL.DS, obj_BD_DAL.sNomTabla);

                obj_BD_DAL.sMsjError = string.Empty;
            }
            catch (SqlException ex)
            {

                obj_BD_DAL.sMsjError = ex.ToString().Trim();
            }
            finally
            {
                if (obj_BD_DAL.Obj_CNX.State == ConnectionState.Open)
                {
                    obj_BD_DAL.Obj_CNX.Close();
                }

                obj_BD_DAL.Obj_CNX.Dispose();
            }
        }
        //Método genérico para pasar la lista de parámetros
        public void CrearDatatable(ref cls_BDVETNOVA_DAL obj_BD_DAL)
        {
            obj_BD_DAL.DT_Param = new DataTable("PARAMETROS");
            obj_BD_DAL.DT_Param.Columns.Add("Nom_Param"); //COLUMNA 0
            obj_BD_DAL.DT_Param.Columns.Add("Tipo_Dato_Param"); //COLUMNA 1
            obj_BD_DAL.DT_Param.Columns.Add("Valor_Param"); //COLUMNA 2    
        }

    }
}
