using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GestorRutinas.MVVM.Models
{
    public class Rutina
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Activa { get; set; }

        public ObservableCollection<Ejercicio> Ejercicios { get; set; } = new();

        public int TotalEjercicios => Ejercicios.Count;

        public double VolumenTotalRutina => Ejercicios.Sum(e => e.VolumenTotal);

        public Ejercicio EjercicioMayorPeso =>
            Ejercicios.OrderByDescending(e => e.Peso).FirstOrDefault();
    }
}
