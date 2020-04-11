using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaModelo;

namespace CapaVista
{
    
    public partial class Combo : UserControl
    {
        LogicaCombo cm = new LogicaCombo();
        string tbl ;
        string cmp1 ;
        string cmp2;
        public Combo()
        {
            InitializeComponent();
         
     

        }
      
        public void llenarse(string tabla, string campo1, string campo2) {

            tbl = tabla;
            cmp1 = campo1;
            cmp2 = campo2;
          

           
            Cmb_auto.ValueMember = "numero";
            Cmb_auto.DisplayMember = "nombre";

            string[] items = cm.items(tabla,campo1, campo2);



            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    if (items[i] != "")
                    {
                        Cmb_auto.Items.Add(items[i]);
                    }
                }

            }

            var dt2 = cm.enviar(tabla, campo1, campo2);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row[campo1]) + "-"+ Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));


            }

            Cmb_auto.AutoCompleteCustomSource = coleccion;
            Cmb_auto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cmb_auto.AutoCompleteSource = AutoCompleteSource.CustomSource;





        }


        public string obtenerU() {

            string ob = "";
            string ob2 = "";
            char op;


            ob = Cmb_auto.Text;
            
            //   String ultimo = ob.substring(ob.length() - 1);

            ob2= ob.Substring(ob.Length-1);

            return ob2;

        }

        public string obtenerP() {

            string ob = "";
            string ob2 = "";
            char op;


            op = Cmb_auto.Text[0];
            ob = op.ToString();


            return ob;

        }

    }
}
