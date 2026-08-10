using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_VETNOVA.Entidades
{
    public class cls_Grafico_DAL
    {
        #region Variables privadas
        private DataTable _dtDatos;
        private string _sMsjError;
        #endregion


        public DataTable dtDatos { get => _dtDatos; set => _dtDatos = value; }
        public string sMsjError { get => _sMsjError; set => _sMsjError = value; }
    }
}
