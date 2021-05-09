using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace A875490.Actividad03
{
    class Librodiario
    {
        public string appDataPath { get; set; }
        public string path { get; set; }
        public string pathtxt { get; set; }
        public decimal monto { get; set; }
        public DateTime fecha { get; set; }



        public void crearLibroDiario()
        {
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = Path.Combine(appDataPath, @"A875490.Actividad03\");
            pathtxt = path + "librodiario.txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                StreamWriter w = File.CreateText(pathtxt);
                w.WriteLine(" ");
                w.Close();
            }

        }

        internal void leerlibrodiario()
        {
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = Path.Combine(appDataPath, @"A875490.Actividad03\");
            pathtxt = path + "librodiario.txt";
            
            //StreamReader w = new StreamReader(pathtxt);
            //Console.WriteLine(w.ReadToEnd);
            string texto = File.ReadAllText(pathtxt);
            Console.WriteLine(texto);     
            //w.Close;
            //var archivo = File.ReadAllText(pathtxt);
            //Console.WriteLine(archivo);            
            Console.ReadLine();
        }
    }
}
