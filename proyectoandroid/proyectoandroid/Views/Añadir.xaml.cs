using proyectoandroid.Models;
using proyectoandroid.ViewModels;
using proyectoandroid.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firebase.Database;
using Firebase.Database.Query;
using CRUDFireBase.Helper;
using CRUDFireBase.Model;


namespace proyectoandroid.Views
{
    public partial class Añadir : ContentPage
    {
        ItemsViewModel _viewModel;
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        
        public Añadir()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }



        private void Limpiar()
        {
            Nombre.Text = String.Empty;
            clase.SelectedIndex = -1;
            Raza.SelectedIndex = -1;
            URL.Text = String.Empty;
            Rasgo.Text = String.Empty;
            Ideal.Text = String.Empty;
            Vinculo.Text = String.Empty;
            Defecto.Text = String.Empty;
            Objeto.Text = String.Empty;
            alineamiento.SelectedIndex = -1;

        }

        private async void Añadirpjs(object sender, EventArgs e)
        {
            Random random = new Random();
            int id = random.Next(1, 1000000);

            if (String.IsNullOrEmpty(Nombre.Text) == true | clase.SelectedIndex < 0 | Raza.SelectedIndex < 0 | alineamiento.SelectedIndex < 0)
            {

                Error1.IsVisible = true;

            }
            else
            {



                await firebaseHelper.AddPersonaje(id, Nombre.Text, clase.SelectedItem.ToString(), Raza.SelectedItem.ToString(), URL.Text, Rasgo.Text, Ideal.Text, Vinculo.Text, Defecto.Text, Objeto.Text, alineamiento.SelectedItem.ToString());
                Limpiar();
                await DisplayAlert("Éxito", "Personaje añadido correctamente", "Aceptar");
                Id.Text = id.ToString();
            }
        }

        private async void Borrapjs(object sender, EventArgs e)
        {
            await firebaseHelper.DeletePersonaje(Convert.ToInt32(Id.Text));
            await DisplayAlert("Éxito", "Personaje Borrado correctamente", "Aceptar");
            Id.Text = String.Empty;
            Limpiar();
        }

        private void Borraerror(object sender, TextChangedEventArgs e)
        {
            Error1.IsVisible = false;
        }

        private void BorraerrorPicker(object sender, EventArgs e)
        {
            Error1.IsVisible = false;
        }


        private async void BtnRetrive_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Id.Text))
            {
                var personaje = await firebaseHelper.GetPersonaje(Convert.ToInt32(Id.Text));
                if (personaje != null)
                {
                    Nombre.Text = personaje.Nombre.ToString();
                    clase.SelectedItem = personaje.Clase;
                    Raza.SelectedItem = personaje.Raza;
                    URL.Text = personaje.URL;
                    Rasgo.Text = personaje.Rasgo;
                    Ideal.Text = personaje.Ideal;
                    Vinculo.Text = personaje.Vinculo;
                    Defecto.Text = personaje.Defecto;
                    Objeto.Text = personaje.Objeto;
                    alineamiento.SelectedItem = personaje.Alineamiento;    
                    await DisplayAlert("Éxito", "Datos del personaje Cargados con exitos", "Aceptar");

                }
                else
                {
                    await DisplayAlert("Alerta", "No se encontró el personaje introduce un id existente", "Aceptar");
                }
            }
            




        }

        private async void Updatepjs(object sender, EventArgs e)
        {
            await firebaseHelper.UpdatePersonaje(Convert.ToInt32(Id.Text), Nombre.Text, clase.SelectedItem.ToString(), Raza.SelectedItem.ToString(), URL.Text, Rasgo.Text, Ideal.Text, Vinculo.Text, Defecto.Text, Objeto.Text, alineamiento.SelectedItem.ToString());
            Limpiar();
            await DisplayAlert("Éxito", "Personaje actualizado correctamente", "Aceptar");
            
        }
    }
}
