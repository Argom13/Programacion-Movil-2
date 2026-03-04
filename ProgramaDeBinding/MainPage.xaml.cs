using ProgramaDeBinding.modelo;

namespace ProgramaDeBinding
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            var person = new Person
            {
                Name = "Francisco",
                Phone = "99784512",
                Address = "Tegucigalpa"

            };

            Binding personBinding = new Binding
            {
                Source = person,

                Path = "Name"
            };

            txtnombre.SetBinding(Label.TextProperty, personBinding);
          


        }

    }

}
