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

            //Desea guardar el asiento en archivo?
            bool guardar = Validador.PreguntaSiNo("Desea guardar el asiento en archivo? S/N");
            if (guardar == true)
            {
                guardarmovimiento(inserciones, fecha);
            }


            return new Asientos(fecha, inserciones);
        }

        private static void guardarmovimiento(List<Movimientos> inserciones, DateTime fecha)
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
            }


            StreamWriter w = File.AppendText(pathtxt);




            Validador.Separador();
            Validador.DebeHaber(fecha);
            //File.AppendAllText(pathtxt, fecha.ToShortDateString());
            decimal totaldebe = 0;
            decimal totalhaber = 0;
            foreach (var movimiento in inserciones)
            {
                decimal haber = 0;
                decimal debe = 0;
                if (!movimiento.TipoMovimiento)
                {
                    haber = movimiento.Monto;
                    debe = 0;
                    string texto = $"{fecha.ToShortDateString().PadRight(15)}|{movimiento.Nombrecuenta.PadRight(40)}|{movimiento.Nombre.PadRight(20)}|{debe.ToString().PadLeft(20)}|{haber.ToString().PadLeft(20)}";
                    //File.AppendAllText(pathtxt, texto + Environment.NewLine);
                    w.WriteLine(pathtxt);
                }
                if (movimiento.TipoMovimiento)
                {
                    haber = 0;
                    debe = movimiento.Monto;
                    string texto = ($"{fecha.ToShortDateString().PadRight(15)}|{movimiento.Nombrecuenta.PadRight(40)}|{movimiento.Nombre.PadRight(20)}|{debe.ToString().PadLeft(20)}|{haber.ToString().PadLeft(20)}");
                    //File.AppendAllText(pathtxt, texto + Environment.NewLine);
                    w.WriteLine(pathtxt);
                }
                totaldebe = totaldebe + debe;
                totalhaber = totalhaber + haber;


            }
            string frase = "Total";
            
            string texto3 = $"{frase.PadLeft(70)}{totaldebe.ToString().PadLeft(20)}|{totalhaber.ToString().PadLeft(20)}";
            //File.AppendAllText(pathtxt, texto3 + Environment.NewLine);
            w.WriteLine(pathtxt);





        }

        private static void mostrarMovimiento(List<Movimientos> inserciones, DateTime fecha)
        {

            Validador.Separador();
            Validador.DebeHaber(fecha);
            decimal totaldebe = 0;
            decimal totalhaber = 0;            
            foreach (var movimiento in inserciones)
            {
                decimal haber = 0;
                decimal debe = 0;
                if (!movimiento.TipoMovimiento)
                {
                    haber = movimiento.Monto;
                    debe = 0;
                    Console.WriteLine($"{fecha.ToShortDateString().PadRight(15)}|{movimiento.Nombrecuenta.PadRight(40)}|{movimiento.Nombre.PadRight(20)}|{debe.ToString().PadLeft(20)}|{haber.ToString().PadLeft(20)}");
                    
                }
                if (movimiento.TipoMovimiento)
                {
                    haber = 0;
                    debe = movimiento.Monto;
                    Console.WriteLine($"{fecha.ToShortDateString().PadRight(15)}|{movimiento.Nombrecuenta.PadRight(40)}|{movimiento.Nombre.PadRight(20)}|{debe.ToString().PadLeft(20)}|{haber.ToString().PadLeft(20)}");
                    
                }
                totaldebe = totaldebe + debe;
                totalhaber = totalhaber + haber;
                

            }
            string frase = "Total";
            Validador.Separador();
            Console.WriteLine($"{frase.PadLeft(70)}{totaldebe.ToString().PadLeft(20)}|{totalhaber.ToString().PadLeft(20)}");
        }

        internal void MostrarAsiento()
        {
          
            
        }


        }
    }
