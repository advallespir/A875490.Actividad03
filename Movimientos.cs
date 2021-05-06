using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A875490.Actividad03
{
    public class Movimientos
    {
        public Movimientos(object movimiento)
        {
            Movimiento = movimiento;
        }

        public Movimientos(int codigo, decimal monto, string nombre) 
        {
            Codigo = codigo;
            Monto = monto;
            Nombre = nombre;
        }


        public decimal Monto { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public object Movimiento { get; }

        internal static object Ingresar(System.Collections.Generic.List<Cuentas> plandecuentas)
        {
            Console.WriteLine("Por favor ingrese el tipo de cuenta");

            int codigo = Validador.tipodecuenta(plandecuentas);
            decimal monto = Validador.monto();
            string nombre = "";
            foreach (var Cuentas in plandecuentas)
            {
                if (Cuentas.Codigo == codigo)
                {
                    nombre = Cuentas.Nombre;
                    break;
                }
            }
           

            return new Movimientos(codigo, monto, nombre);
            
        }
    }
}