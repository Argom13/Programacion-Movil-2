using DataBinding.Modelo;

namespace DataBinding
{
    public partial class MainPage : ContentPage
    {
        Persona person = new Persona();

        public MainPage()
        {
            InitializeComponent();
            
            person = new Persona
            {
                Name = "Nepumuseno",
                Phone = "123456789",
                Address = "Calle Falsa 123"

            };
            BindingContext = person;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {


            person.Name = "Mariano";
            person.Phone = "987654321";
            person.Address = "Aqui estamos";



            /*txtNombre.BindingContext = person;
            txtNombre.SetBinding(Label.TextProperty, "Name");*/

            /*Binding PersonaBinding = new Binding();

            PersonaBinding.Source = person;
            PersonaBinding.Path = "Name";

            txtNombre.SetBinding(Label.TextProperty, PersonaBinding);*/
        }
    }
}
