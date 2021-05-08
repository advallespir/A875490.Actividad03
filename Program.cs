using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace A875490.Actividad03
{
    class Program
    {
        static List<Cuentas> plandecuentas = new List<Cuentas>();
        static Dictionary<int,Asientos> asientos = new Dictionary<int,Asientos>();
        static Librodiario librodiario = new Librodiario();
        static int nAsiento;
        static void Main(string[] args)
        {
            /*Un estudio contable ha contratado a su empresa para la confección de una suite de aplicaciones contables:
            1)	A partir de los asientos ingresados por el usuario, una aplicación debe generar/actualizar un archivo de texto llamado “Diario.txt” con el siguiente formato por línea:
            NroAsiento|Fecha|CodigoCuenta|Debe|Haber
            Utilizará el archivo de plan de cuentas adjunto para validar los datos ingresados (recuerde especialmente: Debe = Haber y Activo = Pasivo + PN)
            */

            /*Crea un folder en AppData\Roaming para guardar el libro diario, o lo lee si esta ahi*/


            crearLibroDiario();



            /*Creo los objetos para el plan de cuentas*/
            CrearPlanDeCuentas();






            do
            {
                Console.Clear();
                Console.WriteLine("Bienvenido a estudio contable.");
                Console.WriteLine("Por favor seleccione alguna de las opciones para operar.");
                Console.WriteLine("1) Ver libro diario");
                Console.WriteLine("2) Añadir asiento");
                Console.WriteLine("3) Leer plan de cuentas");
                Console.WriteLine("4) Salir");
                Console.Write("\r\nSelecciona una opcion: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        librodiario.leerlibrodiario();
                        break;
                    case "2":
                        agregarasiento(plandecuentas);
                        break;
                    case "3":
                        foreach (var Cuentas in plandecuentas)
                        {
                            Console.WriteLine(Cuentas.Codigo + "|" + Cuentas.Nombre + "|" + Cuentas.Tipo);
                        }
                        Console.ReadLine();
                        break;
                    case "4":
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        private static void crearLibroDiario()
        {
            string appDataPath;
            string path;
            string pathtxt;
            
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = Path.Combine(appDataPath, @"A875490.Actividad03\");
            pathtxt = path + "librodiario.txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);                
                File.Create(pathtxt);
                TimeSpan interval = new TimeSpan(0, 0, 3);
                Thread.Sleep(interval);
                
            }

            nAsiento++;
            string[] lines = File.ReadAllLines(pathtxt);
            foreach (string line in lines)
            {
                string[] col = line.Split("|");
                //DateTime fecha = DateTime.Parse(col[0]);

                //asientos.Add(new Asientos(fecha,));
                //plandecuentas.Add(new Cuentas(fecha, col[1], col[2]));
            }


        }

        private static void agregarasiento(List<Cuentas> plandecuentas)
        {
            Asientos asiento = Asientos.Ingresar(plandecuentas);
            asientos.Add(nAsiento, asiento);

            //asiento.MostrarAsiento(asiento);

        }

        private static void CrearPlanDeCuentas()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "PlanDeCuentas.txt");
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] col = line.Split("|");
                plandecuentas.Add(new Cuentas(col[0], col[1], col[2]));
            }
        }
    }
}
