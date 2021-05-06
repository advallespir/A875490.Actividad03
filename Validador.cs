using System;

namespace A875490.Actividad03
{
    internal class Validador
    {
        internal static DateTime ingresodefecha()
        {
            DateTime fechavalida;
            
            do
            {
                Console.WriteLine("Por favor ingrese la fecha para el asiento.");
                string fecha = Console.ReadLine();
                if (!DateTime.TryParse(fecha, out fechavalida))
            {
                Console.WriteLine("Por favor ingrese una fecha valida");
                    continue;
            }
                break;
            } while (true);
            return fechavalida;
        }
    }
}