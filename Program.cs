using System;

namespace A875490.Actividad03
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Un estudio contable ha contratado a su empresa para la confección de una suite de aplicaciones contables:
            1)	A partir de los asientos ingresados por el usuario, una aplicación debe generar/actualizar un archivo de texto llamado “Diario.txt” con el siguiente formato por línea:
            NroAsiento|Fecha|CodigoCuenta|Debe|Haber
            Utilizará el archivo de plan de cuentas adjunto para validar los datos ingresados (recuerde especialmente: Debe = Haber y Activo = Pasivo + PN)
            */
                        
            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido a estudio contable.");
                Console.WriteLine("Por favor seleccione alguna de las opciones para operar.");
                Console.WriteLine("1) Ver libro diario");
                Console.WriteLine("2) Añadir entrada");
                Console.WriteLine("3) Salir");
                Console.Write("\r\nSelecciona una opcion: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.ReadLine();
                        return;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
