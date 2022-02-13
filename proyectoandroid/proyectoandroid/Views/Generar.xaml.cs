using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUDFireBase.Helper;
using CRUDFireBase.Model;

namespace proyectoandroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Generar : ContentPage
    {
        int idpersonajeal=0;
        public Generar()
        {
            InitializeComponent();
            GetPersonajeal();
        }
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        

        public async void GetPersonajeal()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();
            Random rnd = new Random();
            
            int idaleat = rnd.Next(0, allIds.Count());
           idpersonajeal=allIds[idaleat].Idpersonaje;
            
            

        }

        public async void GetPersonajeaclase()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();
            Random rnd = new Random();

            
            Boolean loop = true;

            
            while (loop) {
                int idaleat = rnd.Next(0, allIds.Count());


                if (allIds[idaleat].Clase.Equals(claseselect.SelectedItem))
                {
                    claseselect.Title = idaleat.ToString();
                    idpersonajeal = allIds[idaleat].Idpersonaje;
                    loop = false;
                }
                  
            }
            
            



        }
        public async void GetPersonajearaza()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();
            Random rnd = new Random();


            Boolean loop = true;


            while (loop)
            {
                int idaleat = rnd.Next(0, allIds.Count());


                if (allIds[idaleat].Raza.Equals(razaselect.SelectedItem))
                {
                    
                    idpersonajeal = allIds[idaleat].Idpersonaje;
                    loop = false;
                }

            }





        }

        public async void GetPersonajearazayclase()
        {
            var allIds = await firebaseHelper.GetAllPersonajes();
            Random rnd = new Random();


            Boolean loop = true;


            while (loop)
            {
                int idaleat = rnd.Next(0, allIds.Count());


                if (allIds[idaleat].Raza.Equals(razaselect.SelectedItem))
                {
                    if (allIds[idaleat].Clase.Equals(claseselect.SelectedItem)) {
                        
                        idpersonajeal = allIds[idaleat].Idpersonaje;
                        loop = false;

                    }
                    
                }

            }





        }

        private void limpiar() {
            Nombre.Text = String.Empty;
            Clase.Text = String.Empty;
            Raza.Text = String.Empty;
            Url.Source =String.Empty;
            Rasgo.Text = "Rasgo:";
            Ideal.Text = "Ideal:";
            Vinculo.Text = "Vinculo:";
            Defecto.Text = "Defecto:";
            Objeto.Text = "Objeto:";
            Moral.Text = "Moral:";
            
        }


        private async void GeneraRandom(object sender, EventArgs e)
        {


            if (claseselect.SelectedItem != null && razaselect.SelectedItem != null)
            {
                GetPersonajearazayclase();

            }
            else {
                if (claseselect.SelectedItem != null)
                {
                    GetPersonajeaclase();
                    razaselect.SelectedItem = null;
                }
                else
                {
                    if (razaselect.SelectedItem != null)
                    {
                        GetPersonajearaza();
                        claseselect.SelectedItem = null;
                    }
                    else { GetPersonajeal(); }
                }
            }
            
            
                


            
            
             
            
               
            
            var personaje = await firebaseHelper.GetPersonaje(idpersonajeal);
            if (personaje != null)
            {
                limpiar();
                Nombre.Text = personaje.Nombre.ToString();
                Clase.Text = Clase.Text+personaje.Clase;
                Raza.Text = Raza.Text+personaje.Raza;
                Url.Source = personaje.URL;
                Rasgo.Text = Rasgo.Text+personaje.Rasgo;
                Ideal.Text = Ideal.Text+personaje.Ideal;
                Vinculo.Text = Vinculo.Text+personaje.Vinculo;
                Defecto.Text = Defecto.Text+personaje.Defecto;
                Objeto.Text = Objeto.Text+personaje.Objeto;
                Moral.Text = Moral.Text+personaje.Alineamiento;
                claseselect.SelectedIndex = -1;
                razaselect.SelectedIndex = -1;
                GetPersonajeal();
                await DisplayAlert("Éxito", "Personaje generado con exito", "Aceptar");

            }
            else
            {
                await DisplayAlert("Alerta", "Error en la generacion del personaje vuelve a intentarlo y si el error persiste contacta con el Administrador", "Aceptar");
            }

        }


       
        
        
        
        

        }











    }
