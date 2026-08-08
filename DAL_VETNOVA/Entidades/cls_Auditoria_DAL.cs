using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Auditoria_DAL
    {

        #region Variables privadas
        // Atributos de la tablas
        private int _iId_Auditoria, _iId_Usuario;
        private string _sAccion, _sDescripcion;
        private string _sFiltro;
        private DateTime _dtFechaDesde, _dtFechaHasta;

        // Atributos generales en todas las clases
        private string _sValorScalar, _sAxn, _sMsjError;
        private DataTable _dtDatos;
        private int _iId_UsuarioGlobal;
        #endregion

        public int iId_Auditoria { get => _iId_Auditoria; set => _iId_Auditoria = value; }
        public int iId_Usuario { get => _iId_Usuario; set => _iId_Usuario = value; }
        public string sAccion { get => _sAccion; set => _sAccion = value; }
        public string sDescripcion { get => _sDescripcion; set => _sDescripcion = value; }
        public DateTime dtFechaDesde { get => _dtFechaDesde; set => _dtFechaDesde = value; }
        public DateTime dtFechaHasta { get => _dtFechaHasta; set => _dtFechaHasta = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAxn { get => _sAxn; set => _sAxn = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public int iId_UsuarioGlobal { get => _iId_UsuarioGlobal; set => _iId_UsuarioGlobal = value; }
        public string sFiltro { get => _sFiltro; set => _sFiltro = value; }
    }
}
