using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A875490.Actividad03
{
    internal class Asientos
    {
        public DateTime Fecha { get; set; }


        public static List<Movimientos> Inserciones  { get; set; }

        public Asientos(DateTime fecha, List<Movimientos> movimientos)
        {
            Fecha = fecha;
            Inserciones = movimientos;
        }

        internal static Asientos Ingresar(List<Cuentas> plandecuentas)

        {
            
            DateTime fecha = Validador.ingresodefecha();
            //Console.WriteLine(fecha.ToShortDateString());
            //Console.ReadLine();
            var movimiento = Movimientos.Ingresar(plandecuentas);

            Inserciones.Add(new Movimientos(movimiento));


            return new Asientos(fecha, Inserciones);
        }
    }
}