using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Usuarios_DAL
    {

        #region Variables privadas
        // Atributos de la tablas
        private int _iId_Usuario, _iId_Rol;
        private string _sNombre_Usuario, _sEmail, _sContrasena, _sEstado;

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
        public int iId_Usuario { get => _iId_Usuario; set => _iId_Usuario = value; }
        public int iId_Rol { get => _iId_Rol; set => _iId_Rol = value; }
        public string sNombre_Usuario { get => _sNombre_Usuario; set => _sNombre_Usuario = value; }
        public string sEmail { get => _sEmail; set => _sEmail = value; }
        public string sContrasena { get => _sContrasena; set => _sContrasena = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
    }
}
