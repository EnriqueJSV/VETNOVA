using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Propietarios_DAL
    {

        #region Variables privadas
        // Atributos de la tablas
        private int _iId_Propietario, _iId_Tipo_Identificacion;
        private string _sIdentificacion, _sNombre, _sApellido1, _sApellido2, _sTelefono, _sEmail, _sDireccion, _sEstado;
        private string _sFiltro;

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
        public int iId_Propietario { get => _iId_Propietario; set => _iId_Propietario = value; }
        public int iId_Tipo_Identificacion { get => _iId_Tipo_Identificacion; set => _iId_Tipo_Identificacion = value; }
        public string sNombre { get => _sNombre; set => _sNombre = value; }
        public string sApellido1 { get => _sApellido1; set => _sApellido1 = value; }
        public string sApellido2 { get => _sApellido2; set => _sApellido2 = value; }
        public string sTelefono { get => _sTelefono; set => _sTelefono = value; }
        public string sEmail { get => _sEmail; set => _sEmail = value; }
        public string sDireccion { get => _sDireccion; set => _sDireccion = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public string sFiltro { get => _sFiltro; set => _sFiltro = value; }
        public string sIdentificacion { get => _sIdentificacion; set => _sIdentificacion = value; }
    }
}
