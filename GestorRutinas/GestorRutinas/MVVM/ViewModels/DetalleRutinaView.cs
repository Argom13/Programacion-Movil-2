using System;
using System.Linq;
using System.Collections.ObjectModel;
using GestorRutinas.MVVM.Models;

namespace GestorRutinas.MVVM.ViewModels
{
    public class RutinaViewModel
    {
        public Rutina RutinaSeleccionada { get; set; }

        public Ejercicio EjercicioSeleccionado { get; set; }

        public RutinaViewModel()
        {
            RutinaSeleccionada = new Rutina
            {
                Nombre = "Nueva Rutina",
                Descripcion = string.Empty,
                Activa = true
            };
        }

        public RutinaViewModel(Rutina rutina)
        {
            RutinaSeleccionada = rutina ?? new Rutina();
        }

        public bool AgregarEjercicio(string nombre, int series, int reps, decimal peso)
        {
            if (string.IsNullOrWhiteSpace(nombre) || series <= 0 || reps <= 0 || peso <= 0)
                return false;

            var ej = new Ejercicio
            {
                Nombre = nombre,
                Descripcion = string.Empty,
                Series = series,
                Repeticiones = reps,
                Peso = (double)peso,
                UltimaEjecucion = DateTime.MinValue
            };

            RutinaSeleccionada.Ejercicios.Add(ej);
            return true;
        }

        public void RegistrarEjecucion(Ejercicio ejercicio)
        {
            if (ejercicio == null) return;
            ejercicio.UltimaEjecucion = DateTime.Now;
        }

        public void EliminarEjercicio(Ejercicio ejercicio)
        {
            if (ejercicio == null) return;
            RutinaSeleccionada.Ejercicios.Remove(ejercicio);
        }
    }
}
