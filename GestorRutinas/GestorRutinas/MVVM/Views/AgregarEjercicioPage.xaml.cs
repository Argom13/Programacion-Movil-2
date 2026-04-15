using GestorRutinas.MVVM.ViewModels;

namespace GestorRutinas.MVVM.Views;

public partial class AgregarEjercicioPage : ContentPage
{
    private RutinaViewModel _viewModel;

    public AgregarEjercicioPage(RutinaViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        ActualizarResumen();
    }

    private void OnSeriesSliderChanged(object sender, ValueChangedEventArgs e)
    {
        SeriesValueLabel.Text = $"{(int)e.NewValue}";
        ActualizarResumen();
    }

    private void OnRepeticionesSliderChanged(object sender, ValueChangedEventArgs e)
    {
        RepeticionesValueLabel.Text = $"{(int)e.NewValue}";
        ActualizarResumen();
    }

    private void ActualizarResumen()
    {
        var series = (int)SeriesSlider.Value;
        var reps = (int)RepeticionesSlider.Value;
        var nombre = NombreEntry.Text ?? "Sin nombre";

        ResumenLabel.Text = $"{nombre}\n" +
                          $"Series: {series} | Repeticiones: {reps}\n" +
                          $"Total reps: {series * reps}";
    }

    private async void OnCancelarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnGuardarClicked(object sender, EventArgs e)
    {
        string nombre = NombreEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            await DisplayAlert("Error", "El nombre del ejercicio es requerido.", "OK");
            return;
        }

        if (!decimal.TryParse(PesoEntry.Text, out decimal peso))
        {
            await DisplayAlert("Error", "Ingresa un peso válido (numérico).", "OK");
            return;
        }

        if (peso <= 0)
        {
            await DisplayAlert("Error", "El peso debe ser mayor a 0.", "OK");
            return;
        }

        int series = (int)SeriesSlider.Value;
        int reps = (int)RepeticionesSlider.Value;
        string descripcion = DescripcionEditor.Text ?? "";

        bool agregado = _viewModel.AgregarEjercicio(nombre, series, reps, peso);

        if (agregado)
        {
            await DisplayAlert("¡Éxito!",
                $"Ejercicio agregado: {nombre}\n{series}x{reps} @ {peso}kg",
                "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "No se pudo agregar el ejercicio.", "OK");
        }
    }

}