using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Edutor.App
{
    public partial class InitialPage : ContentPage
    {
        public InitialPage()
        {
            InitializeComponent();
            
            edutorImage.Aspect = Aspect.Fill;
            edutorImage.Source = ImageSource.FromFile("edutor_logo.jpg");

            buttonPadre.Clicked += Button_Clicked;
            buttonProfesor.Clicked += Button_Clicked;

        }

        void Button_Clicked(object sender, EventArgs e)
        {
            var sndr = sender as Button;
            string rs = String.Empty;
            if (sndr.Equals(buttonPadre))
            {

            }
            else if (sndr.Equals(buttonProfesor))
            {

            }

            DisplayAlert(sndr.Text + " clicked", "A", "OK");
        }
    }
}
