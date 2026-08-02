using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Mascotas_DAL
    {

        #region Variables privadas
        // Atributos de la tablas
        private int _iId_Mascota, _iId_Propietario, _iId_Raza, _iPeso;
        private string _sNombre, _sSexo, _sColor, _sEstado;
        private DateTime _dtFecha_Nacimiento;

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
        public int iId_Mascota { get => _iId_Mascota; set => _iId_Mascota = value; }
        public int iId_Propietario { get => _iId_Propietario; set => _iId_Propietario = value; }
        public int iId_Raza { get => _iId_Raza; set => _iId_Raza = value; }
        public int iPeso { get => _iPeso; set => _iPeso = value; }
        public string sNombre { get => _sNombre; set => _sNombre = value; }
        public string sSexo { get => _sSexo; set => _sSexo = value; }
        public string sColor { get => _sColor; set => _sColor = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
        public DateTime dtFecha_Nacimiento { get => _dtFecha_Nacimiento; set => _dtFecha_Nacimiento = value; }
    }
}
