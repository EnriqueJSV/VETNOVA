using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Razas_DAL
    {

        #region Variables privadas
        // Atributos de la tablas
        private int _iId_Raza, _iId_Especie;
        private string _sRaza, _sEstado;

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
        public int iId_Raza { get => _iId_Raza; set => _iId_Raza = value; }
        public int iId_Especie { get => _iId_Especie; set => _iId_Especie = value; }
        public string sRaza { get => _sRaza; set => _sRaza = value; }
        public string sEstado { get => _sEstado; set => _sEstado = value; }
    }
}
