using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace A875490.Actividad03
{

    class Cuentas
    {
        public Cuentas(string codigo, string nombre, string tipo)
        {
            Codigo = int.Parse(codigo);
            Nombre = nombre;
            Tipo = tipo;
            
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }



       


        internal void leerPlanDeCuentas()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "PlanDeCuentas.txt");
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split("|");

                //plandecuentas.Add(Agregardatosacuenta(col[0], col[1], col[2]));
            }
        }

        internal static object AgregarCuenta(string v1, string v2, string v3)
        {
            return new Cuentas(v1, v2, v3);

        }
    }
}
