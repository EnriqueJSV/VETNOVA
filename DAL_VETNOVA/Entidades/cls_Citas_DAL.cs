using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Citas_DAL
    {

        #region Variables privadas

        // Atributos de la tablas
        private int _iId_Cita, _iId_Mascota, _iId_Veterinario;
        private DateTime _dtFecha, _dtHora;
        private string _sMotivo, _sEstado_Cita;

        // Atributos generales en todas las clases
        private string _sValorScalar, _sAxn, _sMsjError;
        private DataTable _dtDatos;
        private int _iId_UsuarioGlobal;
        #endregion

        public int iId_Cita { get => _iId_Cita; set => _iId_Cita = value; }
        public int iId_Mascota { get => _iId_Mascota; set => _iId_Mascota = value; }
        public int iId_Veterinario { get => _iId_Veterinario; set => _iId_Veterinario = value; }
        public DateTime dtFecha { get => _dtFecha; set => _dtFecha = value; }
        public DateTime dtHora { get => _dtHora; set => _dtHora = value; }
        public string sMotivo { get => _sMotivo; set => _sMotivo = value; }
        public string sEstado_Cita { get => _sEstado_Cita; set => _sEstado_Cita = value; }
        public string sValorScalar { get => _sValorScalar; set => _sValorScalar = value; }
        public string sAxn { get => _sAxn; set => _sAxn = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public int iId_UsuarioGlobal { get => _iId_UsuarioGlobal; set => _iId_UsuarioGlobal = value; }

    }
}
