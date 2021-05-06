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

        internal static int tipodecuenta(System.Collections.Generic.List<Cuentas> plandecuentas)
        {
            int codigoint;
            do
            {            
            Console.Write("Ingrese el codigo de cuenta:");
            string codigo = Console.ReadLine();
                if (!int.TryParse(codigo, out codigoint))
                {
                    Console.WriteLine("Por favor ingrese un codigo numerico.");
                    continue;
                }
                if (codigoint > 34 || codigoint<10)
                {
                    Console.WriteLine("Por favor ingrese un codigo numerico.");
                    continue;
                }

                foreach (var Cuentas in plandecuentas)
                {
                    if (Cuentas.Codigo == codigoint)
                    {
                        Console.WriteLine("Codigo encontrado!!!!!.");
                        string nombre = Cuentas.Nombre;
                        return codigoint;
                    }
                    
                }
                Console.Write("Codigo incorrecto");


                break;
            } while (true);
            return codigoint;
        }

        internal static decimal monto()
        {
            decimal monto;
            
            do
            {
                Console.WriteLine("Por favor ingrese el monto:");
                string montoaux = Console.ReadLine();
                if (!decimal.TryParse(montoaux, out monto))
                {
                    Console.WriteLine("Por favor ingrese un codigo numerico.");
                    continue;
                }
                else if (monto<0)
                {
                    Console.WriteLine("Por favor ingrese un valor mayor a 0.");
                    continue;
                }
                break;

            } while (true);
            return monto;
        }
    }
}