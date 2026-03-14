using Microsoft.Maui.Controls;

namespace Proyecto_Diego_Fajardo;

public partial class MainPage : ContentPage
{
    const double USD_A_HNL = 26.47;
    const double EUR_A_HNL = 30.36;
    const double HNL_A_HNL = 1.0;

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnMontoChanged(object sender, TextChangedEventArgs e)
    {
        Convertir();
    }

    private void OnMonedaChanged(object sender, CheckedChangedEventArgs e)
    {
        Convertir();
    }

    private void OnIntercambiarClicked(object sender, EventArgs e)
    {
        bool origenHNL = rbOrigenHNL.IsChecked;
        bool origenUSD = rbOrigenUSD.IsChecked;
        bool origenEUR = rbOrigenEUR.IsChecked;

        rbOrigenHNL.IsChecked = rbDestinoHNL.IsChecked;
        rbOrigenUSD.IsChecked = rbDestinoUSD.IsChecked;
        rbOrigenEUR.IsChecked = rbDestinoEUR.IsChecked;

        rbDestinoHNL.IsChecked = origenHNL;
        rbDestinoUSD.IsChecked = origenUSD;
        rbDestinoEUR.IsChecked = origenEUR;

        Convertir();
    }

    private string ObtenerMonedaOrigen()
    {
        if (rbOrigenUSD.IsChecked) return "USD";
        if (rbOrigenEUR.IsChecked) return "EUR";
        return "HNL";
    }

    private string ObtenerMonedaDestino()
    {
        if (rbDestinoUSD.IsChecked) return "USD";
        if (rbDestinoEUR.IsChecked) return "EUR";
        return "HNL";
    }

    private double ObtenerTasaEnHNL(string moneda)
    {
        switch (moneda)
        {
            case "USD": return USD_A_HNL;
            case "EUR": return EUR_A_HNL;
            default: return HNL_A_HNL;
        }
    }

    private void Convertir()
    {
        if (string.IsNullOrEmpty(entryMonto.Text))
        {
            lblResultado.Text = "0.00";
            lblTasa.Text = "";
            return;
        }

        if(double.TryParse(entryMonto.Text, out double monto))
        { 

            string origen = ObtenerMonedaOrigen();
            string destino = ObtenerMonedaDestino();

            
            double enHNL = monto * ObtenerTasaEnHNL(origen);
            double resultado = enHNL / ObtenerTasaEnHNL(destino);

            
            double tasaDirecta = ObtenerTasaEnHNL(origen) / ObtenerTasaEnHNL(destino);

            lblResultado.Text = resultado.ToString();
            lblTasa.Text = $"1 {origen} = {tasaDirecta} {destino}";
        }
    }
}
