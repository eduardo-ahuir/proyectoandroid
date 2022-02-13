using proyectoandroid.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CRUDFireBase.Helper;
using System.Security.Cryptography;

namespace proyectoandroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        FirebaseHelper firebaseHelper = new FirebaseHelper();






        public void hash() {
            

        }




        public async void login()
        {
            var allusers = await firebaseHelper.GetAllusurios();
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(contraseña.Text);
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

                try
                {
                    if (usuario.Text.Equals(allusers[i].usuario))
                    {
                        if (allusers[i].contraseña.Equals(sb.ToString().ToUpper()))
                        {


                            await Shell.Current.GoToAsync("//Generar");

                        }
                        




                    }
                    

                }
                catch (System.ArgumentNullException) {
                    await DisplayAlert("Error", "usuario o contraseña incorrectos", "Aceptar");
                }


        }
        }

        private void Login(object sender, EventArgs e)
        {
            login();
        }

        private void iraregistro(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}