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
        public List<Movimientos> movimientos = new List<Movimientos>();

        internal static Asientos Ingresar()

        {
            
            DateTime fecha = Validador.ingresodefecha();
            Console.WriteLine(fecha);
            Console.ReadLine();
            //var movimientos = Movimientos.Ingresar();
            


            return new Asientos();
        }
    }
}