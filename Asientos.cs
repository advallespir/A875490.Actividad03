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

        public Asientos(DateTime fecha, List<Movimientos> inserciones)
        {
            Fecha = fecha;
            Inserciones = inserciones;
        }

        internal static Asientos Ingresar(List<Cuentas> plandecuentas)

        {
            List<Movimientos> inserciones = new List<Movimientos>();
            DateTime fecha = Validador.ingresodefecha();

            //Console.WriteLine(fecha.);
            //Console.ReadLine();
            decimal total = 0;
            bool salir = false;
            Console.Clear();
            do
            {
                
                decimal temporal = 0;

                Movimientos movimiento = Movimientos.Ingresar(plandecuentas);
                inserciones.Add(movimiento);

                mostrarMovimiento(inserciones,fecha);


                if (movimiento.TipoMovimiento)
                {
                    temporal = movimiento.Monto;
                }
                if (!movimiento.TipoMovimiento)
                {
                    temporal = movimiento.Monto * -1;
                }
                total = total + temporal;

                if (total == 0)
                {                                        
                    salir = Validador.PreguntaSiNo("Desea dejar de cargar movimientos al asiento? S/N");
                }

            } while (salir == false);

            return new Asientos(fecha, inserciones);
        }

        private static void mostrarMovimiento(List<Movimientos> inserciones, DateTime fecha)
        {

            Validador.Separador();
            Validador.DebeHaber(fecha);
            foreach (var movimiento in inserciones)
            {
                
                if (!movimiento.TipoMovimiento)
                {
                    Console.WriteLine($"                     |       {movimiento.Nombrecuenta}       |       {movimiento.Nombre}       |                               |      ${movimiento.Monto}");
                }
                if (movimiento.TipoMovimiento)
                {
                    Console.WriteLine($"                     |       {movimiento.Nombrecuenta}       |       {movimiento.Nombre}       |      ${movimiento.Monto}       |");
                }

            }
            
        }

        internal void MostrarAsiento(Asientos asiento)
        {
            Console.WriteLine(asiento.Fecha);



        }
    }
}