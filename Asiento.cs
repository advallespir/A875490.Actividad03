﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

namespace A875490.Actividad03
{
    class Asiento
    {
        public string appDataPath { get; set; }
        public string path { get; set; }
        public string pathtxt { get; set; }



        public void crearLibroDiario()
        {
            appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            path = Path.Combine(appDataPath, @"A875490.Actividad03\");
            pathtxt = path + "librodiario.txt";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);                
                File.Create(pathtxt);
            }

        }

        internal void leerlibrodiario()
        {
            var archivo = File.ReadAllText(pathtxt);
            Console.WriteLine(archivo);
            Console.ReadLine();
        }
    }
}
