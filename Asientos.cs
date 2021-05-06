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


        public List<Movimientos> movimientos = new List<Movimientos>() { get; set; };

        public Asientos(DateTime fecha, List<Movimientos> movimientos)
        {
            Fecha = fecha;
            Movimientos = movimientos;
        }

        internal static Asientos Ingresar(List<Cuentas> plandecuentas)

        {
            
            DateTime fecha = Validador.ingresodefecha();
            //Console.WriteLine(fecha.ToShortDateString());
            //Console.ReadLine();
            var movimiento = Movimientos.Ingresar(plandecuentas);
            
            movimientos.Add(new Movimientos(movimiento));


            return new Asientos(fecha,movimientos);
        }
    }
}