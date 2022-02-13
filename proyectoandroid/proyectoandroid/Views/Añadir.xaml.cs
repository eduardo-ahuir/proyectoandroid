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
        int Fuerza = 0;
        int Destreza = 0;
        int Constitucion = 0;
        int Inteligencia = 0;
        int Sabiduria = 0;
        int Carisma = 0;
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
            borrar.IsEnabled = false;
            editar.IsEnabled = false;
            Id.Text = String.Empty;
        }

        private async void Añadirpjs(object sender, EventArgs e)
        {
            
            int id = 0;
            var allIds = await firebaseHelper.GetAllPersonajes();
            id = allIds[allIds.Count() - 1].Idpersonaje + 1;
            if (String.IsNullOrEmpty(Nombre.Text) == true | clase.SelectedIndex < 0 | Raza.SelectedIndex < 0 | alineamiento.SelectedIndex < 0)
            {

                Error1.IsVisible = true;

            }
            else
            {


                stats();
                await firebaseHelper.AddPersonaje(id, Nombre.Text, clase.SelectedItem.ToString(), Raza.SelectedItem.ToString(), URL.Text, Rasgo.Text, Ideal.Text, Vinculo.Text, Defecto.Text, Objeto.Text, alineamiento.SelectedItem.ToString(),Fuerza,Destreza,Constitucion,Inteligencia,Sabiduria,Carisma);
                Limpiar();
                await DisplayAlert("Éxito", "Personaje añadido correctamente", "Aceptar");
                Id.Text = id.ToString();

                
            }
        }

        private async void Borrapjs(object sender, EventArgs e)
        {
            try
            {
                await firebaseHelper.DeletePersonaje(Convert.ToInt32(Id.Text));
                await DisplayAlert("Éxito", "Personaje Borrado correctamente", "Aceptar");
                Id.Text = String.Empty;
                Limpiar();
            }
            catch (System.FormatException) { await DisplayAlert("ERROR", "el campo id no puede estar vacio", "Aceptar"); }
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
                        borrar.IsEnabled = true;
                        editar.IsEnabled = true;
                    }
                
                
                else
                {
                    await DisplayAlert("Alerta", "No se encontró el personaje introduce un id existente", "Aceptar");
                }
                      
                        
            }


                



        }

        private async void Updatepjs(object sender, EventArgs e)
        {
            try
            {
                await firebaseHelper.UpdatePersonaje(Convert.ToInt32(Id.Text), Nombre.Text, clase.SelectedItem.ToString(), Raza.SelectedItem.ToString(), URL.Text, Rasgo.Text, Ideal.Text, Vinculo.Text, Defecto.Text, Objeto.Text, alineamiento.SelectedItem.ToString());
                Limpiar();
                await DisplayAlert("Éxito", "Personaje actualizado correctamente", "Aceptar");
            }
            catch (System.FormatException) {
                await DisplayAlert("ERROR", "El campo id no puede estar vacio", "Aceptar");
                
            } 
               
        }



        private void stats() {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int[] numeros2 = new int[4];
            int[] numeros3 = new int[7];
            int min = numeros2.Min();


            for (int p = 0; p < 7; p++)
            {

                for (int i = 0; i < numeros2.Length; i++)
                {
                    var value = rand.Next(1, 6);
                    numeros2[i] = value;

                }
                for (int o = 0; o < numeros2.Length; o++)
                {
                    if (numeros2[o] == min)
                    {
                        numeros2[o] = 0;
                    }
                }
                numeros3[p] = numeros2.Sum();
            }
            numeros3 = numeros3.Where(a => a != numeros3.Min()).ToArray();
            Fuerza = numeros3[0];
            Destreza = numeros3[1];
            Constitucion = numeros3[2];
            Inteligencia = numeros3[3];
            Sabiduria = numeros3[4];
            Carisma = numeros3[5];

        }
    
    
    
    
    }
    }

