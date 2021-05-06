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

        public Movimientos(int codigo, decimal monto, string nombre, string ncuenta, bool movimiento) 
        {
            Codigo = codigo;
            Monto = monto;
            Nombre = nombre;
            Nombrecuenta = ncuenta;
            Movimiento = movimiento;
        }


        public decimal Monto { get; set; }
        public int Codigo { get; set; }
        public string Nombrecuenta { get; set; }
        public string Nombre { get; set; }
        public bool Movimiento { get; set; }

        internal static Movimientos Ingresar(List<Cuentas> plandecuentas)
        {
            Console.WriteLine("Por favor ingrese el tipo de cuenta");
            string ncuenta = "";
            int codigo = Validador.tipodecuenta(plandecuentas);
            foreach (var Cuentas in plandecuentas)
            {
                if (Cuentas.Codigo == codigo)
                {
                    ncuenta = Cuentas.Nombre;
                    break;
                }
            }
            decimal monto = Validador.Monto();            
            string nombre = Validador.AgregarCadena("Por favor ingrese la cuenta", 4,20);
            bool movimiento = Validador.AgregarMovimiento();
            

           
            //Falta agregar todos los movimientos de un dia, y checkear si suman 0.
            return new Movimientos(codigo, monto, nombre, ncuenta, movimiento);
            
        }
    }
}