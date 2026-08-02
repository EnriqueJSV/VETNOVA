using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Consultas_DAL
    {

        #region Variables privadas
        // Atributos de la tablas
        private int _iId_Consulta, _iId_Cita;
        private string _sDiagnostico, _sTratamiento, _sObservaciones;

        // Atributos generales en todas las clases
        private string _sValorScalar, _sAxn, _sMsjError;
        private DataTable _dtDatos;
        private int _iId_UsuarioGlobal;
        #endregion
        public int iId_Consulta { get => _iId_Consulta; set => _iId_Consulta = value; }
        public int iId_Cita { get => _iId_Cita; set => _iId_Cita = value; }
        public string sDiagnostico { get => _sDiagnostico; set => _sDiagnostico = value; }
        public string sTratamiento { get => _sTratamiento; set => _sTratamiento = value; }
        public string sObservaciones { get => _sObservaciones; set => _sObservaciones = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAxn { get => _sAxn; set => _sAxn = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public int iId_UsuarioGlobal { get => _iId_UsuarioGlobal; set => _iId_UsuarioGlobal = value; }

    }
}
