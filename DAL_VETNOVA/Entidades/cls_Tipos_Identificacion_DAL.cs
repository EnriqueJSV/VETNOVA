using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Tipos_Identificacion_DAL
    {

        #region Variables privadas
        // Atributos de la tablas
        private int _iId_Tipo_Identificacion;
        private string _sTipo_Identificacion, _sEstado;

        // Atributos generales en todas las clases
        private string _sValorScalar, _sAxn, _sMsjError;
        private DataTable _dtDatos;
        private int _iId_UsuarioGlobal;

        #endregion

        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAxn { get => _sAxn; set => _sAxn = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public int iId_UsuarioGlobal { get => _iId_UsuarioGlobal; set => _iId_UsuarioGlobal = value; }
        public int iId_Tipo_Identificacion { get => _iId_Tipo_Identificacion; set => _iId_Tipo_Identificacion = value; }
        public string sTipo_Identificacion { get => _sTipo_Identificacion; set => _sTipo_Identificacion = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
    }
}
