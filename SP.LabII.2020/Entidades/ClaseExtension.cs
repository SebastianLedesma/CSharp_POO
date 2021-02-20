using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class ClaseExtension
    {
        public static string InformarNovedad(this CartucheraLlenaException cart)
        {
            return "Cartuchera llena.Salida desde el metodo de extension.";
        }
    }
}
