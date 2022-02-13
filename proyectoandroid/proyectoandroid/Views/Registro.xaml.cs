using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using proyectoandroid.ViewModels;
using Xamarin.Forms.Xaml;
using CRUDFireBase.Helper;
using Xamarin.Forms;
using System.Security.Cryptography;

namespace proyectoandroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
        }
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        private async void registro(object sender, EventArgs e)
        {
            register();



        }


        public async void register()
        {

            var allusers = await firebaseHelper.GetAllPersonajes();
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(contraseñar.Text);
            byte[] result;
            SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider();
            result = sha.ComputeHash(data);
            StringBuilder sb = new StringBuilder();
            for (int a = 0; a < result.Length; a++)
            {
                if (result[a] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[a].ToString("x"));
            }
            sb.ToString().ToUpper();


            for (int i = 0; i < allusers.Count; i++)
            {
                if (!String.IsNullOrEmpty(usuarior.Text)&&usuarior.Text.Equals(allusers[i].usuario))
                {
                    await DisplayAlert("Error", "ese usuario ya existe", "Aceptar");
                    usuarior.Text = String.Empty;
                }
                else {
                    if (!String.IsNullOrEmpty(contraseñar.Text) && contraseñar.Text.Equals(contraseñar2.Text))
                    {
                        await DisplayAlert("Exito", "Usuario registrado correctamente", "Aceptar");
                        Error.IsVisible = false;
                        await firebaseHelper.Addusuario(usuarior.Text, sb.ToString().ToUpper());
                        await Shell.Current.GoToAsync("//LoginPage");
                        break;
                        
                    }
                    else { Error.IsVisible=true; }
                     
                }
                
                
            }



        }
    }
}