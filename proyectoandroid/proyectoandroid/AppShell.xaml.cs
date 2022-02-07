using proyectoandroid.ViewModels;
using proyectoandroid.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace proyectoandroid
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(Añadir), typeof(Añadir));
            Routing.RegisterRoute(nameof(Generar), typeof(Generar));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
