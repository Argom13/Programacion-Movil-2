using System;
using System.Collections.Generic;
using System.Text;

namespace GestorRutinas.MVVM.Models
{
    public class Ejercicio
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Series { get; set; }
        public int Repeticiones { get; set; }
        public double Peso { get; set; }

        public double VolumenTotal => Series * Repeticiones * Peso;

        public DateTime UltimaEjecucion { get; set; } = DateTime.MinValue;

        public int DiasDesdeÚltimo =>
            UltimaEjecucion == DateTime.MinValue
                ? int.MaxValue
                : (DateTime.Now - UltimaEjecucion).Days;

        public int DiasDesdeUltimo => DiasDesdeÚltimo;

    }
}
