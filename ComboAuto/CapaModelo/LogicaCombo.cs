using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaControlador;

namespace CapaModelo
{
    public class LogicaCombo
    {
        string[] llenado = new string[30];

        Sentencias sn = new Sentencias();



        public string[] items(string tabla, string campo1, string campo2)
        {
            string[] Items = sn.llenarCmb(tabla, campo1, campo2);

            return Items;


        }

        public DataTable enviar(string tabla, string campo1, string campo2) {

            

            var dt1= sn.obtener(tabla, campo1, campo2);

            return dt1;
        }

        public string[] items2(string tabla, string campo1, string campo2, string condicion2, string valorcon)
        {
            string[] Items = sn.llenarCmb2(tabla, campo1, campo2, condicion2, valorcon);

            return Items;


        }

        public DataTable enviar2(string tabla, string campo1, string campo2, string condicion2, string valorcon)
        {



            var dt1 = sn.obtener2(tabla, campo1, campo2, condicion2,valorcon);

            return dt1;
        }
    }
}
