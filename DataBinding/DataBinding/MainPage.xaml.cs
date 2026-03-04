using DataBinding.Modelo;

namespace DataBinding
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            /*var person = new Persona
            {
                Name = "Nepumuseno",
                Phone = "123456789",
                Address = "Calle Falsa 123"

            };*/

            /*Binding PersonaBinding = new Binding();

            PersonaBinding.Source = person;
            PersonaBinding.Path = "Name";

            txtNombre.SetBinding(Label.TextProperty, PersonaBinding);*/
        }
    }
}
