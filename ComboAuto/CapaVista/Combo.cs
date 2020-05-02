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
        public void texto(string texto)
        {
            string text = texto;
            Cmb_auto.Text = text;


        }

        public string texto2() {

            string texto1 = " ";
            string texto2 = Cmb_auto.Text;

            if (texto2 == null )
            {


                return texto1;


            }
            else {

                return texto2;

            }
            
            
        }
        public void limpiar() {


            Cmb_auto.DataSource = null;
            Cmb_auto.Items.Clear();
            Cmb_auto.Refresh();
        

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

        public void llenarse2(string tabla, string campo1, string campo2, string condicion2, string valorcon)
        {

            tbl = tabla;
            cmp1 = campo1;
            cmp2 = campo2;



            Cmb_auto.ValueMember = "numero";
            Cmb_auto.DisplayMember = "nombre";

            string[] items = cm.items2(tabla, campo1, campo2, condicion2, valorcon);



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

            var dt2 = cm.enviar2(tabla, campo1, campo2, condicion2, valorcon);
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in dt2.Rows)
            {

                coleccion.Add(Convert.ToString(row[campo1]) + "-" + Convert.ToString(row[campo2]));
                coleccion.Add(Convert.ToString(row[campo2]) + "-" + Convert.ToString(row[campo1]));


            }

            Cmb_auto.AutoCompleteCustomSource = coleccion;
            Cmb_auto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Cmb_auto.AutoCompleteSource = AutoCompleteSource.CustomSource;





        }




        public string obtener() {
            string ob = "";
            ob = Cmb_auto.Text;

            return ob;

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


        public string ObtenerIndif()
        {

            string iddef;
            string obp = obtenerP();


            char al = char.Parse(obp);

            if (char.IsLetter(al))
            {
                string cosa = obtener();

                char[] delimitador = { '-' };
                int i = 0;
                string[] partes = cosa.Split(delimitador);

                string id = partes[1] + "-" + partes[0];

                iddef= id;
            }

            else
            {

                string completo = obtener();

                iddef = completo;

            }

            return iddef;



        }
        public int existe(string buscar)
        {


            int encontrado = Cmb_auto.FindString(buscar);



            return encontrado;

        }

        private void Cmb_auto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
