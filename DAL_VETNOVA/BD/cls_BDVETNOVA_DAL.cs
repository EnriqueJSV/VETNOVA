using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.BD
{
    public class cls_BDVETNOVA_DAL
    {
        #region VARIABLES PRIVADAS
        private SqlConnection _obj_CNX; //objeto que controla la cadena de conexión
        private SqlCommand _obj_CMD; //objeto que controla el comando a ejecutar
        private SqlDataAdapter _obj_DAP; //Objeto DataAdapter
        private string _sNomSP, _sNomTabla, _sValorScalar; //Valores de nombre de store procedure, nombre de tabla, valor escalar
        private DataSet _DS; //Objeto DataSet
        private string _sMsjError; //Variable para el manejo de errores 
        private DataTable _DT_Param; //Datatable que controla la lista de parametros del store procedure
        #endregion

        #region VARIABLES PUBLICAS O CONSTRUCTORES
        public SqlConnection Obj_CNX { get => _obj_CNX; set => _obj_CNX = value; }
        public SqlCommand Obj_CMD { get => _obj_CMD; set => _obj_CMD = value; }
        public SqlDataAdapter Obj_DAP { get => _obj_DAP; set => _obj_DAP = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public string sNomSP { get => _sNomSP; set => _sNomSP = value; }
        public string sNomTabla { get => _sNomTabla; set => _sNomTabla = value; }
        public DataSet DS { get => _DS; set => _DS = value; }
        public DataTable DT_Param { get => _DT_Param; set => _DT_Param = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        #endregion
    }
}

